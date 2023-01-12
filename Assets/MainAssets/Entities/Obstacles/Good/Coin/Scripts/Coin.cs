using YG;
using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static Action OnCoinTouch;

    [Range(10f, 40f)]
    public float Speed;

    private void OnEnable()
    {
        YandexGame.OpenVideoEvent += DestroyCoin;
        InputHandler.OnMoneyRespawnButtonClick += DestroyCoin;
    }

    private void OnDisable()
    {
        YandexGame.OpenVideoEvent -= DestroyCoin;
        InputHandler.OnMoneyRespawnButtonClick -= DestroyCoin;
    }

    private void Update()
    {
        transform.MoveLeft(Speed);
    }

    private void DestroyCoin()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" )
        {
            OnCoinTouch?.Invoke();
            Destroy(gameObject);
        }
    }
}
