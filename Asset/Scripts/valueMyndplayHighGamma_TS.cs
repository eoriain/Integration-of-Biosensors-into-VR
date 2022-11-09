using UnityEngine;
using UnityEngine.UI;
using MindWave;

public class valueMyndplayHighGamma_TS : MonoBehaviour
{  
    Text highGammaText;  
    private TGCConnectionController controller;


    private void Start()
    {
        highGammaText = GetComponent<Text>();
        controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();
    }

    void Update()
    {
        highGammaText.text = controller.highGamma_ts.ToString();
    }
}