using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private FadeTransition fadeTransition;
    public static bool isPaused;
    public static bool returnToMainMenu;
    [SerializeField] private GameObject buttonPaused;

    private void Awake()
    {
        returnToMainMenu = false;
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
        buttonPaused.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }
    
    public void GameResume()
    {
        buttonPaused.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    public void LoadMainMenu()
    {
        fadeTransition.ThrowFade();
        returnToMainMenu = true;
        GameResume();
        SceneManager.LoadScene("1_Start");
    }
}