using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    [SerializeField] float force = 100f;
    [SerializeField] GameObject bumper;
    [SerializeField] int BaseScore = 100;
    private Vector3 scale = Vector3.zero;
    private bool hit, waiting;
    private float expandTime = 0.025f;

    private void OnCollisionEnter(Collision clsn){
        // Debug.Log("COLLISION");
        // clsn.rigidbody.transform.Translate(0,1,0);
        
        // Rigidbody ball = clsn.rigidbody;
        // Vector3 diff = ball.transform.position - this.transform.position;
        // Vector3 dir = new Vector3(diff.x, 0, diff.z).normalized;
        // ball.AddForce(dir * force);
        
        
        if(clsn.rigidbody.tag=="Ball")
        {
            hit = true;
            force = Random.Range(60.0f, 120.0f);
            Rigidbody otherRB = clsn.rigidbody;
            otherRB.AddExplosionForce(force, transform.position,5);
            
            Utilities.Score += (int) (BaseScore * Utilities.ScoreMultiplier + 0.001f);
            Utilities.hitCount++;
        }
    }

    void Update()
    {
        // Only get the original size of the bumper once
        if (scale == Vector3.zero)
            scale = bumper.transform.localScale;

        if (hit)
        {
            if (waiting)
                return;
            bumper.transform.localScale = scale * 1.25f;
            Time.timeScale = 0.0f;
            StartCoroutine(Wait(expandTime));
        }
    }

    IEnumerator Wait(float time)
    {
        waiting = true;
        yield return new WaitForSecondsRealtime(time);
        Time.timeScale = 1.0f;
        bumper.transform.localScale = scale;
        hit = false;
        waiting = false;
    }
}
