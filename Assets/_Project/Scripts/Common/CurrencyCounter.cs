using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using VirtueSky.Events;
using VirtueSky.Variables;

public class CurrencyCounter : MonoBehaviour
{
    public TextMeshProUGUI CurrencyAmountText;
    public int StepCount = 10;
    public float DelayTime = .01f;
    public CurrencyGenerate CurrencyGenerate;
    [SerializeField] IntegerVariable currencyTotalVariable;
    [SerializeField] private EventNoParam eventCoinMove;

    private int currentCoin;

    private void Start()
    {
    }

    private void OnEnable()
    {
        CurrencyAmountText.text = currencyTotalVariable.Value.ToString();
        SaveCurrency();
    }

    private void SaveCurrency()
    {
        currentCoin = currencyTotalVariable.Value;
    }

    public void UpdateCurrencyAmountText()
    {
        if (currencyTotalVariable.Value > currentCoin)
        {
            IncreaseCurrency();
        }
        else
        {
            DecreaseCurrency();
        }
    }

    private void IncreaseCurrency()
    {
        bool isFirstMove = false;
        CurrencyGenerate.GenerateCoin(() =>
        {
            if (!isFirstMove)
            {
                isFirstMove = true;
                int currentCurrencyAmount = int.Parse(CurrencyAmountText.text);
                int nextAmount = (currencyTotalVariable.Value - currentCurrencyAmount) / StepCount;
                int step = StepCount;
                CurrencyTextCount(currentCurrencyAmount, nextAmount, step);
            }
        }, () => { eventCoinMove.Raise(); });
    }

    private void DecreaseCurrency()
    {
        int currentCurrencyAmount = int.Parse(CurrencyAmountText.text);
        int nextAmount = (currencyTotalVariable.Value - currentCurrencyAmount) / StepCount;
        int step = StepCount;
        CurrencyTextCount(currentCurrencyAmount, nextAmount, step);
    }

    private void CurrencyTextCount(int currentCurrencyValue, int nextAmountValue, int stepCount)
    {
        if (stepCount == 0)
        {
            CurrencyAmountText.text = currencyTotalVariable.Value.ToString();
            return;
        }

        int totalValue = (currentCurrencyValue + nextAmountValue);
        DOTween.Sequence().AppendInterval(DelayTime).SetUpdate(isIndependentUpdate: true).AppendCallback(() =>
            {
                CurrencyAmountText.text = totalValue.ToString();
            })
            .AppendCallback(() => { CurrencyTextCount(totalValue, nextAmountValue, stepCount - 1); });
    }
}