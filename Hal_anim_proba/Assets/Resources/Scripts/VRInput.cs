using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class VRInput : MonoBehaviour
{
    public SteamVR_ActionSet actionset;
    public SteamVR_Input_Sources inputSource;
    public SteamVR_Action_Vector2 timeWarpInput;
    public float sensitivity = 0.1f;

    TimeWarp timeWarp;

    float warpRaw = 1;
    // Start is called before the first frame update
    void Start()
    {
        timeWarp = gameObject.GetComponent<TimeWarp>();

        actionset.Activate();
        timeWarpInput[inputSource].onChange += OnWarpAction; ;
        
    }

    private void OnWarpAction(SteamVR_Action_Vector2 fromAction, SteamVR_Input_Sources fromSource, Vector2 axis, Vector2 delta)
    {
        warpRaw+=axis.y*sensitivity;
    }

    // Update is called once per frame
    void Update()
    {
        float result = timeWarp.SetSpeed(warpRaw);
        Debug.Log(result);
        warpRaw = result;
    }
}
