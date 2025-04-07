using UnityEngine;
using UnityEngine.EventSystems;

public class RotatingTile : MonoBehaviour, IPointerClickHandler
{
    public int rotationStep = 90;
    public int correctRotation = 0;
    public int currentRotation = 0;

    public PuzzleManager manager;

    public void OnPointerClick(PointerEventData eventData)
    {
        RotateTile();
    }

    void RotateTile()
    {
        currentRotation = (currentRotation - rotationStep + 360) % 360;
        transform.rotation = Quaternion.Euler(0, 0, currentRotation);
        manager.CheckIfSolved();
    }

    public bool IsCorrect()
    {
        return currentRotation == correctRotation;
    }
}
