/*
 * Collectable: Handles when a player gets a collectable (the screw).
 *
 * author: Allison Poh
 *
 * Timestamp: 11/3/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    //get reference to current collectable
    void Start() {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    //if the feet of the player triggers the collectable, send collect message to the player and destroy the collectable
    void OnTriggerEnter2D(Collider2D col) {
        if(col is CircleCollider2D) { 
            Debug.Log("col: " + col);

            Destroy(gameObject);
            col.gameObject.SendMessage("Collect",gameObject);
        }
    }
}
