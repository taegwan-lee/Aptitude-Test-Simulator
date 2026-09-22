using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButton : MonoBehaviour
{
    public void StartGameScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("TitleScene");
    }

}
