using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class VRControl : MonoBehaviour
{
    public SteamVR_ActionSet actionSet;
    public SteamVR_Action_Vector2 timeVector;
    public SteamVR_Input_Sources inputSource;
    public float timeSpeed = 1;
    public float maxTimeSpeed = 20;
    public float minTimeSpeed = -20;
    public float stepScale = 0.001f;
    float timeVal = 1;
    bool changed = true;
    Animator[] animators;
    ParticleSystem[] particles;
    // Start is called before the first frame update
    void Start()
    {
        actionSet.Activate();
        timeVector[inputSource].onChange += VectorChanged;
        animators = GameObject.FindObjectsOfType<Animator>();
        particles = GameObject.FindObjectsOfType<ParticleSystem>();

    }

    private void VectorChanged(SteamVR_Action_Vector2 fromAction, SteamVR_Input_Sources fromSource, Vector2 axis, Vector2 delta)
    {

        timeSpeed += axis.y * stepScale* (1+Mathf.Abs(timeSpeed)/10);
        timeSpeed = Mathf.Clamp(timeSpeed,minTimeSpeed, maxTimeSpeed);
        changed = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (changed)
        {
            foreach (Animator animator in animators)
            {
                animator.SetFloat("Speed", timeSpeed);

            }
            foreach (ParticleSystem particle in particles)
            {
                particle.playbackSpeed = Mathf.Abs(timeSpeed);
            }
            changed = false;
        }
        
    }
}
