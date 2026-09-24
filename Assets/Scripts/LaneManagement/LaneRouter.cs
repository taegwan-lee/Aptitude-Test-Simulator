using System.Collections.Generic;
using UnityEngine;

public static class LaneRouter
{
    private static readonly Dictionary<int, LaneController> _map = new();

    public static void Register(LaneController lc) => _map[lc.laneNumber] = lc;
    public static void Unregister(LaneController lc)
    {
        if (_map.TryGetValue(lc.laneNumber, out var cur) && cur == lc) _map.Remove(lc.laneNumber);
    }
    public static LaneController For(int lane) => _map[lane];
}
