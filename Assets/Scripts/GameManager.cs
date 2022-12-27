using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance { private set; get; }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void ChangeScene(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);
        StartCoroutine(SetActive(_sceneName));
    }

    private IEnumerator SetActive(string _sceneName)
    {
        yield return null;
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(_sceneName));
    }
    
    public void Restart()
    {
        
    }
    
    public void Quit()
    {
        Application.Quit();
    }
}