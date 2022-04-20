using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHit : MonoBehaviour
{
    private static float lastHit = 0f;
    void OnCollisionEnter(Collision col)
    {
        if (lastHit == 0f)
            lastHit = Time.time;
        if (Time.time - lastHit >= .005f)
        {
            if (col.collider.tag == "Wall")
            {
                // Debug.Log("Bump");
                float rand = Random.Range(0f, 10f);
                if (rand <= 3.3f)
                    FindObjectOfType<AudioManager>().Play("WallHit1");
                else if (rand <= 6.6f)
                    FindObjectOfType<AudioManager>().Play("WallHit2");
                else
                    FindObjectOfType<AudioManager>().Play("WallHit3");
            }

            if (col.collider.tag == "Player")
            {
                // Debug.Log("Ball Bump");
                FindObjectOfType<AudioManager>().Play("BallHit1");
            }
            lastHit = 0f;
        }
        
    }
}
