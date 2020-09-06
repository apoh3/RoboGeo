/*
 * Typing: used for displaying the back story, showing the text one letter at a time
 *
 * author: Allison Poh
 *
 * timestamp: 11/3/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Typing : MonoBehaviour
{
    public Text txt;
    public Image btn;

    private int idx = 0;
    private int frameCnt = 0;
    private int returnFlag = 0;
    private string textToPrint = "Hey...hello...HEY YOU! I've got this weird robot stuck inside me. Can you help him out?? And while you're at it, tell him to clean up all these old screws. Thanks.";
    
    //reference text object and next button
    void Start() {
        txt = GameObject.Find("StoryTxt_1").GetComponent<Text>();
        btn = GameObject.Find("NextBtn").GetComponent<Image>();

        txt.text = "";
        
        btn.color = new Color32(255,255,255,0);
        GameObject.Find("NextBtn").GetComponent<Animator>().enabled = false;
    }

    //print one letter every 5 frames unless return is pressed (print all letters at once then)
    void Update() {
        if(Input.GetKeyDown("return") && returnFlag == 0) { //print all letters
            txt.text = textToPrint;
            idx = textToPrint.Length;

            returnFlag = 1;

            return;
        } else if(Input.GetKeyDown("return") && returnFlag == 1) {
            StartGameAtLevel1();
        }

        if(idx < textToPrint.Length) { //display single letter
            if(frameCnt == 5) {
                txt.text += textToPrint[idx];
                idx++;
                frameCnt = 0;
            } else {
                frameCnt++;
            }
        } else if (idx == textToPrint.Length) { //animate button when all characters displayed
            GameObject.Find("NextBtn").GetComponent<Animator>().enabled = true;
            idx++;
            returnFlag = 1;
        }
    }

    //start the game
    private void StartGameAtLevel1() {
        SceneManager.LoadScene("Level1");
	    Debug.Log("begin level 1");
    }

}
