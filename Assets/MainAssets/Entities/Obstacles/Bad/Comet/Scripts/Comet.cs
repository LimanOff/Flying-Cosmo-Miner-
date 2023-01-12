using YG;
using UnityEngine;

public class Comet : MonoBehaviour
{
    [Range(10f,40f)]
    public float Speed;

    private void OnEnable()
    {
        YandexGame.OpenVideoEvent += DestroyEnemy;
    }

    private void OnDisable()
    {
        YandexGame.OpenVideoEvent -= DestroyEnemy;
    }

    private void Update()
    {
        transform.MoveLeft(Speed);
    }

    private void DestroyEnemy()
    {
        Destroy(this.gameObject);
    }
}
