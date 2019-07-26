using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public GameObject objectDefaultOn;
    public GameObject objectDefaultOff;
    public GameObject trigger;
    // Start is called before the first frame update
    void Start()
    {
        objectDefaultOff.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == trigger)
        {
            objectDefaultOn.SetActive(false);
            objectDefaultOff.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == trigger)
        {
            objectDefaultOn.SetActive(true);
            objectDefaultOff.SetActive(false);
        }
    }
}
