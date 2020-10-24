using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Firebase.Auth;

public class LoginController : MonoBehaviour
{ 
    [SerializeField] private InputField EmailAddress, Password;
    [SerializeField] private Button LoginButton, SignUpButton, ResetPassword;
    [SerializeField] private SaveLoadConnection _Bridge;

    bool CanLogin = false;
    bool bothFieldsHaveInputs = false;

    [SerializeField] public FirebaseUser user;

    void Awake()
    {
        SignUpButton.onClick.AddListener(OpenSignUpScene);
        ResetPassword.onClick.AddListener(ResetPasswordClicked);
    }

    void ResetPasswordClicked()
    {
        FirebaseAuth auth = FirebaseAuth.DefaultInstance;
        FirebaseUser user = auth.CurrentUser;
        if (user != null)
        {
            if (EmailAddress.text != null)
            {
                auth.SendPasswordResetEmailAsync(EmailAddress.text).ContinueWith(task =>
                {
                    if (task.IsCanceled)
                    {
                        Debug.LogError("SendPasswordResetEmailAsync was canceled.");
                        return;
                    }
                    if (task.IsFaulted)
                    {
                        Debug.LogError("SendPasswordResetEmailAsync encountered an error: " + task.Exception);
                        return;
                    }

                    Debug.Log("Password reset email sent successfully.");
                });
            }
            else
            {
                Debug.Log("Email Address is Empty Please fill so we can send password reset link");
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(EmailAddress.text != null && Password.text != null && bothFieldsHaveInputs == false)
        {
            bothFieldsHaveInputs = true;
            CanLogin = true;
            AddListnerToLoginButton();
        }
        else if (EmailAddress.text == null && Password.text == null)
        {
            bothFieldsHaveInputs = false;
            CanLogin = false;
        }
    }

    void AddListnerToLoginButton()
    {
        if (CanLogin == true)
        {
            LoginButton.onClick.AddListener(LoginButtonClicked);
            LoginButton.enabled = true;
            LoginButton.interactable = true;
        }
    }

    void LoginButtonClicked()
    { 
        if(CanLogin == true)
        {
            FirebaseAuth.DefaultInstance.SignInWithEmailAndPasswordAsync(EmailAddress.text, Password.text).ContinueWith(task =>
            {
  
                if (task.IsCanceled)
                {
                    Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                    return;
                }
                if (task.IsFaulted)
                {
                    Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                    return;
                }
                Firebase.Auth.FirebaseUser newUser = task.Result;
                if (newUser.IsEmailVerified == false)
                {
                    Debug.Log("Please Verify Email Address");
                    newUser.SendEmailVerificationAsync().ContinueWith(t =>
                    {
                        Debug.LogFormat("SendEmailVerificationAsync Success");
                        newUser = null;
                    });
                    return;
                }
                if (newUser.IsEmailVerified)
                {
                    Debug.LogFormat("User signed in successfully: {0} ({1})",
                    newUser.DisplayName, newUser.UserId);
                    user = FirebaseAuth.DefaultInstance.CurrentUser;
                    _Bridge.loadData(newUser.UserId);
                }
            });
           
        }
    }

    void OpenSignUpScene()
    {
        SceneManager.LoadScene(1);
    }
}
