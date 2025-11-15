using System;
using UnityEngine;

public class ChestVisual : MonoBehaviour
{
    private static readonly int Pulse = Animator.StringToHash("pulse");
    
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private AwardVisualController _awardVisualController;

    private FinalAnimation _finalAnimation;
    private Animator _chestAnimator;
    
    private void Awake()
    {
        _finalAnimation = GetComponent<FinalAnimation>();
        _chestAnimator = GetComponent<Animator>();
    }
    
    private void OnEnable()
    {
        _awardVisualController.OnCardAnimationFinished += ShowFinalAnimation;
    }

    private void OnDisable()
    {
        _awardVisualController.OnCardAnimationFinished -= ShowFinalAnimation;
    }

    public void PulseChest()
    {
        _chestAnimator.SetTrigger(Pulse);
    }

    public void ShowFinalAnimation()
    {
        if (_uiManager.TokensCount == 0)
        {
            _finalAnimation.Show();
        }
    }
}