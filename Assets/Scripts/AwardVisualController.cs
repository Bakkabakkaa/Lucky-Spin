using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AwardVisualController : MonoBehaviour
{
    private static readonly int Show = Animator.StringToHash("show");
    private static readonly int ShowScull = Animator.StringToHash("showScull");
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _amountText;
    [SerializeField] private TextMeshProUGUI _value; 
    [SerializeField] private Animator _animator;
    [SerializeField] private ChestVisual _chestVisual;
    [SerializeField] private SoundsManager _soundsManager;

    public event Action OnCardAnimationFinished; 
     

    public void ShowAward(Sprite awardSprite, string text, string value)
    {
        _icon.sprite = awardSprite;
        _amountText.text = text;
        _value.text = value;

        if (text != "Oh NO...")
        {
            _animator.SetTrigger(Show);
            _soundsManager.PlayAward();
        }
        else
        {
            _animator.SetTrigger(ShowScull);
            _soundsManager.PlayScull();
        }
        
    }
    
    public void OnCardReachedChest()
    {
        _chestVisual.PulseChest();
        OnCardAnimationFinished?.Invoke();
    }
}