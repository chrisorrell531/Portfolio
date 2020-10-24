using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using System;
using UnityEngine.SceneManagement;

[System.Serializable]
public class SaveLoadConnection : MonoBehaviour
{
    string _PlayerLeveljson = null;
    private PlayerSatsBehaviour _stats;
    bool loaded = false;

    void Awake()
    {
        if(_stats == null)
        {
            _stats = GameObject.Find("PlayerStatsBehaviour").GetComponent<PlayerSatsBehaviour>();
        }
    }

    public void CallWriteToDataBase(string userID, string Email)
    {
        LoadPlayerData(userID);
    }

    private void WriteNewUserToDataBase(string userID, string Email)
    {
        // Get the root reference location of the database.
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
        string key = reference.Child("PlayerInfo").Push().Key;
        User user = new User(userID, Email);
        string json = JsonUtility.ToJson(user);
        reference.Child("users").Child(userID).Child("PlayerInfo").SetRawJsonValueAsync(json);
        PlayerStats _stats = new PlayerStats();
        _stats.CallSetDefualtScoresAndLevels();
        _PlayerLeveljson = JsonUtility.ToJson(_stats);
        reference.Child("users").Child(userID).Child("PlayerStats").SetRawJsonValueAsync(_PlayerLeveljson);
    }

    public void loadData(string UserId)
    {
        CallLoadPlayerData(UserId);
    }

    private void CallLoadPlayerData(string UserId)
    {
        Debug.Log("Initiated");
        LoadPlayerData(UserId);
    }

    private void LoadPlayerData(string UserId)
    {
        DataSnapshot snapshot = null;
        string ConvertSnapShot = null;
        Debug.Log("LoadingPlayer");
        FirebaseAuth auth = FirebaseAuth.DefaultInstance;
        string uid = auth.CurrentUser.UserId;
        FirebaseDatabase.DefaultInstance.GetReferenceFromUrl("https://crazybird-2d.firebaseio.com/users/" + uid).Child("PlayerStats").GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                Debug.Log("User Not Found");
                // Handle the error...
            }
            if (task.IsCompleted)
            {
                snapshot = task.Result;
                ConvertSnapShot = snapshot.GetRawJsonValue();
                Debug.Log("snapshot Taken");
                PlayerStats s = JsonUtility.FromJson<PlayerStats>(ConvertSnapShot);
                _stats.Cash = s.Cash;
                _stats.Gems = s.Gems;
                _stats.PlayerLevel = s.PlayerLevel;
                _stats.AttackSpeedLevel = s.AttackSpeedLevel;
                _stats.SpeedLevel = s.SpeedLevel;
                Debug.Log("Cash = " + _stats.Cash);
                loaded = true;
            }
        });
      
    }

    void Update()
    {
        if(loaded == true)
        {
            Debug.Log("Loading Scene");
            SceneManager.LoadScene(2);
        }
    }
}
