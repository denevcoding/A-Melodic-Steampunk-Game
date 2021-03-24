using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TickClock : MyGenericSingleton<TickClock>
{

    [SerializeField]
    private float tickPerSecond;
    private bool clockRunning;
    public event Action timerEvents;


    private void Awake()
    {
        StartClock();
    }//closes Awake method

    public void StartClock()
    {
        StartCoroutine(RunClock());
    }//closes StartClock method

    public void PauseClock()
    {
        clockRunning = false;
    }//closes PauseClock method

    private IEnumerator RunClock()
    {
        clockRunning = true;

        while (clockRunning)
        {
            yield return new WaitForSecondsRealtime(1 / tickPerSecond);
            timerEvents?.Invoke();
        }

        yield return null;
    }//closes ClockRunning method










}//close TickClock class
