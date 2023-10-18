using System.Collections;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    [HideInInspector] public float TotalTime;
    private float _currentTime;

    private void Start()
    {
        StartCoroutine(UpdateTime());
    }

    private IEnumerator UpdateTime()
    {
        yield return new WaitForSeconds(2f);
        _currentTime = TotalTime;
        while (IsTimeContinue())
        {
            DisplayTime();
            yield return new WaitForSeconds(1f);
            _currentTime--;
        }

        yield return null;
    }

    private void DisplayTime()
    {
        int minutes = Mathf.FloorToInt(_currentTime / 60.00f);
        int seconds = Mathf.FloorToInt(_currentTime - minutes * 60.00f);
        UIManager.Instance.CountDownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public bool IsTimeContinue()
    {
        return _currentTime >= 0;
    }
}