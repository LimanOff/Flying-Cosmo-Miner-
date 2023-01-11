using YG;
using System;
using UnityEngine;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{
    public static Action OnWaitButtonClick;
    public static Action OnJumpButtonClick;

    public static Action OnJustRespawnButtonClick;
    public static Action OnRewardRespawnButtonClick;

    [Header("Buttons")]
    [SerializeField] private Button _waitButton;
    [SerializeField] private Button _jumpButton;
    [Space(50f)]
    [SerializeField] private Button _justRespawnButton;
    [SerializeField] private Button _rewardRespawnButton;

    [Header("Panels")]
    [SerializeField] private GameObject _gamePanel;
    [SerializeField] private GameObject _waitPanel;
    [SerializeField] private GameObject _diePanel;

    private void Awake()
    {
        OpenWaitPanel();
    }

    private void OnEnable()
    {
        _jumpButton.AddListener(delegate { ExecuteDelegate(OnJumpButtonClick); });
        _waitButton.AddListener(delegate { ExecuteDelegate(OnWaitButtonClick); });

        _justRespawnButton.AddListener(delegate { ExecuteDelegate(OnJustRespawnButtonClick); });
        _rewardRespawnButton.AddListener(delegate { ExecuteDelegate(OnRewardRespawnButtonClick); });

        _waitButton.AddListener(CloseWaitPanel);

        YandexGame.CloseVideoEvent += ShowAd;

        DeathZone.OnPlayerDie += OpenDiePanel;
    }

    private void OnDisable()
    {
        _jumpButton.RemoveListener(delegate {ExecuteDelegate(OnJumpButtonClick); });
        _waitButton.RemoveListener(delegate { ExecuteDelegate(OnWaitButtonClick); });

        _justRespawnButton.RemoveListener(delegate { ExecuteDelegate(OnJustRespawnButtonClick); });
        _rewardRespawnButton.RemoveListener(delegate { ExecuteDelegate(OnRewardRespawnButtonClick); });

        _waitButton.RemoveListener(CloseWaitPanel);

        YandexGame.CloseVideoEvent -= ShowAd;

        DeathZone.OnPlayerDie -= OpenDiePanel;
    }


    private void ExecuteDelegate(Action action)
    {
        action?.Invoke();
    }

    private void OpenDiePanel()
    {
        _diePanel.Activate();
        _gamePanel.Deactivate();
        _waitPanel.Deactivate();

        Time.timeScale = 0;
    }

    private void CloseDiePanel()
    {
        _gamePanel.Activate();
        _diePanel.Deactivate();
        _waitPanel.Deactivate();

        Time.timeScale = 1;
    }

    private void CloseWaitPanel()
    {
        _gamePanel.Activate();
        _diePanel.Deactivate();
        _waitPanel.Deactivate();

        Time.timeScale = 1;
    }

    private void OpenWaitPanel()
    {
        _waitPanel.Activate();
        _gamePanel.Deactivate();
        _diePanel.Deactivate();

        Time.timeScale = 1;
    }

    private void ShowAd()
    {
        CloseDiePanel();
        OpenWaitPanel();
    }
}
