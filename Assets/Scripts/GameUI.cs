using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TMP_Text timer;
    [SerializeField] private TMP_Text cluesFoundText;

    private void Update()
    {
        UpdateClues();
        timer.text = $"{Mathf.Floor(Timer.time / 60):0}:{Timer.time % 60:00}";
        if (PauseMenu.returnToMainMenu || PauseMenu.isRestart) PlayerController.cluesFound = 0;
    }

    private void UpdateClues()
    {
        cluesFoundText.text = "Clues Found : " + PlayerController.cluesFound + " / 7";
    }
}