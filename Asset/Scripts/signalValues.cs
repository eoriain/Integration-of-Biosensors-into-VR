using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using MindWave;

public class signalValues : MonoBehaviour
{  
    private TGCConnectionController controller;
    private ButtonVR controller1;
    private ShimmerBiosignals controller2;
    private ICATEmpaticaBLEClient controller3;
    private CubeGrabbed controller4;
    private CubePlaced controller5;    
    private AnvilGrabbed controller6;
    private AnvilPlaced controller7;    
    private valueMyndplayStressPercent controller8;
    private valueMyndplayConcentratePercent controller9;
    private valueMyndplayRelaxPercent controller10;

    public int Attention;
    public int Meditation;
    public int Delta;
    public int Theta;
    public int lowAlpha;
    public int highAlpha;
    public int lowBeta;
    public int highBeta;
    public int lowGamma;
    public int highGamma;

    public double shimmergsr;
    public double ppg;
    public int hr;

    public float bpm;
    public float temp;
    public float gsr;
    public float bvp;
    public float ibi;

    public float stressPercentage;
    public float concentratePercentage;
    public float relaxPercentage;

    public string StartValue;
    public string ExitValue;
    public string PickUpValue;
    public string PlacementValue;    
    public string PickUp2Value;
    public string Placement2Value;

    public string timeNow;

    public string valueToBeLogged;

    private void Start()
    {
        controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();
        controller1 = GameObject.Find("GoCollider").GetComponent<ButtonVR>();
        controller2 = GameObject.Find("ShimmerObject").GetComponent<ShimmerBiosignals>();
        controller3 = GameObject.Find("EmpaticaE4").GetComponent<ICATEmpaticaBLEClient>();
        controller4 = GameObject.Find("TargetObject").GetComponent<CubeGrabbed>();
        controller5 = GameObject.Find("TargetObject").GetComponent<CubePlaced>();        
        controller6 = GameObject.Find("Anvil_RigidBody").GetComponent<AnvilGrabbed>();
        controller7 = GameObject.Find("Anvil_RigidBody").GetComponent<AnvilPlaced>();
        controller8 = GameObject.Find("DuplicateStressValue").GetComponent<valueMyndplayStressPercent>();
        controller9 = GameObject.Find("DuplicateConcentrateValue").GetComponent<valueMyndplayConcentratePercent>();
        controller10 = GameObject.Find("DuplicateRelaxValue").GetComponent<valueMyndplayRelaxPercent>();

        PickUpValue = "------";
        PlacementValue = "------";
        PickUp2Value = "------";
        Placement2Value = "------";
    }

    void Update()
    {
        DateTime now = DateTime.Now;
        timeNow = now.ToString("yyyyMMddHHmmssf");

        if (controller.Attention_ts.Contains(timeNow))
        {
            Attention = controller.Attention;
        }
        else
        {
            Attention = 0;
        }

        if (controller.Meditation_ts.Contains(timeNow))
        {
            Meditation = controller.Meditation;
        }
        else
        {
            Meditation = 0;
        }

        if (controller.Delta_ts.Contains(timeNow))
        {
            Delta = controller.Delta;
        }
        else
        {
            Delta = 0;
        }

        if (controller.Theta_ts.Contains(timeNow))
        {
            Theta = controller.Theta;
        }
        else
        {
            Theta = 0;
        }

        if (controller.lowAlpha_ts.Contains(timeNow))
        {
            lowAlpha = controller.lowAlpha;
        }
        else
        {
            lowAlpha = 0;
        }

        if (controller.highAlpha_ts.Contains(timeNow))
        {
            highAlpha = controller.highAlpha;
        }
        else
        {
            highAlpha = 0;
        }

        if (controller.lowBeta_ts.Contains(timeNow))
        {
            lowBeta = controller.lowBeta;
        }
        else
        {
            lowBeta = 0;
        }

        if (controller.highBeta_ts.Contains(timeNow))
        {
            highBeta = controller.highBeta;
        }
        else
        {
            highBeta = 0;
        }

        if (controller.lowGamma_ts.Contains(timeNow))
        {
            lowGamma = controller.lowGamma;
        }
        else
        {
            lowGamma = 0;
        }

        if (controller.highGamma_ts.Contains(timeNow))
        {
            highGamma = controller.highGamma;
        }
        else
        {
            highGamma = 0;
        }

        if (controller2.gsr_ts.Contains(timeNow))
        {
            shimmergsr = controller2.gsr;
        }
        else
        {
            shimmergsr = 0;
        }

        if (controller2.ppg_ts.Contains(timeNow))
        {
            ppg = controller2.ppg;
        }
        else
        {
            ppg = 0;
        }

        if (controller2.hr_ts.Contains(timeNow))
        {
            hr = controller2.hr;
        }
        else
        {
            hr = 0;
        }

        if (controller3.bpm_ts.Contains(timeNow))
        {
            bpm = controller3.bpm;
        }
        else
        {
            bpm = 0;
        }

        if (controller3.temp_ts.Contains(timeNow))
        {
            temp = controller3.temp;
        }
        else
        {
            temp = 0;
        }

        if (controller3.gsr_ts.Contains(timeNow))
        {
            gsr = controller3.gsr;
        }
        else
        {
            gsr = 0;
        }

        if (controller3.bvp_ts.Contains(timeNow))
        {
            bvp = controller3.bvp;
        }
        else
        {
            bvp = 0;
        }

        if (controller3.ibi_ts.Contains(timeNow))
        {
            ibi = controller3.ibi;
        }
        else
        {
            ibi = 0;
        }        
        
        if (controller8.stressPercentage_ts.Contains(timeNow))
        {
            stressPercentage = controller8.stressPercentage;
        }
        else
        {
            stressPercentage = 0;
        }

        if (controller9.concentratePercentage_ts.Contains(timeNow))
        {
            concentratePercentage = controller9.concentratePercentage;
        }
        else
        {
            concentratePercentage = 0;
        }

        if (controller10.relaxPercentage_ts.Contains(timeNow))
        {
            relaxPercentage = controller10.relaxPercentage;
        }
        else
        {
            relaxPercentage = 0;
        }

        if (controller1.StartTS.Contains(timeNow))
        {
            StartValue = controller1.StartValue;
        }

        if (controller1.ExitTS.Contains(timeNow))
        {
            ExitValue = controller1.ExitValue;
        }

        if (controller4.PickUpTS.Contains(timeNow))
        {
            PickUpValue = controller4.PickUpValue;
        }

        if (controller5.PlacementTS.Contains(timeNow))
        {
            PlacementValue = controller5.PlacementValue;
        }
    
        if (controller6.PickUpTS.Contains(timeNow))
        {
            PickUp2Value = controller6.PickUpValue;
        }

        if (controller7.PlacementTS.Contains(timeNow))
        {
            Placement2Value = controller7.PlacementValue;
        }

        //Debug.Log(timeNow + ", " + Attention + ", " + Meditation + ", " + Delta + ", " + Theta + ", " + lowAlpha + ", " + highAlpha + ", " + lowBeta + ", " + highBeta + ", " + lowGamma + ", " + shimmergsr + ", " + ppg + ", " + hr + ", " + bpm + ", " + temp + ", " + gsr + ", " + bvp + ", " + ibi + ", " + StartValue + ", " + ExitValue + ", " + PickUpValue + ", " + PlacementValue);
        valueToBeLogged = timeNow.ToString() + ", " + stressPercentage.ToString() + ", " + concentratePercentage.ToString() + ", " + relaxPercentage.ToString() + ", " + Attention.ToString() + ", " + Meditation.ToString() + ", " + Delta.ToString() + ", " + Theta.ToString() + ", " + lowAlpha.ToString() + ", " + highAlpha.ToString() + ", " + lowBeta.ToString() + ", " + highBeta.ToString() + ", " + lowGamma.ToString() + ", " + highGamma.ToString() + ", " + shimmergsr.ToString() + ", " + ppg.ToString() + ", " + hr.ToString() + ", " + bpm.ToString() + ", " + temp.ToString() + ", " + gsr.ToString() + ", " + bvp.ToString() + ", " + ibi.ToString() + ", " + StartValue + ", " + ExitValue + ", " + PickUpValue + ", " + PlacementValue + ", " + PickUp2Value + ", " + Placement2Value;
    }
}