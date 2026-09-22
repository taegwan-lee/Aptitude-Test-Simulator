using System;
using System.Collections.Generic;
using UnityEngine;

public enum NoteColor {Red, Yellow, Blue, Green}

[Serializable]
public struct NoteData
{
    public int lane;
    public NoteColor color;
    public float spawnTime;
    public float speed;

}
[CreateAssetMenu(fileName = "ChartSO", menuName = "Scriptable Objects/ChartSO")]
public class ChartSO : ScriptableObject
{
    public float bpm;
    public List<NoteData> notes;
}
