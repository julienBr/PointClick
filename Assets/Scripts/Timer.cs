using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private static Timer _timer;
    [SerializeField] private TMP_Text timer;
    private float time;
    private float TimerInterval = 5f;
    private float tick;

    private void Awake()
    {
        //time = 0f;
        tick = TimerInterval;
    }

    private void Update()
    {
        timer.text = $"{Mathf.Floor(time / 60):0}:{time % 60:00}";
        time += Time.deltaTime;
        if (time == tick) tick = time + TimerInterval;
    }
}