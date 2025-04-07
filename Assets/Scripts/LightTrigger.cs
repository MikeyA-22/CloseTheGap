using UnityEngine;

public class LightTrigger : MonoBehaviour
{
    public GameObject gameOverScreen;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player hit the light. Game Over.");

            Time.timeScale = 0f;
            gameOverScreen.SetActive(true);
        }
    }
}
