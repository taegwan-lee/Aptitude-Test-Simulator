using System;
using System.Diagnostics;
using UnityEngine;

public class TimeCheck : MonoBehaviour
{
    [SerializeField]
    private int NumTerm = 8; //numterm마다 숫자 바뀌게
    [SerializeField]
    private AudioClip[] numSounds;
    [SerializeField]
    private AudioSource audioSource;

    float t = 0;
    int TestNum;

    public static TimeCheck Instance { get; private set;}
    int currentNum = -1;
    bool CanAnswer = false;
    bool isRunning = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }
    void Update()
    {
        float delay = GameManager.Instance.SongTime - t;
        
        if (delay >= NumTerm && isRunning==true)
        {
            if(currentNum==7 && CanAnswer == true)//이전에 7이었는데 버튼 안눌렀으면 점수 깎음(7놓쳤을때)
            {
                ScoreSystem.Instance.TimeIncorrectUp(); 
            }
            TestNum = RandNum();
            currentNum = TestNum;
            CanAnswer = true;

            NumPlay(TestNum);
            t = GameManager.Instance.SongTime;
        }
    }

    private int RandNum()
    {
        int r = UnityEngine.Random.Range(1, 10);
        return r;
    }

    private void NumPlay(int num)
    {
        int index = num - 1;
        audioSource.PlayOneShot(numSounds[index]);
    }

    public void TryTimeButton()
    {
        if(!CanAnswer) return;
        CanAnswer = false;

        if(currentNum == 7)
        {
            ScoreSystem.Instance.TimeCorrectUp();
        }
        else 
        {   
            ScoreSystem.Instance.TimeIncorrectUp(); 
        }
    }

    public void StartNumber()
    {
        isRunning = true;
    }
    public void StopNumber()
    {
        CanAnswer = false;
        isRunning = false;
    }
}
