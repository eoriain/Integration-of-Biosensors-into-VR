using UnityEngine;
using UnityEngine.UI;
using MindWave;

public class valueMyndplayHighBeta : MonoBehaviour
{  
    Text highBetaText;  
    private TGCConnectionController controller;


    private void Start()
    {
        highBetaText = GetComponent<Text>();
        controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();
    }

    void Update()
    {
        highBetaText.text = controller.highBeta.ToString();
    }
}