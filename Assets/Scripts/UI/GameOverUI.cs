using System.Collections;
using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    public static GameOverUI Instance { get; private set; }

    [Header("Refs")]
    public CanvasGroup blackOverlay;
    public CanvasGroup panelGroup;
    public TextMeshProUGUI detailText; 


    public float fadeDuration = 0.5f;
    public float panelPopDuration = 0.15f;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        // 시작 시에는 안 보이게
        blackOverlay.alpha = 0f;
        panelGroup.alpha = 0f;
        panelGroup.gameObject.SetActive(false);
    }

    public void Show()
    {
       
        if (detailText != null)
        {
            int missNote = ScoreSystem.Instance.lossingCount;
            int missTime =ScoreSystem.Instance.TimeInCorrect;

            detailText.text=
                $"노트를 놓친 횟수 : {missNote}\n" +
                $"시간을 잘못 누른 횟수 : {missTime}";
        }

        // 연출 시작
        StartCoroutine(ShowRoutine());
    }

    IEnumerator ShowRoutine()
    {
        // 1) 검은 화면 페이드 인
        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float lerp = t / fadeDuration;
            blackOverlay.alpha = Mathf.Lerp(0f, 0.9f, lerp);
            yield return null;
        }
        blackOverlay.alpha = 0.9f;

        // 2) 점수 패널 활성화 + 팝 애니메이션
        panelGroup.gameObject.SetActive(true);
        panelGroup.alpha = 1f;

        RectTransform rt = panelGroup.GetComponent<RectTransform>();
        Vector3 baseScale = Vector3.one;
        rt.localScale = baseScale * 0.7f; // 처음엔 작게 시작

        t = 0f;
        while (t < panelPopDuration)
        {
            t += Time.deltaTime;
            float lerp = t / panelPopDuration;
            // 약간 튀어나오는 느낌
            rt.localScale = Vector3.Lerp(baseScale * 0.7f, baseScale, lerp);
            yield return null;
        }
        rt.localScale = baseScale;

        // 여기서 버튼 눌러서 재시작 등 하면 됨
        panelGroup.interactable = true;
        panelGroup.blocksRaycasts = true;
    }
}