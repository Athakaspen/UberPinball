using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    [SerializeField] float force = 100f;

    private void OnCollisionEnter(Collision clsn){
        // Debug.Log("COLLISION");
        // clsn.rigidbody.transform.Translate(0,1,0);
        
        // Rigidbody ball = clsn.rigidbody;
        // Vector3 diff = ball.transform.position - this.transform.position;
        // Vector3 dir = new Vector3(diff.x, 0, diff.z).normalized;
        // ball.AddForce(dir * force);

        if(clsn.transform.tag=="Ball")
        {
            Rigidbody otherRB = clsn.rigidbody;
            otherRB.AddExplosionForce(force, transform.position,5);
        }

        Utilities.Score += 100;
    }
}
