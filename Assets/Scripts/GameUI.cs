using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    private static GameUI _gameUI;
    //[SerializeField] private PlayerController player;
    [SerializeField] private TMP_Text cluesFoundText;
    
    private void Awake()
    {
        if (!_gameUI)
        {
            _gameUI = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    private void Update()
    {
        UpdateClues();
    }

    private void UpdateClues()
    {
        cluesFoundText.text = "Clues Found : " + PlayerController.cluesFound + " / 7";
    }
}