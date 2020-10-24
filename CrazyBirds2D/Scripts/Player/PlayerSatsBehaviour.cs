using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSatsBehaviour : MonoBehaviour
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

    [SerializeField, HideInInspector] private ShopController _shop;
    [SerializeField, HideInInspector] private PlayerController _controller;
    //Called before the Start frame
    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    /**
     * So becuase our script uses DontDestroyOnLoad function this stops our object being deleted when a new scene opens. 
     * This is great for moving player data across scenes such as stats.
     * And becuase our object is only created once on scene 0 we have the issue of a when a new scene loads the object would normally be created
     * Awake and Start would be recalled. You can see the critical errors already right, DontDestroyOnLoad would run every time a new scene loaded meaning wed have loads
     * of duplicates to stop this the object isnt deleted and Awake only runs at the very point that the object is insantied at the start, so we use OnLevelWasLoaded Method as 
     * the awake function of this script
     * */

    void OnSceneLoaded()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        if(scene != 0)
        {
            _shop = GameObject.Find("PlayerShop").GetComponent<ShopController>();
        }
        AssignLevels();
    }

    void Start()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        if (scene == 3)
        {
            if (SpeedLevel > 1 && SpeedLevel < 26)
            {
                if (_controller == null)
                {
                    _controller = GetComponent<PlayerController>();
                }
                _controller.JumpHeight = _controller.JumpHeight + SpeedLevel;
            }
        }
    }

    void AssignLevels()
    {
        _shop.SpeedLevel = SpeedLevel;
        _shop.SpeedCost = 50;
        _shop.DamageLevel = DamageLevel;
        _shop.HealthLevel = HealthLevel;
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
