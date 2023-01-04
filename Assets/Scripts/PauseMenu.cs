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

    private void Start()
    {
        Time.timeScale = 1;
        Debug.Log("TimeScale à 1");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && gameObject.scene.name != "1_Start")
        {
            if (isPaused) GameResume();
            else GamePaused();
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
        player._audioSource.Play();
        buttonPaused.SetActive(false);
        winWindow.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    public void Restart()
    {
        GameResume();
        fadeTransition.ThrowFade();
        isRestart = true;
        SceneManager.LoadScene("2_Top");
        Debug.Log("TimeScale : " + Time.timeScale);

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
        fadeTransition.ThrowFade();
        returnToMainMenu = true;
        GameResume();
        SceneManager.LoadScene("1_Start");
    }
}