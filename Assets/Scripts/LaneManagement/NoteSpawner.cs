using System.Numerics;
using UnityEngine;
using System.Collections.Generic;
public class NoteSpawner : MonoBehaviour
{
    public ChartSO chart;
    public NoteView notePrefab;
    public LaneController[] lanes;

    public int randomNoteCount = 20;
    public float Speed = 0.1f;
    public float spawnInterval = 4f;
    public int Beat =1;

    private int _idx;

    void Start()
    {
        GenerateRandomChart();

        chart.notes.Sort((a, b) => a.spawnTime.CompareTo(b.spawnTime));
    }

    void Update()
    {
        float t = GameManager.Instance.SongTime;

        while(_idx < chart.notes.Count && chart.notes[_idx].spawnTime <= t)
        {
            var nd = chart.notes[_idx++];
            var lane = lanes[nd.lane - 1];

            var note = Instantiate(notePrefab, lane.spawnPoint.position, UnityEngine.Quaternion.identity);
            note.Init(nd.lane, nd.color, nd.speed, lane.JudgeY);
            lane.OnNoteSpawned(note);
        }
    }

    void GenerateRandomChart()
    {
        chart.notes = new List<NoteData>();
        float currentTime = 0f; //시작하고 몇초뒤부터 시작할건지
        for(int i=0; i<randomNoteCount; i++)
        {

            currentTime += spawnInterval;
            NoteData temp =  new NoteData
            {
                lane = Random.Range(1, lanes.Length+1),
                color = (NoteColor)Random.Range(0, System.Enum.GetValues(typeof(NoteColor)).Length),
                spawnTime = currentTime,
                speed = Speed
            };

            chart.notes.Add(temp);
        }
    }
}
