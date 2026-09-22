using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public AudioSource audioSource;
    public bool useAudioTime = true;

    public float GameDuration = 120f;
    public bool IsPlaying { get; private set;}
    private float startTime;

    private void Start()
    {
        if (Instance != null) { Destroy(gameObject); return; }
        Instance = this;
        StartGame();

    }

    private void Update()
    {
        if(SongTime >= GameDuration && IsPlaying == true)
        {
            EndGame();
        }
    }

    public void StartGame()
    {
        IsPlaying =true;

        if(useAudioTime && audioSource != null)
        {
            audioSource.time = 0f;
            audioSource.Play();
        }
        else
        {
            startTime = Time.time;
        }

        if (TimeCheck.Instance != null)
        {
            TimeCheck.Instance.StartNumber();
        }
    }

    public void EndGame()
    {
        IsPlaying =false;
        if (TimeCheck.Instance != null)
        {
            TimeCheck.Instance.StopNumber();
        }

        // 게임 오버 UI 호출
        GameOverUI.Instance.Show();
    }

    public float SongTime
    {
        get
        {
            if(useAudioTime && audioSource != null)
                 return audioSource.time;

            return Time.time - startTime;
        }
    }
}
