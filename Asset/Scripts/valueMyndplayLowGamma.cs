using UnityEngine;
using UnityEngine.UI;
using MindWave;

public class valueMyndplayLowGamma : MonoBehaviour
{  
    Text lowGammaText;  
    private TGCConnectionController controller;


    private void Start()
    {
        lowGammaText = GetComponent<Text>();
        controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();
    }

    void Update()
    {
        lowGammaText.text = controller.lowGamma.ToString();
    }
}