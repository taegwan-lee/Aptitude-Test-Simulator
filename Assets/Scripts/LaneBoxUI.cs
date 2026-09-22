using System.Collections.Generic;
using UnityEngine;

public class LaneBoxUI : MonoBehaviour
{
    [Header("Refs")]
    public LaneController lane;
    public List<RectTransform> slots;
    public BoxWidget boxPrefab;

    private readonly List<BoxWidget> _boxes = new();

    void Update()
    {
        if (lane == null || lane.Inventory == null) return;
        SyncUI();
    }

    void SyncUI()
    {
        int want = lane.Inventory.BoxCount;

        while (_boxes.Count < want)
        {
            var w = Instantiate(boxPrefab);
            w.transform.SetParent(slots[_boxes.Count], false);
            w.ClearAll();
            _boxes.Add(w);
        }
        while (_boxes.Count > want)
        {
            Destroy(_boxes[^1].gameObject);
            _boxes.RemoveAt(_boxes.Count - 1);
        }

        foreach (var w in _boxes) w.ClearAll();

        foreach(NoteColor c in System.Enum.GetValues(typeof(NoteColor)))
        {
            int filled = lane.Inventory.GetFilled(c);
            for (int i = 0; i < filled && i < _boxes.Count; i++)
                _boxes[i].SetMark(c, true, lane.laneNumber.ToString());
        }
    }
}
