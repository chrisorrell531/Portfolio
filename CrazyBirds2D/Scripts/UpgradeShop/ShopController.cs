using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    #region Upgrades Levels And Cost Variables
    [SerializeField, HideInInspector] public int SpeedLevel;
    [SerializeField] public float SpeedCost = 50f;
    [SerializeField, HideInInspector] public int DamageLevel;
    [SerializeField] public float DamageCost = 75f;
    [SerializeField, HideInInspector] public int HealthLevel;
    [SerializeField] public float HealthCost = 100f;
    [SerializeField, HideInInspector] public int AttackSpeedLevel;
    [SerializeField] public float AttackSpeedCost = 125f;
    [SerializeField, HideInInspector] public int IncreaseCoinLevel;
    [SerializeField] public float IncreaseCoinCost = 150f;
    [SerializeField, HideInInspector] public int ChanceOfIceBulletLevel;
    [SerializeField] public float ChanceOfIceBulletCost = 175f;
    [SerializeField, HideInInspector] public int MultiShotLevel;
    [SerializeField] public float MultiShotCost = 250f;
    [SerializeField, HideInInspector] public int InvincibilityLevel;
    [SerializeField] public float InvincibilityCost = 300f;
    [SerializeField, HideInInspector] public int SecondlifeChanceLevel;
    [SerializeField] public float SecondlifeChanceCost = 300f;
    [SerializeField, HideInInspector] public bool Bird2Bought;
    [SerializeField] public bool Bird3Bought;
    [SerializeField, HideInInspector] public bool Bird4Bought;
    #endregion
    #region UI Text boxes
    [SerializeField] private Text SpeedLevelText;
    [SerializeField] private Text SpeedCostText;
    [SerializeField] private Text DamageLevelText;
    [SerializeField] private Text DamageCostText;
    [SerializeField] private Text HealthLevelText;
    [SerializeField] private Text HealthCostText;
    [SerializeField] private Text AttackSpeedLevelText;
    [SerializeField] private Text AttackSpeedCostText;
    [SerializeField] private Text IncreaseCoinLevelText;
    [SerializeField] private Text IncreaseCoinCostText;
    [SerializeField] private Text ChanceOfIceBulletLevelText;
    [SerializeField] private Text ChanceOfIceBulletCostText;
    [SerializeField] private Text MultiShotLevelText;
    [SerializeField] private Text MultiShotCostText;
    [SerializeField] private Text InvincibilityLevelText;
    [SerializeField] private Text InvincibilityCostText;
    [SerializeField] private Text SecondlifeChanceLevelText;
    [SerializeField] private Text SecondlifeChanceCostText;
    #endregion

    [SerializeField, HideInInspector] private PlayerSatsBehaviour stats;

    void Awake()
    {
        if(stats == null)
        {
            stats = GameObject.Find("PlayerStatsBehaviour").GetComponent<PlayerSatsBehaviour>();
        }
        AssignShopCosts();
    }

    void Start()
    {
        AssignShopCosts();
    }

    private void AssignShopCosts()
    {
        SpeedLevel = stats.SpeedLevel;
        SpeedCost = SpeedCost * SpeedLevel * 1.2f; 
        AssignUI();
    }

    private void AssignUI()
    {
        SpeedLevelText.text = SpeedLevel.ToString("#00");
        SpeedCostText.text =  SpeedCost.ToString("#0.00");
    }

    public void SpeedUpgradeClicked()
    {
        if(SpeedCost <= stats.Cash)
        {
            stats.SpeedLevel += 1;
            Debug.Log("Speed Upgraded");
        }
        AssignShopCosts();
    }
}
