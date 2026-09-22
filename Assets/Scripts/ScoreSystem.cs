using UnityEngine;

public class ScoreSystem : MonoBehaviour
{   
    public static ScoreSystem Instance { get; private set; }
    public int lossingCount {get; private set;}    //시간 지나서 노트를 놓친 횟수
    public int TimeCorrect {get; private set;}   //8일때 올바르게 버튼 누른 점수
    public int TimeInCorrect {get; private set;}   //제 때 버튼을 누르지 못해 넘어갔거나, 잘못부른 숫자에 누른 횟수

    private void Start()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        Init();
    } 
    public void Init()
    {
        lossingCount = 0;
        TimeCorrect = 0;
        TimeInCorrect = 0;
    }

    public void AddMiss()
    {
        lossingCount++;
    }

    public void TimeCorrectUp()
    {
        TimeCorrect++;
    }
    public void TimeIncorrectUp()
    {
        TimeInCorrect++;
    }

   
}
