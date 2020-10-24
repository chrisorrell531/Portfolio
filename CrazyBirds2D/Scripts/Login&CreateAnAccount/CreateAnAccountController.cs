using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;
using UnityEngine.SceneManagement;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class CreateAnAccountController : MonoBehaviour
{
    [SerializeField] private InputField emailInput;
    [SerializeField] private InputField passwordInput;
    [SerializeField] private InputField mobileInput;
    [SerializeField] private Button SignUpButton;
    [SerializeField] private Button LoginButton;
    [SerializeField] private Button FacebookSignUpButton;

    [SerializeField, HideInInspector] private bool CanSignUp = false;

    // Start is called before the first frame update
    void Start()
    {
        SignUpButton.onClick.AddListener(SignUpButtonClicked);
        LoginButton.onClick.AddListener(OpenLoginScene);
        //FacebookSignUpButton.onClick.AddListener(FacebookSignUpButtonClicked);
    }

    void OpenLoginScene()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(emailInput.text != null && passwordInput.text != null && CanSignUp == false)
        {
            CanSignUp = true;
            SignUpButton.enabled = true;
        }
    }

    void SignUpButtonClicked()
    {
        FirebaseAuth.DefaultInstance.CreateUserWithEmailAndPasswordAsync(emailInput.text, passwordInput.text).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }
            // Firebase user has been created.
            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
            newUser.DisplayName, newUser.UserId);
            newUser.SendEmailVerificationAsync().ContinueWith(t => {
            Debug.LogFormat("SendEmailVerificationAsync Success");
            WriteNewUserToDataBase(newUser.UserId, newUser.Email);
            });
        });
        SceneManager.LoadScene(0);
    }

    private void WriteNewUserToDataBase(string userID, string Email)
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://crazybird-2d.firebaseio.com/");
        // Get the root reference location of the database.
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
        string key = reference.Child("PlayerInfo").Push().Key;
        User user = new User(userID, Email);
        string json = JsonUtility.ToJson(user);
        reference.Child("users").Child(userID).Child("PlayerInfo").SetRawJsonValueAsync(json);
        PlayerStats _stats = new PlayerStats();
        _stats.CallSetDefualtScoresAndLevels();
        string _PlayerLeveljson = JsonUtility.ToJson(_stats);
        reference.Child("users").Child(userID).Child("PlayerStats").SetRawJsonValueAsync(_PlayerLeveljson);
    }

    void FacebookSignUpButtonClicked()
    {
       // Firebase.Auth.Credential credential =
       // Firebase.Auth.FacebookAuthProvider.GetCredential(accessToken);
        //auth.SignInWithCredentialAsync(credential).ContinueWith(task => {
          //  if (task.IsCanceled)
            //{
              //  Debug.LogError("SignInWithCredentialAsync was canceled.");
                //return;
           // }
           // if (task.IsFaulted)
           // {
             //   Debug.LogError("SignInWithCredentialAsync encountered an error: " + task.Exception);
              //  return;
            //}

           // Firebase.Auth.FirebaseUser newUser = task.Result;
            //Debug.LogFormat("User signed in successfully: {0} ({1})",
             //   newUser.DisplayName, newUser.UserId);
        //});
    }
}
