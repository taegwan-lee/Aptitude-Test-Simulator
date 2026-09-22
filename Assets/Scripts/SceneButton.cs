using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void StartGameScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
