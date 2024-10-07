using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum Menu
{
    Main,
    Result,
    Gameplay,
    None
}

public class HudManager : MonoBehaviour
{
    public static HudManager Instance;

    [Header("Menus")]
    public GameObject mainMenu;
    public GameObject resultMenu;
    public GameObject gameplayMenu;

    [Header("Gameplay components")]
    public Button JumpBtn;
    public Image[] lives;
    public TextMeshProUGUI gameTime;

    [Header("Main Menu Components")]
    public Button playBtn;

    [Header("Result Menu Components")]
    public Button returnBtn;
    public Image winImage;
    public Image loseImage;
    public TextMeshProUGUI endTime;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        
    }

    public void DropLife()
    {
        for (int i = lives.Length - 1; i >= 0; i--)
        {
            if (lives[i].enabled)
            {
                lives[i].enabled = false;
                break;
            }
        }
    }

    public void GainLife(int amount)
    {
        int liveGiven = 0;
        
        foreach (Image live in lives)
        {
            if (!live.IsActive())
            {
                live.enabled = true;
                liveGiven++;
                if(liveGiven == amount)
                {
                    break;
                }
            }
        }
    }

    public void SetMenu(Menu menu)
    {
        mainMenu.SetActive(false);
        resultMenu.SetActive(false);
        gameplayMenu.SetActive(false);

        switch (menu)
        {
            case Menu.None:
                break;
            case Menu.Result:
                resultMenu.SetActive(true);
                break;
            case Menu.Main:
                mainMenu.SetActive(true);
                break;
            case Menu.Gameplay:
                gameplayMenu.SetActive(true);
                break;
        }
    }

    public void PlayerWin()
    {
        winImage.enabled = true;
        loseImage.enabled = false;
    }
    public void PlayerLost()
    {
        winImage.enabled = false;
        loseImage.enabled = true;
    }

    public void SetGameTime(float elapsed)
    {
        gameTime.text = elapsed.ToString("F2");
    }

    public void SetEndGameTime(float elapsed)
    {
        endTime.text = elapsed.ToString("F2");
    }
}
