using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using MindWave;

public class valueMyndplayStressPercent : MonoBehaviour
{  
    Text stressText;  
    private TGCConnectionController controller;
    private ShimmerBiosignals controller1;
    private ICATEmpaticaBLEClient controller2;
    private signalBaselineValues controller3;
    public float stressPercentage;
    public float thetaPercentage;
    public float lowAlphaPercentage;
    public float highAlphaPercentage;
    public float ibiPercentage;
    public float gsrPercentage;
    public float tempPercentage;
    public string stressPercentage_ts;

    private void Start()
    {
        stressText = GetComponent<Text>();
        controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();
        controller1 = GameObject.Find("ShimmerObject").GetComponent<ShimmerBiosignals>();
        controller2 = GameObject.Find("EmpaticaE4").GetComponent<ICATEmpaticaBLEClient>();
        controller3 = GameObject.Find("SignalBaselines").GetComponent<signalBaselineValues>();
    }

    void Update()
    {
        DateTime now = DateTime.Now;

        if (controller.Theta <= controller3.ThetaBaselineAverage)
        {
            thetaPercentage = 0.0f;
        }
        else 
        {
            thetaPercentage = (float)(controller.Theta / ((controller.ThetaList.Max() - controller3.ThetaBaselineAverage) / 100));
        }

        if (controller.lowAlpha >= controller3.lowAlphaBaselineAverage)
        {
            lowAlphaPercentage = 0.0f;
        }
        else
        {
            lowAlphaPercentage = (float)((controller3.lowAlphaBaselineAverage - controller.lowAlpha) / ((controller3.lowAlphaBaselineAverage - 0) / 100));
        }

        if (controller.highAlpha >= controller3.highAlphaBaselineAverage)
        {
            highAlphaPercentage = 0.0f;
        }
        else
        {
            highAlphaPercentage = (float)((controller3.highAlphaBaselineAverage - controller.highAlpha) / ((controller3.highAlphaBaselineAverage - 0) / 100));
        }

        if (controller2.ibi >= controller3.ibiBaselineAverage)
        {
            ibiPercentage = 0.0f;
        }
        else
        {
            ibiPercentage = (float)((controller3.ibiBaselineAverage - controller2.ibi) / ((controller3.ibiBaselineAverage - 0) / 100));
        }

        if (controller2.gsr <= controller3.gsrBaselineAverage)
        {
            gsrPercentage = 0.0f;
        }
        else
        {
            gsrPercentage = (float)((controller2.gsr - controller3.gsrBaselineAverage) / ((controller2.gsrList.Max() - controller3.gsrBaselineAverage) / 100));
        }

        if (controller2.temp <= controller3.tempBaselineAverage)
        {
            tempPercentage = 0.0f;
        }
        else
        {
            tempPercentage = (float)((controller2.temp - controller3.tempBaselineAverage) / ((controller2.tempList.Max() - controller3.tempBaselineAverage) / 100));
        }

        stressPercentage = (thetaPercentage + lowAlphaPercentage + highAlphaPercentage + ibiPercentage + gsrPercentage + tempPercentage)/6;
        stressPercentage_ts = now.ToString("yyyyMMddHHmmssfff");

        if (stressPercentage > 100)
        {
            stressText.text = "100.0";
        }
        else
        {
            stressText.text = stressPercentage.ToString();
        }
    }
}