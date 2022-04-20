using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    public float restAngle = 0f;
    public float pressedAngle = 45f;
    public float hitStrength = 10000f;
    public float flipperDamper = 150f;

    private HingeJoint hinge;

    public string inputName;
    private bool isPressed;

    // Start is called before the first frame update
    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        hinge.useSpring = true;
    }

    // Update is called once per frame
    void Update()
    {
        JointSpring spring = new JointSpring();
        spring.spring = hitStrength;
        spring.damper = flipperDamper;

        if (Input.GetAxis(inputName) > 0.9f){
            isPressed = true;
            spring.targetPosition = pressedAngle;
        } else {
            isPressed = false;
            spring.targetPosition = restAngle;
        }
        hinge.spring = spring;
        hinge.useLimits = true;
    }

    void OnCollisionEnter(Collision clsn){
        if (!isPressed) return;
        if (clsn.rigidbody != null && clsn.rigidbody.tag == "Ball") 
            Utilities.hitCount = 0; // reset multiplier
    }
    void OnCollisionStay(Collision clsn){
        if (!isPressed) return;
        if (clsn.rigidbody != null && clsn.rigidbody.tag == "Ball") 
            Utilities.hitCount = 0; // reset multiplier
    }
}
