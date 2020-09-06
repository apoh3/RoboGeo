/*
 * Instruction: For level 1, when the player runs throught a InsFlagBlock_#, the instruction displays at the top and all previous instructions are destroyed
 * **requires inputting instructNum (the current instruction) and numOfInstructs
 *
 * author: Allison Poh
 *
 * Timestamp: 11/3/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instruction : MonoBehaviour
{
    public int instructNum;
    public GameObject instruction;
    public string scriptName = "";

    private Rigidbody2D rigidBody; //InsFlagBlocks
    private int numOfInstructs;

    //get reference to the InsFlagBlock and the current color of it, and hide all blocks
    void Start() {
        if(scriptName == "level1") {
            numOfInstructs = 6;
        } else {
            numOfInstructs = 1;
        }

        rigidBody = gameObject.GetComponent<Rigidbody2D>();

        HideCurr(instructNum);    
    }

    //when player collides into InsFlagBlock, display the correct instruction and destroy the last one
    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "Player") {
            Debug.Log(this.name + " collided with " + col.name);

            if(instructNum <= numOfInstructs) {
                if(instructNum > 1) {
                    StartCoroutine(Coroutine());
                } else {
                    OneAppear();
                }          
            } else {
                DestroyPrev();
                Destroy(GameObject.Find("InsFlagBlock_" + (instructNum)));
            }
        }
    }

    //enumerator to wait 1 second before showing next instruction
    IEnumerator Coroutine() {
        DestroyPrev();
        yield return new WaitForSeconds(1);
        OneAppear();
    }

    //set current instruction to transparent
    private void HideCurr(int blockNum) {
        //turn panel transparent
        if(blockNum <= numOfInstructs) {
            //string instructBlock = "I" + blockNum;
            instruction.GetComponent<Image>().color = new Color32(0,0,0,0);
        
            //turn all text transparent
            Text[] texts = instruction.GetComponentsInChildren<Text>();
            for(int j = 0; j < texts.Length; j++) {
                texts[j].color = new Color32(0,0,0,0);
            } 

            //turn all keys transparent
            Renderer[] renderers = instruction.GetComponentsInChildren<Renderer>();
            for(int j = 0; j < renderers.Length; j++) {
                renderers[j].material.color = new Color32(0,0,0,0);
            }
        }
    }

    //destroy previous InsFlagBlock (to avoid running into it again if running backwards)
    private void DestroyPrev() {
        if(GameObject.Find("I" + (instructNum-1)) != null) {
            Destroy(GameObject.Find("I" + (instructNum-1)));
            Destroy(GameObject.Find("InsFlagBlock_" + (instructNum-1)));
        }
    }

    //set current instruction to original color
    private void OneAppear() {
        //string currBlock = "I"+instructNum;

        //turn panel transparent
        instruction.GetComponent<Image>().color = new Color32(255,255,255,200);

        //turn all text transparent
        Text[] texts = instruction.GetComponentsInChildren<Text>();
        for(int j = 0; j < texts.Length; j++) {
            texts[j].color = new Color32(0,0,0,255);
        } 

        //turn all keys transparent
        Renderer[] renderers = instruction.GetComponentsInChildren<Renderer>();
        for(int j = 0; j < renderers.Length; j++) {
            renderers[j].material.color = new Color32(255,255,255,255);
        }
    }

    //handles collisoin error when enemy collides into block
    private void Damage() { }
}
