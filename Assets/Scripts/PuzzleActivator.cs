using UnityEngine;

public class PuzzleActivator : MonoBehaviour
{
    public GameObject puzzleUI; // Assign the puzzle canvas here
    private bool playerInRange = false;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            ActivatePuzzle();
        }
    }

    void ActivatePuzzle()
    {
        if (puzzleUI != null)
        {
            puzzleUI.SetActive(true);
            // Optional: Pause game or disable player movement
            Debug.Log("Puzzle activated!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Press E to hack");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
