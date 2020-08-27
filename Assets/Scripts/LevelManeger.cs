using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManeger : MonoBehaviour
{
    public static LevelManeger levelManeger;
    private int coinsCorrent = 0;
    private bool gameOver = false;
    private float seconds;
    private int secondsToInt;
    private int minutes;

    public Text minutesText;
    public Text secondsText;
    public Text coinsText;

    public GameObject gameOverText;

    private bool winLevel = false;
    public GameObject winLevelText;
    public int levelFree;

    void Awake()
    {
        if(levelManeger == null)
        {
            levelManeger = this;
        }
        else if (levelManeger != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver && !winLevel)
        {
            seconds += Time.deltaTime;
            if(seconds > 60)
            {
                seconds = 0;
                minutes++;
                minutesText.text = minutes.ToString();
            }
            secondsToInt = (int)seconds;
            secondsText.text = secondsToInt.ToString();
        }
        if(gameOver && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (winLevel && Input.GetMouseButtonUp(0))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    public void SetCoins()
    {
        coinsCorrent++;
        coinsText.text = coinsCorrent.ToString();
    }

    public int GetCoins()
    {
        return coinsCorrent;
    }

    public void ResetCoins()
    {
        coinsCorrent = 0;
        coinsText.text = coinsCorrent.ToString(); 
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverText.SetActive(true);
    }

    public void WinLevel()
    {
        winLevel = true;
        LevelSet.levelSet.freeLevel(levelFree);
        winLevelText.SetActive(true);
    }
}
