using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fog : MonoBehaviour
{
    public float fogDensityInside = 0;
    public float fogDensityOutside = 0;
    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.fogDensity = fogDensityInside;
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Camera.main.gameObject)
        {
            RenderSettings.fogDensity = fogDensityInside;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Camera.main.gameObject)
        {
            RenderSettings.fogDensity = fogDensityOutside;

        }
    }

}
