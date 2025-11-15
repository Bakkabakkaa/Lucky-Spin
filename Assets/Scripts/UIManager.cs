using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _tokenValue;
    [SerializeField] private WheelSpinner _wheelSpinner;
    [SerializeField] private ChestManager _chestManager;
    [SerializeField] private TextMeshProUGUI _coinsText;
    [SerializeField] private TextMeshProUGUI _gemsText;
    [SerializeField] private SpinButtonView _spinButtonView;
    
    public int TokensCount { get; private set; } = 3;

    private void OnEnable()
    {
        _wheelSpinner.OnSpinStart += ChangeTokenValue;
    }

    private void OnDisable()
    {
        _wheelSpinner.OnSpinStart -= ChangeTokenValue;
    }

    private void ChangeTokenValue()
    {
        TokensCount -= 1;
        _tokenValue.text = TokensCount.ToString();

        if (TokensCount <= 0)
        {
            _spinButtonView.SetInteractable(false);
        }
    }

    public void ChangeUI()
    {
        _coinsText.text = (100 + _chestManager.CoinsValue).ToString();
        _gemsText.text = (5 + _chestManager.GemsValue).ToString();
    }
    
    
}