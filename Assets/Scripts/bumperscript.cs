using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bumperscript : MonoBehaviour
{
    [SerializeField] float bounceForce;
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag=="Player")
        {
            Rigidbody otherRB = collision.rigidbody;
            otherRB.AddExplosionForce(bounceForce, collision.contacts[0].point,5);
        }
    }
}