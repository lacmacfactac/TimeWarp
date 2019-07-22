using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class VRInput : MonoBehaviour
{
    public SteamVR_ActionSet actionset;
    public SteamVR_Input_Sources inputSource;
    public SteamVR_Action_Single timeWarpInput;

    TimeWarp timeWarp;

    float warpRaw = 1;
    // Start is called before the first frame update
    void Start()
    {
        timeWarp = gameObject.GetComponent<TimeWarp>();

        actionset.Activate();
        timeWarpInput[inputSource].onChange += OnWarpChanged;
        
    }

    private void OnWarpChanged(SteamVR_Action_Single fromAction, SteamVR_Input_Sources fromSource, float newAxis, float newDelta)
    {
        Debug.Log("New value: " + newAxis.ToString());
        warpRaw = newAxis;
    }

    // Update is called once per frame
    void Update()
    {
        timeWarp.Speed = warpRaw;
    }
}
