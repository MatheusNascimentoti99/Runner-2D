using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void LoadLevel(int level)
    {
        if(level <= LevelSet.levelSet.GetCorrentLevel())
        {
            SceneManager.LoadScene(level);
        }
        else
        {
            return;
        }
    }
}
