/*
 * Borders: Attached to the ground, platforms, and walls. Simply allows for a damage message to be sent but takes no actions. Needed for preventing
 * unwanted errors when an enemy collides (i.e. touches, walks on, or falls onto) with this object.
 * 
 * author: Allison Poh
 *
 * timestamp: 11/3/19
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borders : MonoBehaviour
{
    void Damage() {
        //do nothing
    }
}
