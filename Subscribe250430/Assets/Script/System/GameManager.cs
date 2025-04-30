using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    private bool bPause;

    public int money;
    public TextMeshProUGUI money_text;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        bPause = false;
    }

    private void Update()
    {
        money_text.text = money.ToString();
    }

    public void Pause()
    {
        if (bPause == false)
        {
            Time.timeScale = 0;
            bPause = true;
            return;
        }
    }

    public void UnPause()
    {
        if (bPause == true)
        {
            Time.timeScale = 1;
            bPause = false;
            return;
        }
    }

    public void ReStartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
