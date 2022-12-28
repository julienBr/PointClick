using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] private FadeTransition fadeTransition;

    public void ChangeScene(string _sceneName)
    {
        StartCoroutine(LoadScene(_sceneName));
    }

    private IEnumerator LoadScene(string _sceneName)
    {
        fadeTransition.ThrowFade();
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(_sceneName);
    }
    
    public void Restart()
    {
        
    }
    
    public void Quit()
    {
        Application.Quit();
    }
}