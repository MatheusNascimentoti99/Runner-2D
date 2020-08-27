using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSet : MonoBehaviour
{
    public static LevelSet levelSet;
    private int correntLevel = 1;
    // Start is called before the first frame update
    void Awake()
    {
        if(levelSet == null)
        {
            levelSet = this;
        }
        else if (levelSet != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void freeLevel(int levelOpen)
    {
        if(levelOpen > correntLevel)
        {
            correntLevel = levelOpen;
        }
    }

    public int GetCorrentLevel()
    {
        return correntLevel;
    }
}

