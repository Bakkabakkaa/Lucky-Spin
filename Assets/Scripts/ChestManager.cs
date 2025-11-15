using System;
using UnityEngine;

public class ChestManager : MonoBehaviour
{
    [SerializeField] private AwardsManager _awardsManager;

    public int CoinsValue { get; private set; }
    public int GemsValue { get; private set; }
    public int HeartsValue { get; private set; }
    public int RewardsValue { get; private set; }

    private void OnEnable()
    {
        _awardsManager.OnAwardChecked += UpdateChest;
    }

    private void OnDisable()
    {
        _awardsManager.OnAwardChecked -= UpdateChest;
    }

    private void UpdateChest(AwardType currentAward)
    {
        if (currentAward == AwardType.Gold)
        {
            CoinsValue += 50;
        }
        else if (currentAward == AwardType.Gem)
        {
            GemsValue += 2;
        }
        else if (currentAward == AwardType.Heart)
        {
            HeartsValue += 1;
        }
        else if (currentAward == AwardType.Relic)
        {
            RewardsValue += 1;
        }
    }
}
