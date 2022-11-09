using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGrabbedIntro : MonoBehaviour
{
    private OVRGrabbable OVRGrabbable;
    private bool flag;

    // Start is called before the first frame update
    void Start()
    {
        OVRGrabbable = GetComponent<OVRGrabbable>();
        flag = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRGrabbable.isGrabbed && flag == true) 
        {
            GameObject.Find("StepTwoBlock").SetActive(false);
            GameObject.Find("MoveToStepFour").SetActive(false);

            flag = false;
        }        
    }
}
