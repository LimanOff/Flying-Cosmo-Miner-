using YG;
using UnityEngine;
using System.Collections;

public class DistanceCounter : MonoBehaviour
{
    public int Distance { get; private set; }

    private Coroutine _coroutine;

    private void Start()
    {
        Distance = 0;
    }

    private void OnEnable()
    {
        InputHandler.OnWaitButtonClick += StartCount;
        InputHandler.OnRewardRespawnButtonClick += StopCount;
        InputHandler.OnMoneyRespawnButtonClick += StopCount;
    }

    private void OnDisable()
    {
        InputHandler.OnWaitButtonClick -= StartCount;
        InputHandler.OnRewardRespawnButtonClick -= StopCount;
        InputHandler.OnMoneyRespawnButtonClick -= StopCount;
    }

    private void StartCount()
    {
         _coroutine = StartCoroutine(Count());
    }
    private void StopCount()
    {
        StopCoroutine(_coroutine);
    }

    private IEnumerator Count()
    {
        while (true)
        {
            Distance++;
            yield return new WaitForSeconds(1f);
        }
    }
}
