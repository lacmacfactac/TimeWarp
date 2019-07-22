using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeWarp : MonoBehaviour
{
    public float maximumTimeSpeed = 5;
    public float minimumTimeSpeed = 1;
    Animator[] animatorList;
    float rawSpeed = 1;
    float speed = 1;
    bool updated = false;


    // Start is called before the first frame update
    void Start()
    {
        animatorList = GameObject.FindObjectsOfType<Animator>();
    }


    public float Speed
    {
        get
        {
            return rawSpeed;
        }

        set
        {
            if (value != rawSpeed)
            {
                rawSpeed = value;
                speed = Mathf.Lerp(minimumTimeSpeed, maximumTimeSpeed, rawSpeed);
                foreach (Animator controller in animatorList)
                {
                    controller.speed = speed;
                }
            }
        }
    }
}
