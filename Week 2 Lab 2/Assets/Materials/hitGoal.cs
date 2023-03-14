using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitGoal : MonoBehaviour
{
    private movement move;
    void OnCollisionEnter (Collision collisionInto)
    {
        if(collisionInto.collider.tag == "Goal")
        {
            Debug.Log("You Win");
        }
    }
}