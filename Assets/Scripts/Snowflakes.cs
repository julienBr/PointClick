using UnityEngine;

public class Snowflakes : MonoBehaviour
{
    private static Snowflakes _snowFlakes;

    private void Awake()
    {
        if (_snowFlakes != null && _snowFlakes != this)
        {
            Destroy(gameObject);
            return;
        }
        _snowFlakes = this;
        DontDestroyOnLoad(this);
    }
    
    private void Update()
    {
        if (PauseMenu.returnToMainMenu || PauseMenu.isRestart) Destroy(gameObject);
    }
}