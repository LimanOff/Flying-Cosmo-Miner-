using YG;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Recorder : MonoBehaviour
{
    [SerializeField] private DistanceCounter _distanceCounter;
    [SerializeField] private int _currentDistancePassed;

    private void OnEnable()
    {
        InputHandler.OnRewardRespawnButtonClick += ShowAd;
        InputHandler.OnJustRespawnButtonClick += ReloadLevel;
    }

    private void OnDisable()
    {
        InputHandler.OnRewardRespawnButtonClick -= ShowAd;
        InputHandler.OnJustRespawnButtonClick -= ReloadLevel;
    }

    private void ShowAd()
    {
        YandexGame.RewVideoShow(0);
    }

    private void RecordToLeaderBoard()
    {
        _currentDistancePassed = _distanceCounter.Distance;

        if (_currentDistancePassed > YandexGame.savesData.MaxDistance)
        {
            YandexGame.NewLeaderboardScores("HowMuchPassed", _currentDistancePassed);
            YandexGame.savesData.MaxDistance = _currentDistancePassed;
        }
    }

    private void ReloadLevel()
    {
        RecordToLeaderBoard();

        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
}
