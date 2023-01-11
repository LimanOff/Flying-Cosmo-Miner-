using YG;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Recorder : MonoBehaviour
{
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
        YandexGame.NewLeaderboardScores("HowMuchDistanceCompleted", 1);
    }

    private void ReloadLevel()
    {
        RecordToLeaderBoard();

        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
}
