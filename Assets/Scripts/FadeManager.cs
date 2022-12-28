using UnityEngine;

public class FadeManager : MonoBehaviour
{
    private static FadeManager _fadeManager { set; get; }
    
    /*private void Awake()
    {
        if (_fadeManager != null)
        {
            Destroy(this);
            return;
        }
        _fadeManager = this;
        DontDestroyOnLoad(gameObject);
    }*/
}