using System;
using UnityEngine;

public class AwardsManager : MonoBehaviour
{
    [SerializeField] private AwardVisualController _awardVisualController;
    [SerializeField] private Sprite _coinSprite;
    [SerializeField] private Sprite _skullSprite;
    [SerializeField] private Sprite _gemSprite;
    [SerializeField] private Sprite _rewardSprite;
    [SerializeField] private Sprite _heartSprite;
    public AwardType CurrentAward { get; private set; }
    public event Action<AwardType> OnAwardChecked;
    
    private WheelSpinner _wheelSpinner;

    private void Awake()
    {
        _wheelSpinner = GetComponent<WheelSpinner>();
    }

    private void OnEnable()
    {
        _wheelSpinner.OnSpinEnd += CheckAward;
    }

    private void OnDisable()
    {
        _wheelSpinner.OnSpinEnd -= CheckAward;
    }

    private void CheckAward()
    {
        float angle = _wheelSpinner.transform.eulerAngles.z;
        CurrentAward = GetAwardByAngle(angle);
        
        OnAwardChecked?.Invoke(CurrentAward);
        DisplayAward(CurrentAward);
    }

    public void DisplayAward(AwardType type)
    {
        switch (type)
        {
            case AwardType.Gold:
                _awardVisualController.ShowAward(_coinSprite, "Coins", "50");
                break;
            case AwardType.Gem:
                _awardVisualController.ShowAward(_gemSprite, "Gems", "2 ");
                break;
            case AwardType.Skull:
                _awardVisualController.ShowAward(_skullSprite, "Oh NO...", " ");
                break;
            case AwardType.Relic:
                _awardVisualController.ShowAward(_rewardSprite, "Mystery relic!", " ");
                break;
            case AwardType.Heart:
                _awardVisualController.ShowAward(_heartSprite, "Life!", " ");
                break;
        }
    }
    
    private AwardType GetAwardByAngle(float angle)
    {
        angle %= 360f;
        if (angle < 0)
            angle += 360f;

        if (angle >= 337.5f || angle <= 22.45f)
        {
            return AwardType.Gold;
        }
        else if (angle > 22.45f && angle <= 67.8f)
        {
            return AwardType.Gem;
        }
        else if (angle > 67.8f && angle <= 112.5f)
        {
            return AwardType.Skull;
        }
        else if (angle > 112.5f && angle <= 157.7f)
        {
            return AwardType.Heart;
        }
        else if (angle > 157.7f && angle <= 202.6f)
        {
            return AwardType.Gold;
        }
        else if (angle > 202.6f && angle <= 247.2f)
        {
            return AwardType.Gem;
        }
        else if (angle > 247.2f && angle <= 292.7f)
        {
            return AwardType.Relic;
        }
        else
        {
            return AwardType.Heart;
        }
    }
}