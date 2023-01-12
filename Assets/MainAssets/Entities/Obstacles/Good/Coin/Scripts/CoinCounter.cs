using YG;
using System;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    [SerializeField] private Text _countOfCoinsText;
    public int CountOfCoins { get; private set; }

    private void Start()
    {
        CountOfCoins = YandexGame.savesData.Money;

        _countOfCoinsText.text = $"{CountOfCoins}";
    }

    private void OnEnable()
    {
        Coin.OnCoinTouch += AddCoins;
        InputHandler.OnMoneyRespawnButtonClick += SpendCoins;

        InputHandler.OnRewardRespawnButtonClick += SaveMoney;
        InputHandler.OnJustRespawnButtonClick += SaveMoney;
    }

    private void OnDisable()
    {
        Coin.OnCoinTouch -= AddCoins;
        InputHandler.OnMoneyRespawnButtonClick -= SpendCoins;

        InputHandler.OnRewardRespawnButtonClick -= SaveMoney;
        InputHandler.OnJustRespawnButtonClick -= SaveMoney;
    }

    private void AddCoins()
    {
        CountOfCoins++;
        _countOfCoinsText.text = $"{CountOfCoins}";
    }

    private void SpendCoins()
    {
        CountOfCoins -= 25;
        _countOfCoinsText.text = $"{CountOfCoins}";
    }

    private void SaveMoney()
    {
        YandexGame.savesData.Money = CountOfCoins;

        YandexGame.SaveProgress();
    }
}
