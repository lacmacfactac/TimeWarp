using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeWarp : MonoBehaviour
{
    public float maximumTimeSpeed = 5;
    public float minimumTimeSpeed = 1;
    Animator[] animatorList;
    float rawSpeed = 1;
    public float speed = 1;
    bool updated = false;


    // Start is called before the first frame update
    void Start()
    {
        animatorList = GameObject.FindObjectsOfType<Animator>();
        foreach (Animator controller in animatorList)
        {
            controller.SetFloat("Speed", speed);
        }
    }


    public float SetSpeed(float value)
    {
            if (value != rawSpeed)
            {

                rawSpeed = value;
                speed = Mathf.Clamp(rawSpeed,minimumTimeSpeed, maximumTimeSpeed);
                foreach (Animator controller in animatorList)
                {
                    controller.SetFloat("Speed", speed);
                }
            }

        return speed;
    }
}
