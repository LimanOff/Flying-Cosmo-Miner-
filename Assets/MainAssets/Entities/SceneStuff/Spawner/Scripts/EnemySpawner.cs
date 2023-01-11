using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private GameObject _parent;
    [SerializeField] private GameObject[] _spawnPoints;

    private void OnEnable()
    {
        InputHandler.OnWaitButtonClick += StartSpawning;
    }

    private void OnDisable()
    {
        InputHandler.OnWaitButtonClick -= StartSpawning;
        StopSpawning();
    }

    public void StartSpawning()
    {
        StartCoroutine(SpawnEnemies());
    }

    public void StopSpawning()
    {
        StopCoroutine(SpawnEnemies());
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
