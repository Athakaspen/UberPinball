using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHit : MonoBehaviour
{
    private static float lastHit = 0f;
    void OnCollisionEnter(Collision col)
    {
        float rand = Random.Range(0f, 10f);
        if (col.collider.tag == "Wall" || col.collider.tag == "Flipper")
        {
            if (rand <= 3.3f)
                FindObjectOfType<AudioManager>().Play("WallHit1");
            else if (rand <= 6.6f)
                FindObjectOfType<AudioManager>().Play("WallHit2");
            else
                FindObjectOfType<AudioManager>().Play("WallHit3");
        }

        else if (col.collider.tag == "Ball")
        {
            // Debug.Log("Ball Bump");
            FindObjectOfType<AudioManager>().Play("BallHit1");
        }

        else if (col.collider.tag == "ScoreObject")
        {
            if (rand <= 1.6f)
                FindObjectOfType<AudioManager>().Play("ScoreHit1");
            else if (rand <= 3.3f)
                FindObjectOfType<AudioManager>().Play("ScoreHit2");
            else if (rand <= 5f)
                FindObjectOfType<AudioManager>().Play("ScoreHit3");
            else if (rand <= 6.6f)
                FindObjectOfType<AudioManager>().Play("ScoreHit4");
            else if (rand <= 8.3f)
                FindObjectOfType<AudioManager>().Play("ScoreHit5");
            else 
                FindObjectOfType<AudioManager>().Play("ScoreHit6");
        }
    }
}
