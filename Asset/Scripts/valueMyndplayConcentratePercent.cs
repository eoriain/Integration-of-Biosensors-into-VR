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
using System.Collections;
using MindWave;

public class valueMyndplayConcentratePercent : MonoBehaviour
{  
    Text concentrateText;
    private TGCConnectionController controller;
    private ShimmerBiosignals controller1;
    private ICATEmpaticaBLEClient controller2;
    private signalBaselineValues controller3;
    public float concentratePercentage;
    public float DeltaPercentage;
    public float lowBetaPercentage;
    public float highBetaPercentage;
    public float lowGammaPercentage;
    public float highGammaPercentage;
    public string concentratePercentage_ts;

    private void Start()
    {
        concentrateText = GetComponent<Text>();
        controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();
        controller1 = GameObject.Find("ShimmerObject").GetComponent<ShimmerBiosignals>();
        controller2 = GameObject.Find("EmpaticaE4").GetComponent<ICATEmpaticaBLEClient>();
        controller3 = GameObject.Find("SignalBaselines").GetComponent<signalBaselineValues>();
    }

    void Update()
    {
        DateTime now = DateTime.Now;
        if (controller.Delta >= controller3.DeltaBaselineAverage)
        {
            DeltaPercentage = 0.0f;
        }
        else
        {
            DeltaPercentage = (float)((controller3.DeltaBaselineAverage - controller.Delta) / ((controller3.DeltaBaselineAverage - 0) / 100));
        }

        if (controller.lowBeta <= controller3.lowBetaBaselineAverage)
        {
            lowBetaPercentage = 0.0f;
        }
        else
        {
            lowBetaPercentage = (float)(controller.lowBeta / ((controller.lowBetaList.Max() - controller3.lowBetaBaselineAverage) / 100));
        }

        if (controller.highBeta <= controller3.highBetaBaselineAverage)
        {
            highBetaPercentage = 0.0f;
        }
        else
        {
            highBetaPercentage = (float)(controller.highBeta / ((controller.highBetaList.Max() - controller3.highBetaBaselineAverage) / 100));
        }

        if (controller.lowGamma <= controller3.lowGammaBaselineAverage)
        {
            lowGammaPercentage = 0.0f;
        }
        else
        {
            lowGammaPercentage = (float)(controller.lowGamma / ((controller.lowGammaList.Max() - controller3.lowGammaBaselineAverage) / 100));
        }

        if (controller.highGamma <= controller3.highGammaBaselineAverage)
        {
            highGammaPercentage = 0.0f;
        }
        else
        {
            highGammaPercentage = (float)(controller.highGamma / ((controller.highGammaList.Max() - controller3.highGammaBaselineAverage) / 100));
        }

        concentratePercentage = (DeltaPercentage + lowBetaPercentage + highBetaPercentage + lowGammaPercentage + highGammaPercentage) / 5;
        concentratePercentage_ts = now.ToString("yyyyMMddHHmmssfff");

        if (concentratePercentage > 100)
        {
            concentrateText.text = "100.0";
        }
        else
        {
            concentrateText.text = concentratePercentage.ToString();
        }
    }
}