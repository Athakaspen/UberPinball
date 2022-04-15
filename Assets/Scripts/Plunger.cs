using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plunger : MonoBehaviour
{
    [SerializeField] string inputName;
    [SerializeField] float pullDist = 1.0f;
    [SerializeField] float springScale = 1000.0f;
    // [SerializeField] float pullForce = 1000.0f;

    // Initialized in Start()
    private SpringJoint sj;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        sj = GetComponent<SpringJoint>();
        rb = GetComponent<Rigidbody>();

        sj.spring = springScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis(inputName) > 0.9f){
            sj.maxDistance = pullDist;
            // Debug.Log("Adding Force");
            // rb.AddForce(transform.forward * -pullForce);
        } else {
            sj.maxDistance = 0;
        }
    }
}
