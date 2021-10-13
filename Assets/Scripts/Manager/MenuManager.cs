using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuManager : SingletonInstance<MenuManager>
{
    [Header("Options Menu.")]
    [SerializeField]
    private GameObject optionsMenu;

    [Header("Bars")]
    [SerializeField]
    private Scrollbar sensibilityBar;

    public float sensitivity;

    private void Start()
    {
        PlayerPrefs.DeleteAll();
        sensitivity = 300f;
    }

    public void PlayGame()
    {
        SceneLoader.GetInstance().LoadScene(GameData.LEVEL_1_SCENE_NAME);
        PlayerPrefs.SetFloat(GameData.MOUSE_SENSITIVITY, sensitivity);
    }

    public void OptionGame()
    {
        optionsMenu.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetSensetivity()
    {
        sensitivity = sensibilityBar.value * 600f;
        sensitivity = Mathf.Clamp(sensitivity, 100, 600);
    }
}