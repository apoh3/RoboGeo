/*
 * Platforms: Controls effects when player jumps on or off platforms
 *
 * author: Allison Poh
 *
 * Timestamp: 11/3/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{
    public Sprite newSprite;

    private SpriteRenderer spriteRenderer;
    private Sprite origSprite;
    private Color origColor;

    private int flag = 0;
 
    //get current sprite renderer and sprite
    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        origSprite = spriteRenderer.sprite;
        origColor = spriteRenderer.color;
    }

    //when the player collides with a platform
    void OnTriggerEnter2D(Collider2D col) {
        if(col.name == "Player") {
            //keyboard key platforms (pressed down effect)
            if(gameObject.tag == "KeyPlat") {
                spriteRenderer.sprite = newSprite;
                Debug.Log(col.name + " landed on a " + gameObject.tag);
            }

            //phone platforms (ring)
            if(gameObject.tag == "callPlat") {
                spriteRenderer.color = new Color32(126,126,126,255);
                Debug.Log(col.name + " landed on a " + gameObject.tag);
            }

            //wire key platforms (change color)
            /*if(gameObject.tag == "wirePlat") {
                spriteRenderer.color = new Color32(175,175,175,255);
                Debug.Log(col.name + " landed on a " + gameObject.tag);
            }*/
        }
    }

    //when the player leaves with a platform
    void OnTriggerExit2D(Collider2D col) {
        if(col.name == "Player") {
            //keyboard key platforms (pressed up effect)
            if(gameObject.tag == "KeyPlat") {
                spriteRenderer.sprite = origSprite;
                Debug.Log(col.name + " left " + gameObject.tag);
            }

            //phone platforms (ring)
            if(gameObject.tag == "callPlat") {
                spriteRenderer.color = origColor;
                Debug.Log(col.name + " landed on a " + gameObject.tag);
            }

            //wire key platforms (change color)
            /*if(gameObject.tag == "wirePlat") {
                spriteRenderer.color = origColor;
                Debug.Log(col.name + " left " + gameObject.tag);
            }*/
        }
    }
}
