/*
 * ButtonSwitch: Used by shell menus in the UI. The user can switch between button options using up/w and down/s, and can select an
 * option using "return".
 * **requires inputting "numOfBtns" and "screen" through inspector to distinquish which shell menu
 *
 * author: Allison Poh
 *
 * Timestamp: 11/3/19
 */

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
 
public class ButtonSwitch: MonoBehaviour 
{
	//input through inspector
	public int numOfBtns; 
	public string screen;

	private Button currBtn;

	private int flag = 0; //0 = up, 1 = down
	private int idx = 0;
	private string[] btns;

	//determine which buttons are available and current button selected (initially the first button in the list)
	void Start () {	
		if(screen == "MainMenu") {
			btns = new string[] {"StartBtn","SettingsBtn","ExitBtn"};
		} else if(screen == "End") {
			btns = new string[] {"RestartBtn","MainMenuBtn","ExitBtn"};
		} else if(screen == "Story") {
			btns = new string[] {"NextBtn"};
		} else if(screen == "Win") {
			btns = new string[] {"MainMenuBtn","ExitBtn"};
		} 

		currBtn = GameObject.Find(btns[0]).GetComponent<Button>();
	}

	//check if user has new button in focus and if user selected button
	void Update() {
		//reset previous btn's color
		currBtn = GameObject.Find(btns[idx]).GetComponent<Button>();
		currBtn.GetComponent<Image>().color = Color.white;

		//determine which button is selected by keys
		if(Input.GetKeyDown("up") || Input.GetKeyDown(KeyCode.W)) {
			if(idx == 0) {
				idx = btns.Length-1;
			} else {
				idx--;
			}
		} else if(Input.GetKeyDown("down") || Input.GetKeyDown(KeyCode.S)) {
			if(idx == btns.Length-1) {
				idx = 0;
			} else {
				idx++;
			}
		}

		//set current btn's color
		currBtn = GameObject.Find(btns[idx]).GetComponent<Button>();
		currBtn.GetComponent<Image>().color = new Color32(29,41,70,255);
		Debug.Log("focused button: "+currBtn);

		//click button on return/enter
		if(Input.GetKeyDown("return")) {	       
			currBtn.onClick.Invoke(); 
			enabled = false;
		}		
	}
}