using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRotator : MonoBehaviour
{
    public float secondsPerRotation = 6.0f;
    public static Transform objectToRotate;
   

    // Update is called once per frame
    void Update()
    {
        objectToRotate.Rotate(0, 6.0f * (2.5f * secondsPerRotation) * Time.deltaTime, 0);
    }
}
