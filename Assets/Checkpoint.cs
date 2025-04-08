using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        //Check to see if it's the player colliding 
        if (!other.CompareTag("Player")) 
        {
            return;
        }

        if(transform == GameLogic.checkpointA[GameLogic.currentCheckpoint].transform)
        {
            if (GameLogic.currentCheckpoint + 1 < GameLogic.checkpointA.Length)
            {
                if(GameLogic.currentCheckpoint == 0)
                {
                    GameLogic.currentLap++;
                }
                GameLogic.currentCheckpoint++;
            }
            else
            {
                GameLogic.currentCheckpoint = 0;
            }
        }
    }
}
