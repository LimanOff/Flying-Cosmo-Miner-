using YG;
using UnityEngine;

public class PlayerRewarder : MonoBehaviour
{
    private Vector3 _currentPos;

    private void Start()
    {
        _currentPos = transform.position;
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
        transform.position = _currentPos;
    }
}
