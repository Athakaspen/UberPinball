using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlane : MonoBehaviour
{
    private void OnCollisionEnter(Collision clsn){
        Destroy(clsn.rigidbody.gameObject);
    }
}
