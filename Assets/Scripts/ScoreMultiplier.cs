using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMultiplier : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        if (col.transform.tag == "ScoreObject")
            Utilities.hitCount++;
        // else if(col.transform.tag == "Flipper")
        //     Utilities.hitCount = 0;
    }
}
