using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class LaneInventory
{
    public int BoxCount { get; private set; } = 1;
    public GameObject BoxImage;
    private readonly Dictionary<NoteColor, int> _filled = new()
    {
            {NoteColor.Red, 0 }, { NoteColor.Yellow, 0},
            {NoteColor.Blue, 0}, {NoteColor.Green,0}
    };

    public void AddBox() {BoxCount++;}

    public bool TryStore(NoteColor color)//박스에 칸 남아있으면 filled 채우고 true 리턴
    {
        if (_filled[color] < BoxCount) { _filled[color]++; return true; }
        return false;
    }

    public int GetFilled(NoteColor c) => _filled[c];

}

