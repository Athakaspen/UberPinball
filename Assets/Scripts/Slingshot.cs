using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    [SerializeField] float force = 100f;
    [SerializeField] GameObject slingshot;
    [SerializeField] int BaseScore = 100;
    private Vector3 scale = Vector3.zero;
    private bool hit, waiting;
    private float expandTime = 0.025f;

    private void OnCollisionEnter(Collision clsn){
        // clsn.rigidbody.transform.Translate(0,1,0);
        hit = true;
        force = Random.Range(60.0f, 120.0f);
        Rigidbody ball = clsn.rigidbody;
        Vector3 dir = Quaternion.AngleAxis(this.transform.rotation.eulerAngles.y, Vector3.up) * Vector3.forward;
        // Debug.Log(dir);
        ball.AddForce(dir * force);

        Utilities.Score += (int) (BaseScore * Utilities.ScoreMultiplier + 0.001f);
        Utilities.hitCount++;
    }

    void Update()
    {
        // Only get the original size of the slingshot once
        if (scale == Vector3.zero)
            scale = slingshot.transform.localScale;

        if (hit)
        {
            if (waiting)
                return;
            slingshot.transform.localScale = scale * 1.15f;
            Time.timeScale = 0.0f;
            StartCoroutine(Wait(expandTime));
            
        }
    }

    IEnumerator Wait(float time)
    {
        waiting = true;
        yield return new WaitForSecondsRealtime(time);
        Time.timeScale = 1.0f;
        slingshot.transform.localScale = scale;
        hit = false;
        waiting = false;
    }
}
