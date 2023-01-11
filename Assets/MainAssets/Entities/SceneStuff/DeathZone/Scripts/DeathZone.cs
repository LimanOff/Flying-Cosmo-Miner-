using System;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public int HowMuchPlayerDie = 0;

    public static Action OnPlayerDie;

    private void OnDisable()
    {
        HowMuchPlayerDie = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            HowMuchPlayerDie++;
            OnPlayerDie?.Invoke();
        }
    }
}
