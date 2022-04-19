using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    [SerializeField] float force = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision clsn){
        // clsn.rigidbody.transform.Translate(0,1,0);
        Rigidbody ball = clsn.rigidbody;
        Vector3 dir = Quaternion.AngleAxis(this.transform.rotation.eulerAngles.y, Vector3.up) * Vector3.forward;
        Debug.Log(dir);
        ball.AddForce(dir * force);
    }
}
