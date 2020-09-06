/*
 * MenuManager: Holds all the button invoke methods for the UI. 
 *
 * author: Allison Poh
 *
 * Timestamp: 11/3/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject gobject;

    private int flag = 0; //0 = settings closed, 1 = settings open 

    //start game
    void Start() {
        Debug.Log("starting game (main menu displayed)");
    }

    //checks if user is closing a popup (settings popup)
    void Update() {
        if(Input.GetKeyDown("return") && flag == 1) {
            CloseSettings();
            flag = 0;
        }
    }

    //move to story scene (MainMenu to BeginStory)
    private void BeginStory() {
        SceneManager.LoadScene("BeginStory");
	    Debug.Log("story time..");
    }

    //back to main menu
    private void GoBackToMain() {
        SceneManager.LoadScene("MainMenu");
	    Debug.Log("back at main menu");
    }

    //load current scene
    private void LoadSceneAt() {
	    string level = "Level"+Values.GetLevel();
        SceneManager.LoadScene(level);

	    Debug.Log("begin level "+Values.GetLevel());
        Values.health = 3;
        Values.score-=Values.levelScore;
        Values.levelScore = 0;
    }

    //toggle settings popup
    private void DisplaySettings() {
        GameObject.Find("SettingsPanel").transform.SetAsLastSibling();
        flag = 1;

        Debug.Log("displaying settings menu...");
    }

    //toggle settings popup
    private void CloseSettings() {
        GameObject.Find("SettingsPanel").transform.SetAsFirstSibling();
        Debug.Log("settings menu closed");

        ButtonSwitch script; //enable button panel
        script = gobject.GetComponent<ButtonSwitch>();
        script.enabled = true;
    }

    //exit program
    private void Terminate() {
        Debug.Log("quitting...");
        Application.Quit(); //closes when .exe
        //UnityEditor.EditorApplication.isPlaying = false; //closes in unity
    }
}

    
