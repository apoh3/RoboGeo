/*
 * GameUtilities: Handles interactions during the game that do not affect game play, such as pausing and exiting
 *
 * author: Allison Poh
 *
 * Timestamp: 11/3/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUtilities : MonoBehaviour
{	
	private int pauseFlag = 0;

	//check if game should be paused/unpaused, where 'p' is the key
    void Update() {
		//pause
		if(Input.GetKeyDown("p")) {
			if(pauseFlag == 0) { //pause game (halt time)
				Time.timeScale = 0;
				pauseFlag = 1;
				Debug.Log("game paused");
			} else if(pauseFlag == 1) { //unpause game
				Time.timeScale = 1;
				pauseFlag = 0;
				Debug.Log("game unpaused");
			}
		}

		//exit
		if(Input.GetKeyDown("escape")) { 
			SceneManager.LoadScene("MainMenu");
	    	Debug.Log("back at main menu");

			Values.ResetValues();

			Time.timeScale = 1; //if pause -> exit -> start, game is never unpaused
		}
		
	}
}