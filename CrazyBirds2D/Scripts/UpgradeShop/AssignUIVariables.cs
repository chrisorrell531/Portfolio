using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssignUIVariables : MonoBehaviour
{
    [SerializeField] private Text CashText;
    [SerializeField] private Text GemsText;
    [SerializeField] private Text PlayerLevelText;

    [SerializeField, HideInInspector] private PlayerSatsBehaviour stats;

    #region Error Check and Correction
    void Awake()
    {
        switch (CashText)
        {
            case Text A when CashText == null:
                CashText = GameObject.Find("TotalMoneyText").GetComponent<Text>();
                break;
        }
        switch (GemsText)
        {
            case Text A when GemsText == null:
                CashText = GameObject.Find("TotalGemsText").GetComponent<Text>();
                break;
        }
        switch (PlayerLevelText)
        {
            case Text A when PlayerLevelText == null:
                CashText = GameObject.Find("TotalLevelText").GetComponent<Text>();
                break;
        }
        switch (stats)
        {
            case PlayerSatsBehaviour a when stats == null:
                stats = GetComponent<PlayerSatsBehaviour>();
                break;
        }
    }
    #endregion

    #region Updates UI
    // Update is called once per frame 
    void Update()
    {
        if (stats == null)
        {
            stats = GameObject.Find("PlayerStatsBehaviour").GetComponent<PlayerSatsBehaviour>();
        }
        else
        {
            if (!CashText.text.Equals(stats.Cash.ToString("#00.00")))
            {
                CashText.text = stats.Cash.ToString("#00.00");
            }
            switch (GemsText.text)
            {
                case string A when GemsText.text != stats.Gems.ToString():
                    GemsText.text = stats.Gems.ToString("#00");
                    break;
            }
            switch (PlayerLevelText.text)
            {
                case string A when PlayerLevelText.text != stats.PlayerLevel.ToString():
                    PlayerLevelText.text = stats.PlayerLevel.ToString("#00");
                    break;
            }
        }
    }
    #endregion
}
