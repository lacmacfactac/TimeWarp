using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplaySpeed: MonoBehaviour
{
    public GameObject textTarget;
    public GameObject objectWithTimeSource;

    TextMeshPro text;
    VRControl speedSource;
    // Start is called before the first frame update
    void Start()
    {
        text = textTarget.GetComponent<TextMeshPro>();
        speedSource = objectWithTimeSource.GetComponent<VRControl>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = speedSource.timeSpeed.ToString("F2");
        if (speedSource.timeSpeed < 0)
        {
            text.color = Color.Lerp(Color.white, Color.red, Mathf.Abs(speedSource.timeSpeed / 20));
        }
        else
        {
            text.color = Color.Lerp(Color.white, Color.cyan, Mathf.Abs(speedSource.timeSpeed / 20));
        }
    }
}
