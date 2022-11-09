using UnityEngine;
using UnityEngine.UI;
using MindWave;

public class valueMyndplayStatus : MonoBehaviour
{  
    Text statusText;
    /*
    private TGCConnectionController controller;
    private ICATEmpaticaBLEClient controller1;
    private signalBaselineValues controller2;
    */
    private valueMyndplayStressPercent controller1;
    private valueMyndplayConcentratePercent controller2;
    private valueMyndplayRelaxPercent controller3;

    public string status;

    private void Start()
    {
        status = "_______";
        statusText = GetComponent<Text>();
        /*controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();
        controller1 = GameObject.Find("EmpaticaE4").GetComponent<ICATEmpaticaBLEClient>();
        controller2 = GameObject.Find("SignalBaselines").GetComponent<signalBaselineValues>();*/
        controller1 = GameObject.Find("DuplicateStressValue").GetComponent<valueMyndplayStressPercent>();
        controller2 = GameObject.Find("DuplicateConcentrateValue").GetComponent<valueMyndplayConcentratePercent>();
        controller3 = GameObject.Find("DuplicateRelaxValue").GetComponent<valueMyndplayRelaxPercent>();
    }

    void Update()
    {
        if (controller1.stressPercentage > controller2.concentratePercentage && controller1.stressPercentage > controller3.relaxPercentage)
        {
            status = "STRESSED";
        }
        else if (controller2.concentratePercentage > controller1.stressPercentage && controller2.concentratePercentage > controller3.relaxPercentage)
        {
            status = "CONCENTRATING";
        }
        else if (controller3.relaxPercentage > controller2.concentratePercentage && controller3.relaxPercentage > controller1.stressPercentage)
        {
            status = "RELAXED";
        }
        statusText.text = "Physiological Status:   " + status;
    }
} 