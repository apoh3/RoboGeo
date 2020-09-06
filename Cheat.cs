/*
 * Cheat: During any level in the game, allows the user to switch to a new level or restart the current level based on an inputted value.
 *
 * author: John Gomes
 *
 * timestamp: 11/3/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cheat : MonoBehaviour
{
    //Update is called once per frame; checks if cheat code entered
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) //#1 at top of keyboard
        {
            SceneManager.LoadScene("Level1");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene("Level2");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SceneManager.LoadScene("Level3");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SceneManager.LoadScene("Level4");
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SceneManager.LoadScene("Level5");
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            SceneManager.LoadScene("Level6");
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            SceneManager.LoadScene("Level7");
        }
        
        if (Input.GetKeyDown(KeyCode.T))
        {
            GameObject.Find("Player").transform.position = new Vector3(5.0f, 25.0f, 0.0f);
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            GameObject.Find("Player").transform.position = new Vector3(40f, 25.0f, 0.0f);
        }
    }
}
