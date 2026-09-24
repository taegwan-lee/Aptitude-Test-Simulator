using UnityEngine;
using TMPro;


public class TImerUI : MonoBehaviour
{
   public TextMeshProUGUI remainTime;

   private void Update()
    {
        if(!GameManager.Instance.IsPlaying)
            return;

        float remain = GameManager.Instance.GameDuration - GameManager.Instance.SongTime;
        if (remain < 0 ) remain =0;

        remainTime.text = FormatTime(remain);
    }

    private string FormatTime(float t)
    {
        int sec = Mathf.CeilToInt(t);
        return $"남은시간 : {sec.ToString()}";
    }
}
