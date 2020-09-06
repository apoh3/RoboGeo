/*
 * Enemy: Controls how and when an enemy moves, and what happens when it is triggered by another object.
 * **requires input for "speed" through the inspector
 *
 * author: Allison Poh
 *
 * Timestamp: 11/3/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int speed; //pos = right direction, neg = left direction

    private Rigidbody2D rigidBody; //the enemy obejct
    private AudioSource soundSrc; //sound effect played by enemy

    private int isActive = 0; //flagged to 1 when the enemy is in camera view

    //get reference to the enemy object and the sound it makes
    void Start() {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        soundSrc = gameObject.GetComponent<AudioSource>();
    }

    //check if the enemy is in view and, if so, make the enemy move and play noise
    void Update() {        
		if(gameObject.GetComponent<SpriteRenderer>().isVisible && isActive == 0) { //in camera view
            isActive = 1;
        } else { //not in camera view
            if(soundSrc) {
                soundSrc.volume = 0.0f;
            }
        }

        if(isActive == 1) { //in camera view
            rigidBody.velocity = new Vector2(speed, rigidBody.velocity.y); //give enemy velocity

            if(soundSrc) { //play sound
                soundSrc.volume = Values.GetSoundVolume();
            }

            if(!gameObject.GetComponent<SpriteRenderer>().isVisible) { //stop sound if no longer visible
                soundSrc.volume = 0.0f;
            }
        }
    }

    //send "Damage" message to any object it collides with
    void OnTriggerEnter2D(Collider2D col) {
        if(col.tag == "wall" || col.tag == "Enemy") { //flip enemy's velocity if hit wall
            if(speed < 0)
                gameObject.transform.eulerAngles = new Vector3(0,180,0); 
            else if(speed > 0)
                gameObject.transform.eulerAngles = new Vector3(0,0,0); 

            speed*=-1;
        }

        if(col.gameObject)
            col.gameObject.SendMessage("Damage");
    }
}
