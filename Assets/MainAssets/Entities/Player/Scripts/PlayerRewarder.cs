using YG;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerRewarder : MonoBehaviour
{
    private Vector3 _currentPos;
    private Rigidbody2D _rb;

    private void Start()
    {
        _currentPos = transform.position;
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        YandexGame.OpenVideoEvent += ResetPosition;
    }

    private void OnDisable()
    {
        YandexGame.OpenVideoEvent -= ResetPosition;
    }

    private void ResetPosition()
    {
        _rb.isKinematic = true;
        _rb.simulated = false;

        transform.position = _currentPos;
    }
}
