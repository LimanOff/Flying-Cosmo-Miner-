using System;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public static int HowMuchPlayerDie;

    public static Action OnPlayerDie;

    private void OnEnable()
    {
        InputHandler.OnJustRespawnButtonClick += ResetPlayerDie;
    }

    private void OnDisable()
    {
        InputHandler.OnJustRespawnButtonClick -= ResetPlayerDie;
    }

    private void ResetPlayerDie()
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
