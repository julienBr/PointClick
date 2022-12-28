using UnityEngine;

public class Music : MonoBehaviour
{
    private static Music _music;

    private void Awake()
    {
        if (_music != null && _music != this)
        {
            Destroy(gameObject);
            return;
        }
        _music = this;
        DontDestroyOnLoad(this);
    }
}