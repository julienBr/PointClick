using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    private static GameUI _gameUI;
    [SerializeField] private TMP_Text cluesFoundText;
    
    /*private void Awake()
    {
        if (_gameUI != null && _gameUI != this)
        {
            Destroy(gameObject);
            return;
        }
        _gameUI = this;
        DontDestroyOnLoad(this);
    }*/

    private void Update()
    {
        UpdateClues();
    }

    private void UpdateClues()
    {
        if (PauseMenu.returnToMainMenu) PlayerController.cluesFound = 0;
        cluesFoundText.text = "Clues Found : " + PlayerController.cluesFound + " / 7";
    }
}