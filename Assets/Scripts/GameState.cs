﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[System.Serializable]
public class GameState
{

    public static int[] levelStars = {0,0,0};
    private int levels = 3;

    public static void setStars(int level, int turn)
    {
        int stars = 4 - turn;
        
        if (stars < 0)
        {
            stars = 0;
        }

        if (stars > levelStars[level])
        {
            levelStars[level] = stars;
        }
    }
}
