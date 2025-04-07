using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public RotatingTile[] tiles;

    public GameObject winScreen;

    public void CheckIfSolved()
    {
        foreach (RotatingTile tile in tiles)
        {
            if (!tile.IsCorrect())
                return;
        }

        Debug.Log("Puzzle Solved!");
        PuzzleSolved();
    }

    void PuzzleSolved()
    {
        Time.timeScale = 0f;
        winScreen.SetActive(true);
    }
}
