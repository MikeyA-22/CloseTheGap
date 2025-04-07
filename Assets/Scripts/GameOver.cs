using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level");
    }

    public void Hub()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Base Area");
    }
}
