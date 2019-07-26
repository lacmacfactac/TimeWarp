using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSpeed : MonoBehaviour
{
    public float timeSpeed = 1;
    float prevSpeed = 1;
    Animator[] animators;
    // Start is called before the first frame update
    void Start()
    {
        animators = GameObject.FindObjectsOfType<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Animator animator in animators)
        {
            animator.SetFloat("Speed", timeSpeed);

        }
        
    }
}
