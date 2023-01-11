using UnityEngine;
using UnityEngine.UI;

public class DistanceOutputer : MonoBehaviour
{
    [SerializeField] private Text _distanceText;
    [SerializeField] private DistanceCounter _distanceCounter;

    private void Update()
    {
        _distanceText.text = $"{_distanceCounter.Distance}";
    }
}
