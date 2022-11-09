using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using MindWave;

public class valueMyndplayRelaxPercent : MonoBehaviour
{  
    Text relaxText;
    private TGCConnectionController controller;
    private ShimmerBiosignals controller1;
    private ICATEmpaticaBLEClient controller2;
    private signalBaselineValues controller3;
    public float relaxPercentage;
    public float DeltaPercentage;
    public float lowBetaPercentage;
    public float highBetaPercentage;
    public float lowAlphaPercentage;
    public float highAlphaPercentage;
    public float ibiPercentage;
    public float gsrPercentage;
    public string relaxPercentage_ts;

    private void Start()
    {
        relaxText = GetComponent<Text>();
        controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();
        controller1 = GameObject.Find("ShimmerObject").GetComponent<ShimmerBiosignals>();
        controller2 = GameObject.Find("EmpaticaE4").GetComponent<ICATEmpaticaBLEClient>();
        controller3 = GameObject.Find("SignalBaselines").GetComponent<signalBaselineValues>();
    }

    void Update()
    {
        DateTime now = DateTime.Now;
        if (controller.Delta <= controller3.DeltaBaselineAverage)
        {
            DeltaPercentage = 0.0f;
        }
        else
        {
            DeltaPercentage = (float)(controller.Delta / ((controller.DeltaList.Max() - controller3.DeltaBaselineAverage) / 100));
        }

        if (controller.lowBeta >= controller3.lowBetaBaselineAverage)
        {
            lowBetaPercentage = 0.0f;
        }
        else
        {
            lowBetaPercentage = (float)((controller3.lowBetaBaselineAverage - controller.lowBeta) / ((controller3.lowBetaBaselineAverage - 0) / 100));
        }

        if (controller.highBeta >= controller3.highBetaBaselineAverage)
        {
            highBetaPercentage = 0.0f;
        }
        else
        {
            highBetaPercentage = (float)((controller3.highBetaBaselineAverage - controller.highBeta) / ((controller3.highBetaBaselineAverage - 0) / 100));
        }

        if (controller.lowAlpha <= controller3.lowAlphaBaselineAverage)
        {
            lowAlphaPercentage = 0.0f;
        }
        else
        {
            lowAlphaPercentage = (float)(controller.lowAlpha / ((controller.lowAlphaList.Max() - controller3.lowAlphaBaselineAverage) / 100));
        }

        if (controller.highAlpha <= controller3.highAlphaBaselineAverage)
        {
            highAlphaPercentage = 0.0f;
        }
        else
        {
            highAlphaPercentage = (float)(controller.highAlpha / ((controller.highAlphaList.Max() - controller3.highAlphaBaselineAverage) / 100));
        }

        if (controller2.ibi <= controller3.ibiBaselineAverage)
        {
            ibiPercentage = 0.0f;
        }
        else
        {
            ibiPercentage = (float)((controller2.ibi - controller3.ibiBaselineAverage) / ((controller2.ibiList.Max() - controller3.ibiBaselineAverage) / 100));
        }

        if (controller2.gsr >= controller3.gsrBaselineAverage)
        {
            gsrPercentage = 0.0f;
        }
        else
        {
            gsrPercentage = (float)((controller3.gsrBaselineAverage - controller2.gsr) / ((controller3.gsrBaselineAverage - 0) / 100));
        }

        relaxPercentage = (DeltaPercentage + lowBetaPercentage + highBetaPercentage + lowAlphaPercentage + highAlphaPercentage + ibiPercentage + gsrPercentage) / 7;
        relaxPercentage_ts = now.ToString("yyyyMMddHHmmssfff");

        if (relaxPercentage > 100)
        {
            relaxText.text = "100.0";
        }
        else
        {
            relaxText.text = relaxPercentage.ToString();
        }
    }
}