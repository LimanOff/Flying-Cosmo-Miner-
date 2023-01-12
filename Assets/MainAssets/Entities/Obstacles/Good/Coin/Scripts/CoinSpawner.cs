using System.Collections;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private GameObject _parent;
    [SerializeField] private GameObject _coinSpawn;

    private Coroutine coroutine;

    private void OnEnable()
    {
        InputHandler.OnWaitButtonClick += StartSpawning;
        InputHandler.OnRewardRespawnButtonClick += StopSpawning;
        InputHandler.OnMoneyRespawnButtonClick += StopSpawning;
    }

    private void OnDisable()
    {
        InputHandler.OnWaitButtonClick -= StartSpawning;
        InputHandler.OnRewardRespawnButtonClick -= StopSpawning;
        InputHandler.OnMoneyRespawnButtonClick -= StopSpawning;
    }

    private void StartSpawning()
    {
        coroutine = StartCoroutine(SpawnCoins());
    }

    private void StopSpawning()
    {
        StopCoroutine(coroutine);
    }

    private IEnumerator SpawnCoins()
    {
        yield return new WaitForSeconds(10f);

        while (true)
        {
            Instantiate(_prefab, transform.position, Quaternion.identity, _parent.transform);
            yield return new WaitForSeconds(20f);
        }
    }
}
