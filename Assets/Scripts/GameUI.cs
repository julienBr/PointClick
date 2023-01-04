using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TMP_Text timer;
    [SerializeField] private TMP_Text cluesFoundText;
    [SerializeField] private Image clue1;
    [SerializeField] private Image clue2;
    [SerializeField] private Image clue3;
    [SerializeField] private Image clue4;
    [SerializeField] private Image clue5;
    [SerializeField] private Image clue6;
    [SerializeField] private Image clue7;

    private void Update()
    {
        UpdateClues();
        timer.text = $"{Mathf.Floor(Timer.time / 60):0}:{Timer.time % 60:00}";
        if (PauseMenu.returnToMainMenu) PlayerController.cluesFound = 0;
    }

    private void UpdateClues()
    {
        cluesFoundText.text = "Clues Found : " + PlayerController.cluesFound + " / 7";
    }
}