using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuController : MonoBehaviour
{
    [SerializeField] private Button PlayButton;
    [SerializeField] private Button OptionsButton;
    [SerializeField] private Button ExitButton;

    // Start is called before the first frame update
    void Start()
    {
        PlayButton.onClick.AddListener(PlayButtonClick);
        OptionsButton.onClick.AddListener(OptionsButtonClick);
        ExitButton.onClick.AddListener(ExitButtonClick);
    }

    void PlayButtonClick()
    {
        SceneManager.LoadScene(3);
    }

    void OptionsButtonClick()
    {

    }

    void ExitButtonClick()
    {
        Application.Quit();
    }
}
