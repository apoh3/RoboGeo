/*
 * Settings: In the main menu, the settings options are player color, sound volume, and music volume. Methods update values for
 * all scenes to grab.
 *
 * author: Allison Poh
 *
 * timestamp: 11/3/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    //setting input options
    public Dropdown dropdown1;
    public Slider slider3;
    public Slider slider4;

    public AudioSource musicSrc; //music played
    
    private string[] d1 = new string[] {"Grey","Black","White","Red","Green","Blue"}; //dropdown options

    //changes the color of the player by setting Values.playerColor
    private void SetPlayerColor() {
        int val = dropdown1.value;
        string valTxt = d1[val];

        if(val == 0) {
            Values.playerColor = new Color32(125,125,125,255); //grey
        } else if(val == 1) {
            Values.playerColor = new Color32(0,0,0,255); //black
        } else if(val == 2) {
            Values.playerColor = new Color32(255,255,255,255); //white
        } else if(val == 3) {
            Values.playerColor = new Color32(255,0,0,255); //red
        } else if(val == 4) {
            Values.playerColor = new Color32(0,255,0,255); //green
        } else if(val == 5) {
            Values.playerColor = new Color32(0,0,255,255); //blue
        }

        Debug.Log("player color changed: " + valTxt + " (" + val + ")");
    }

    //changes the sound of all enemies by setting Values.soundVolume
    private void SetSoundVolume() {
        float val = slider3.value;

        Values.soundVolume = val*(float)0.1;

        Debug.Log("sound volume changed: " + val);
    }

    //changes the music of all scenes by setting Values.musicVolume
    private void SetMusicVolume() {
        float val = slider4.value;

        Values.musicVolume = val*(float)0.1;
        musicSrc.volume = Values.GetMusicVolume();

        Debug.Log("music volume changed: " + val);
    }
}
