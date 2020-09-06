/*
 * Values: Holds all static attributes that need to be passed from scene to scene and provides access to these attributes.
 *
 * author: Allison Poh
 *
 * Timestamp: 11/3/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Values
{
    public static int level = 1;
    public static int score = 0;
    public static int levelScore = 0;
    public static int health = 3;
    public static Color playerColor = new Color32(125,125,125,255);
    public static float soundVolume = 0.5f;
    public static float musicVolume = 0.5f;

    //below determined by each level
    public static int GetLevel() {
        return level;
    }

    public static int GetScore() {
        return score;
    }

    public static int GetLevelScore() {
        return levelScore;
    }

    public static int GetHealth() {
        if(health > 3) //max out at 3
            health = 3;

        return health;
    }

    //below determined by settings
    public static Color GetPlayerColor() {
        return playerColor;
    }

    public static float GetSoundVolume() {
        return soundVolume;
    }

    public static float GetMusicVolume() {
        return musicVolume;
    }

    //resets the attributes changed during gameplay
    public static void ResetValues() {
        level = 1;
        score = 0;
        levelScore = 0;
        health = 3;
    }
}
