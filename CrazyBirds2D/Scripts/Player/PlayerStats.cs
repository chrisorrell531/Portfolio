using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats
{
    [SerializeField] public int PlayerLevel;
    [SerializeField] public int Points;
    [SerializeField] public float Experience;
    [SerializeField] public float Cash;
    [SerializeField] public float Gems;
    [SerializeField] public int SpeedLevel, DamageLevel, HealthLevel, AttackSpeedLevel, IncreaseCoinIncomeLevel, ChanceOfIceBulletLevel, MultiShotLevel, InvincibilityLevel;
    [SerializeField] public int SecondLifeChanceLevel;
    [SerializeField] public bool Bird2Bought, Bird3Bought, Bird4Bought;
    [SerializeField] public float HighScore;

    [SerializeField] private PlayerSatsBehaviour stats;

    void Start()
    {
        stats = GameObject.Find("PlayerStatsBehaviour").GetComponent<PlayerSatsBehaviour>();
        if(stats != null)
        {
            stats.PlayerLevel = PlayerLevel;
            stats.Points = Points;
            stats.Experience = Experience;
            stats.Cash = Cash;
            stats.Gems = Gems;
            stats.SpeedLevel = SpeedLevel;
            stats.DamageLevel = DamageLevel;
            stats.HealthLevel = HealthLevel;
            stats.AttackSpeedLevel = AttackSpeedLevel;
            stats.IncreaseCoinIncomeLevel = IncreaseCoinIncomeLevel;
            stats.ChanceOfIceBulletLevel = ChanceOfIceBulletLevel;
            stats.MultiShotLevel = MultiShotLevel;
            stats.InvincibilityLevel = InvincibilityLevel;
            stats.SecondLifeChanceLevel = SecondLifeChanceLevel;
            stats.Bird2Bought = Bird2Bought;
            stats.Bird3Bought = Bird3Bought;
            stats.Bird4Bought = Bird4Bought;
            stats.HighScore = HighScore;
        }
    }

    public void CallSetDefualtScoresAndLevels()
    {
        SetDefualtScoresAndLevels();
    }

    private void SetDefualtScoresAndLevels()
    {
        PlayerLevel = 1;
        Experience = 0.00f;
        Cash = 100.00f;
        Gems = 30.0f;
        SpeedLevel = 1;
        DamageLevel = 1;
        HealthLevel = 1;
        AttackSpeedLevel = 1;
        IncreaseCoinIncomeLevel = 1;
        ChanceOfIceBulletLevel = 0;
        MultiShotLevel = 0;
        InvincibilityLevel = 0;
        SecondLifeChanceLevel = 0;
        Bird2Bought = false;
        Bird3Bought = false;
        Bird4Bought = false;
        HighScore = 0.00f;
    }

}
