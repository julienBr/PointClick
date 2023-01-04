using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TMP_Text timer;
    [SerializeField] private TMP_Text cluesFoundText;
    [SerializeField] private GameObject winWindow;

    private void Update()
    {
        UpdateClues();
        timer.text = $"{Mathf.Floor(Timer.time / 60):0}:{Timer.time % 60:00}";
        if (PauseMenu.returnToMainMenu) PlayerController.cluesFound = 0;
    }

    private void UpdateClues()
    {
        cluesFoundText.text = "Clues Found : " + PlayerController.cluesFound + " / 7";
        if (PlayerController.cluesFound == 1)
        {
            Time.timeScale = 0;
            winWindow.SetActive(true);
        }
    }
}