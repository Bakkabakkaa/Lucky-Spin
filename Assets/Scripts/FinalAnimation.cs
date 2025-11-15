using System;
using TMPro;
using UnityEngine;

public class FinalAnimation : MonoBehaviour
{
    [SerializeField] private ChestManager _chestManager;
    [SerializeField] private TextMeshProUGUI _coinsText;
    [SerializeField] private TextMeshProUGUI _gemsText;
    [SerializeField] private TextMeshProUGUI _rewardsText;
    [SerializeField] private TextMeshProUGUI _heartsText;
    
    private Animator _finalAnimator;
    
    private static readonly int ShowFinal = Animator.StringToHash("ShowFinal");

    private void Awake()
    {
        _finalAnimator = GetComponent<Animator>();
    }
    public void Show()
    {
        _finalAnimator.SetBool(ShowFinal, true);
        _coinsText.text = _chestManager.CoinsValue.ToString();
        _gemsText.text = _chestManager.GemsValue.ToString();
        _rewardsText.text = _chestManager.RewardsValue.ToString();
        _heartsText.text = _chestManager.HeartsValue.ToString();
    }
}