using System.Collections.Generic;
using UnityEngine;

public class ClueManager : MonoBehaviour
{
    public static ClueManager _clueManager;
    public static List<string> clueList = new();
    private void Awake()
    {
        if (_clueManager != null && _clueManager != this)
        {
            Destroy(gameObject);
            return;
        }
        _clueManager = this;
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        if(clueList.Count != 0)
        {
            foreach (string clue in clueList)
            {
                GameObject _clue = GameObject.Find(clue);
                if(_clue != null) _clue.SetActive(false);
            }
        }
    }
}