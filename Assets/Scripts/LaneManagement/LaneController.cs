using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using UnityEngine;

public class LaneController : MonoBehaviour
{
    [Range(1, 4)] public int laneNumber = 1;
    public Transform spawnPoint;
    public Transform judgeLine;
    public float hitWindowAfter = 0.35f;
    public float expireAfter = 8.0f;

    public LaneInventory Inventory { get; private set; } = new();

    private readonly Queue<NoteView> _queue = new();

    private void OnEnable() => LaneRouter.Register(this);
    private void OnDisable() => LaneRouter.Unregister(this);

    public float JudgeY => judgeLine.position.y;

    public void OnNoteSpawned(NoteView note)
    {
        _queue.Enqueue(note);
    }

    void Update()
    {
        while (_queue.Count > 0 && _queue.Peek().IsResolved)
            _queue.Dequeue();

        if (_queue.Count == 0) return;

        float t = GameManager.Instance.SongTime;
        var note = _queue.Peek();

        if (!note.HasCrossed) return;

        if (t > note.BornTime + expireAfter)
        {
            note.MarkMiss();
            ScoreSystem.Instance.AddMiss();
            _queue.Dequeue();
        }
    }
    
    public void TryHit()
    {
        while (_queue.Count > 0 && _queue.Peek().IsResolved) _queue.Dequeue();
        if (_queue.Count == 0) return;

        var note = _queue.Peek();
        if (!note.HasCrossed) return;

        float t = GameManager.Instance.SongTime;

        if (t >= note.CrossTime && t <= note.CrossTime + expireAfter && t>= note.CrossTime + hitWindowAfter)
        {
            if (Inventory.TryStore(note.Color))
            {
                note.MarkMiss();
                _queue.Dequeue();
                return;
            }
            else return;
        }

        if (t >= note.CrossTime && t <= note.CrossTime + hitWindowAfter)
        {
            if (Inventory.TryStore(note.Color))
            {
                note.MarkHit();
                _queue.Dequeue();
                return;
            }
            else
            {
                return;
            }
        }
    }
    public void AddBox()
    {
        if (CheckBox()) Inventory.AddBox();
        else;
    }

    public bool CheckBox()
    {
        var note = _queue.Peek();
        int current = Inventory.GetFilled(note.Color);
        if (current == Inventory.BoxCount)
        {
            UnityEngine.Debug.Log($"{current}, {Inventory.BoxCount}");
            return true;
        }
        else { return false; }
    }

}
