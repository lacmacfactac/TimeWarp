using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceMovementDirection : MonoBehaviour
{
    public Vector3 prevPos;
    public Vector3 faceDirection;
    public float movementDirection;
    Animator animator;
    float timeSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        prevPos = transform.position - transform.forward;
        faceDirection = transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        timeSpeed = animator.GetFloat("Speed");

        faceDirection = timeSpeed >= 0 ? prevPos-transform.position : transform.position-prevPos;
        //movementDirection = Vector3.SignedAngle(transform.forward, faceDirection, Vector3.up);
        //movementDirection = Vector3.SignedAngle(transform.forward, faceDirection, Vector3.up);
        if (movementDirection < -0.01f)
        {
           // animator.SetInteger("Direction", -1);
        }
        else if (movementDirection > 0.01f)
        {
           // animator.SetInteger("Direction", 1);
        }
        else
        {
           // animator.SetInteger("Direction", 0);
        }
        Quaternion p = Quaternion.FromToRotation(transform.up, Vector3.up);
        transform.rotation = p * transform.rotation;
        Quaternion q = Quaternion.FromToRotation(transform.forward, faceDirection);
        transform.rotation =  q * transform.rotation;

        if ((transform.position - prevPos).magnitude > 1f)
        {
            prevPos = transform.position;
        }
        prevPos = transform.position;
    }
}
