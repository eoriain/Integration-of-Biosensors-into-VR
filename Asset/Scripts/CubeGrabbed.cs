using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGrabbed : MonoBehaviour
{
    private OVRGrabbable OVRGrabbable;
    private signalBaselineValues controller;
    public string PickUpTS;
    public string PickUpValue;
    public string valueToBeLogged;
    public bool flag;

    // Start is called before the first frame update
    void Start()
    {
        OVRGrabbable = GetComponent<OVRGrabbable>();
        controller = GameObject.Find("SignalBaselines").GetComponent<signalBaselineValues>();
        flag = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRGrabbable.isGrabbed && flag == true) 
        {
            DateTime now = DateTime.Now;
            PickUpTS = now.ToString("yyyyMMddHHmmssfff");
            PickUpValue = "User picked up 1kg object";

            valueToBeLogged = controller.StartTS.ToString() + ", " + controller.AttentionBaselineAverage.ToString() + ", " + controller.MeditationBaselineAverage.ToString() + ", " + controller.DeltaBaselineAverage.ToString() + ", " + controller.ThetaBaselineAverage.ToString() + ", " + controller.lowAlphaBaselineAverage.ToString() + ", " + controller.highAlphaBaselineAverage.ToString() + ", " + controller.lowBetaBaselineAverage.ToString() + ", " + controller.highBetaBaselineAverage.ToString() + ", " + controller.lowGammaBaselineAverage.ToString() + ", " + controller.highGammaBaselineAverage.ToString() + ", " + controller.gsrShimmerBaselineAverage.ToString() + ", " + controller.ppgBaselineAverage.ToString() + ", " + controller.hrBaselineAverage.ToString() + ", " + controller.bpmBaselineAverage.ToString() + ", " + controller.tempBaselineAverage.ToString() + ", " + controller.gsrBaselineAverage.ToString() + ", " + controller.bvpBaselineAverage.ToString() + ", " + controller.ibiBaselineAverage.ToString();

            //GameObject.Find("IntroductionArea").SetActive(false);

            flag = false;
        }        
    }
}
