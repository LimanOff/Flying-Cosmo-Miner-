using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private GameObject _parent;
    [SerializeField] private GameObject[] _spawnPoints;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        InputHandler.OnWaitButtonClick += StartSpawning;
        InputHandler.OnRewardRespawnButtonClick += StopSpawning;
    }

    private void OnDisable()
    {
        InputHandler.OnWaitButtonClick -= StartSpawning;
        InputHandler.OnRewardRespawnButtonClick -= StopSpawning;
    }

    public void StartSpawning()
    {
        _coroutine = StartCoroutine(SpawnEnemies());
    }

    public void StopSpawning()
    {
        StopCoroutine(_coroutine);
    }

    private IEnumerator SpawnEnemies()
    {
        while(true)
        {
            Instantiate(_prefab,CalculateSpawnPosition(),Quaternion.identity,_parent.transform);
            yield return new WaitForSeconds(1f);
        }
    }

    private Vector3 CalculateSpawnPosition()
    {
        int randomIndex = Random.Range(0,_spawnPoints.Length);
        Vector3 spawnPos = _spawnPoints[randomIndex].transform.position;
        return spawnPos;
    }
}
