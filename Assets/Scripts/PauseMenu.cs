using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private FadeTransition fadeTransition;
    public static bool isPaused;
    public static bool returnToMainMenu;
    public static bool isRestart;
    [SerializeField] private GameObject buttonPaused;
    [SerializeField] private GameObject settingsWindow;
    [SerializeField] private GameObject winWindow;
    [SerializeField] private PlayerController player;

    private void Awake()
    {
        returnToMainMenu = false;
        isRestart = false;
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && gameObject.scene.name != "1_Start")
        {
            if (isPaused) GameResume();
            else GamePaused();
        }
        if (PlayerController.cluesFound == 7)
        {
            winWindow.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void GamePaused()
    {
        settingsWindow.SetActive(false);
        player._audioSource.Stop();
        buttonPaused.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }
    
    public void GameResume()
    {
        Time.timeScale = 1;
        player._audioSource.Play();
        buttonPaused.SetActive(false);
        winWindow.SetActive(false);
        isPaused = false;
    }

    public void Restart()
    {
        GameResume();
        StartCoroutine(FadeRestart());
    }

    private IEnumerator FadeRestart()
    {
        fadeTransition.ThrowFade();
        isRestart = true;
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("2_Top");
    }
    
    public void OpenSettingsWindow()
    {
        settingsWindow.SetActive(true);
    }
    
    public void CloseSettingsWindow()
    {
        settingsWindow.SetActive(false);
    }
    
    public void LoadMainMenu()
    {
        GameResume();
        StartCoroutine(MainMenu());
    }

    private IEnumerator MainMenu()
    {
        fadeTransition.ThrowFade();
        returnToMainMenu = true;
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("1_Start");
    }
}