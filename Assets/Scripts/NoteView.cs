using System.ComponentModel;
using System.Diagnostics;
using System.IO.Compression;
using TMPro;
using UnityEngine;

public class NoteView : MonoBehaviour
{
    public int Lane { get; private set; }
    public NoteColor Color { get; private set; }
    public float Speed { get; private set; }

    public bool HasCrossed { get; private set; }
    public bool IsResolved { get; private set; }
    public float CrossTime { get; private set; }
    public float BornTime{get;private set;}
    
    [SerializeField]
    private TMP_Text laneNum;

    private float _judgeY;

    public void Init(int lane, NoteColor color, float speed, float judgeY)
    {
        Lane = lane;
        Color = color;
        Speed = speed;
        _judgeY = judgeY;
        HasCrossed = false;
        IsResolved = false;
        BornTime = GameManager.Instance.SongTime;


        Color unityColor = color switch
        {
            NoteColor.Red => UnityEngine.Color.red,
            NoteColor.Yellow => UnityEngine.Color.yellow,
            NoteColor.Blue => UnityEngine.Color.blue,
            NoteColor.Green => UnityEngine.Color.green,
            _ => UnityEngine.Color.white
        };

        var sr = GetComponent<SpriteRenderer>();
        if (sr) sr.color = unityColor;
        sr.color = new Color(unityColor.r, unityColor.g, unityColor.b, 0f);

        laneNum.text = lane.ToString();
        laneNum.color = unityColor;
    }

    void Update()
    {
        transform.position += Vector3.down * (Speed * Time.deltaTime);

        if (!HasCrossed && transform.position.y <= _judgeY)
        {
            HasCrossed = true;
            CrossTime = GameManager.Instance.SongTime;
        }

    }

    public void MarkHit() { IsResolved = true; Destroy(gameObject); }
    public void MarkMiss() { IsResolved = true;  Destroy(gameObject); }
}
