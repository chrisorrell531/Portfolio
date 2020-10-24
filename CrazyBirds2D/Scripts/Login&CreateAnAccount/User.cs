using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User
{
    [SerializeField] public string _userID;
    [SerializeField] public string email;

    public User()
    {
    }

    public User(string userID, string Email)
    {
       this._userID = userID;
       this.email = Email;
    }
 }
