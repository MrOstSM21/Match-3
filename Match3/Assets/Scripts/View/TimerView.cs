using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;

public class TimerView : MonoBehaviour
{
    public event Action TimerOff;

    [SerializeField] private float time;
    [SerializeField] private Text timerText;

    private float _timeLeft = 0f;

    private void Start()
    {
        _timeLeft = time;
        StartCoroutine(StartTimer());
    }
    private IEnumerator StartTimer()
    {
        while (_timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime;
            UpdateTimeText();
            yield return null;
        }
        TimerOff?.Invoke();
    }

    private void UpdateTimeText()
    {
        if (_timeLeft < 0)
            _timeLeft = 0;

        float minutes = Mathf.FloorToInt(_timeLeft / 60);
        float seconds = Mathf.FloorToInt(_timeLeft % 60);
        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
