/*
 * Player: Controls the player, including updating when hit, and determining what triggers they set off.
 * If the player is damaged by enemy, will "blink" for 1 second. Player can also trigger new level, collect object, and die.
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

public class Player : MonoBehaviour
{
	public int nextScene;
	
	public int blinkInterval;
	public int endFrame = 60;

	public Sprite b1; //battery image files
	public Sprite b2;
	public Sprite b3;
	public Sprite b0;

	private Color playerColor;
	private int frameCnt;
	private int colorFlag = 0;
	private int isDamaged = 0;

	private int score;

	//called before the first frame update
	void Start() {
		//playerColor = gameObject.GetComponent<SpriteRenderer>().color;

		playerColor = Values.GetPlayerColor();	
		gameObject.GetComponent<SpriteRenderer>().color = playerColor;

		//carry over health and score
		int health = Values.GetHealth();

		if(health == 1) {
			health = 33;
			GameObject.Find("HealthImg").GetComponent<Image>().sprite = b1;
		} else if(health == 2) {
			health = 67;
			GameObject.Find("HealthImg").GetComponent<Image>().sprite = b2;
		} else if(health == 3) {
			health = 100;
			GameObject.Find("HealthImg").GetComponent<Image>().sprite = b3;
		}
		
		GameObject.Find("HealthTxt").GetComponent<Text>().text = health + "%";
		GameObject.Find("ScoreTxt").GetComponent<Text>().text = Values.GetScore().ToString();
	}

	//updates players color if damaged (blinks for 1 second by turning transparency on and off and moves enemy to new layer so player can run
	//through while blinking)
	void Update() {
		frameCnt++;

		if(isDamaged == 1) {
			if(frameCnt <= endFrame) {
				if(frameCnt % blinkInterval == 0) {
					if(colorFlag == 0) {
						gameObject.GetComponent<SpriteRenderer>().color = new Color32(255,255,255,0);
						colorFlag = 1;
					} else {
						gameObject.GetComponent<SpriteRenderer>().color = playerColor;
						colorFlag = 0;
					}		
				}
			} else {
				isDamaged = 0;
				frameCnt = 0;

				gameObject.layer = LayerMask.NameToLayer("Default");
			}
		}
	}

	//called when player hit by enemy, set flags
	void Damage() {
		Debug.Log("Player damaged");

		if(isDamaged == 0) {
			isDamaged = 1;
			frameCnt = 0;

			gameObject.layer = LayerMask.NameToLayer("damaged");

			//decrement health and update image
			Values.health--;

			int health = Values.GetHealth();

			if(health <= 0) {
				health = 0;
				GameObject.Find("HealthImg").GetComponent<Image>().sprite = b0;
				Values.level = nextScene-1;
				SceneManager.LoadScene("GameOver");

				Debug.Log("Player died");
			} if(health == 1) {
				health = 33;
				GameObject.Find("HealthImg").GetComponent<Image>().sprite = b1;
			} else if(health == 2) {
				health = 67;
				GameObject.Find("HealthImg").GetComponent<Image>().sprite = b2;
			} else if(health == 3) {
				health = 100;
				GameObject.Find("HealthImg").GetComponent<Image>().sprite = b3;
			}
			
			GameObject.Find("HealthTxt").GetComponent<Text>().text = health + "%";
		}
	}

	//called when player hit by collectable
	void Collect(GameObject g) {
		if(g.tag == "Collectable") {
			Debug.Log("Player collected screw");

			//update score
			Values.score++;
			Values.levelScore++;
			Debug.Log("score: " + Values.GetScore());

			GameObject.Find("ScoreTxt").GetComponent<Text>().text = Values.GetScore().ToString();
		}

		if(g.tag == "Health") {
			Debug.Log("Player charged up");

			Values.health++;
			int health = Values.GetHealth();

			if(health > 3) {
				health = 3;
			}

			Debug.Log("health: " + health);

			//update health and image
			if(health == 1) {
				health = 33;
				GameObject.Find("HealthImg").GetComponent<Image>().sprite = b1;
			} else if(health == 2) {
				health = 67;
				GameObject.Find("HealthImg").GetComponent<Image>().sprite = b2;
			} else if(health == 3) {
				health = 100;
				GameObject.Find("HealthImg").GetComponent<Image>().sprite = b3;
			}

			GameObject.Find("HealthTxt").GetComponent<Text>().text = health + "%";
		}

		Destroy(g);
	}

	//determines what hit the player
	void OnTriggerEnter2D(Collider2D col) {
		//if the player reaches the end of the level
		if(col.gameObject.tag == "NewSceneDoor") {
			Debug.Log(this.name + " collided with " + col.name);

			if(nextScene == 8) {
				SceneManager.LoadScene("EndScene");
				Debug.Log("end scene");
			} else {
				SceneManager.LoadScene("Level"+nextScene);
				Debug.Log("begin level " +nextScene);
				Values.level = nextScene;
				Values.levelScore = 0;
			}
		}

		//if the player falls of a platform and triggers the invisible ground, they die
		if(col.gameObject.tag == "InvisibleGround") {
			Debug.Log(this.name + " collided with " + col.name);

			GameObject.Find("HealthImg").GetComponent<Image>().sprite = b0;
			Values.level = nextScene-1;
			SceneManager.LoadScene("GameOver");

			Debug.Log("Player died");
		}
 	}
}