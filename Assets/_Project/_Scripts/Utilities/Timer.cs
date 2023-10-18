using System;
using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public event Action OnTimerEnded;
    public event Action OnTimerChanged;
    [field: SerializeField, BoxGroup("SETTINGS")] public string TimerName { get; private set; } = "Timer";
    [field: SerializeField, BoxGroup("SETTINGS")] public float TargetTime { get; private set; } = 5.0f;
    [field: SerializeField, BoxGroup("DEBUG"), ReadOnly] public float CurrentTime { get; private set; } = 0.0f;
    [field: SerializeField, BoxGroup("DEBUG"), ReadOnly] public bool IsTimerEnded { get; private set; } = false;
    private Coroutine _timerCoroutine;

    public void SetTimer(float targetTime)
    {
        TargetTime = targetTime;
    }

    public void StartTimer()
    {
        if (_timerCoroutine is not null)
        {
            StopCoroutine(_timerCoroutine);
        }

        _timerCoroutine = StartCoroutine(StartTimerCoroutine());
    }

    public void ResetCurrentTime()
    {
        CurrentTime = 0.0f;
        IsTimerEnded = false;
    }

    private IEnumerator StartTimerCoroutine()
    {
        ResetCurrentTime();

        while (CurrentTime < TargetTime)
        {
            if (TargetTime < 1.0f)
            {
                yield return new WaitForSeconds(TargetTime);
                CurrentTime += TargetTime;
            }
            else
            {
                yield return new WaitForSeconds(1.0f);
                CurrentTime += 1.0f;
            }

            OnTimerChanged?.Invoke();
        }

        IsTimerEnded = true;
        OnTimerEnded?.Invoke();
    }
}