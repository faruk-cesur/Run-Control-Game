using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDownController : MonoBehaviour
{
    [SerializeField] private CountDown _countDown;

    private void Start()
    {
        StartCoroutine(GameStartCoroutine());
        StartCoroutine(TimeFinishCoroutine());
    }

    private IEnumerator GameStartCoroutine()
    {
        yield return new WaitUntil(() => GameManager.Instance.CurrentGameState == GameState.Gameplay);
        _countDown.gameObject.SetActive(true);
    }

    private IEnumerator TimeFinishCoroutine()
    {
        yield return new WaitWhile(() => _countDown.IsTimeContinue());
        GameManager.Instance.Lose(0);
        _countDown.gameObject.SetActive(false);
    }
}