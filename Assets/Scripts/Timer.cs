using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text timer;
    private float time;

    private void Update()
    {
        timer.text = $"{Mathf.Floor(time / 60):0}:{time % 60:00}";
        time += Time.deltaTime;
    }
}