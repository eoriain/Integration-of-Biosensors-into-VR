using UnityEngine;
using UnityEngine.UI;
using MindWave;

public class valueMyndplayLowBeta_TS : MonoBehaviour
{  
    Text lowBetaText;  
    private TGCConnectionController controller;


    private void Start()
    {
        lowBetaText = GetComponent<Text>();
        controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();
    }

    void Update()
    {
        lowBetaText.text = controller.lowBeta_ts.ToString();
    }
}