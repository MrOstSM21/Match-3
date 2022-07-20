using System;
using UnityEngine;


public class TimeHandler
{
    public static event Action EndGame;

    public bool GameIsStop { get; private set; }

    private TimerView _timerView;
    public TimeHandler(TimerView timerView)
    {
        GameIsStop = false;
        _timerView = timerView;
        Subscribe();
        ChangeTimeScale(true);
    }
    private void Subscribe()
    {
        _timerView.TimerOff += _timerView_TimerOff;
    }
    private void Unsubscribe()
    {
        _timerView.TimerOff -= _timerView_TimerOff;
    }

    private void _timerView_TimerOff()
    {
        EndGame?.Invoke();
        ChangeTimeScale(false);
        GameIsStop = true;
        Unsubscribe();
    }
    private void ChangeTimeScale(bool timeState)
    {
        if (timeState)
            Time.timeScale = 1;
        else
            Time.timeScale = 0;
    }
}
