using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[System.Serializable]
public class GameState
{

    public static int[] levelStars = {-1,-1,-1};
    private int levels = 3;

    public static void setStars(int level, int stars)
    {
        if (stars < 0)
        {
            stars = 0;
        }

        if (stars > levelStars[level - 1])
        {
            levelStars[level - 1] = stars;
        }
    }

    public static bool isLevelEnabled(int level)
    {
        if (level == 1)
        {
            return true;
        }
        else
        {
            return levelStars[level - 2] >= 0;
        }
    }
}
