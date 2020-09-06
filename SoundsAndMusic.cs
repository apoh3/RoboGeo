/*
 * SoundsAndMusic: Used by every scene to determine the volume of the music.
 *
 * author: Allison Poh
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsAndMusic : MonoBehaviour
{
    public AudioSource musicSrc;

    //set music volume by getting it from Values
    void Start()  {
        musicSrc.volume = Values.GetMusicVolume();
    }
}
