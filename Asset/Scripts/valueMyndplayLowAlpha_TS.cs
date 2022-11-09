using UnityEngine;
using UnityEngine.UI;
using MindWave;

public class valueMyndplayLowAlpha_TS : MonoBehaviour
{  
    Text lowAlphaText;  
    private TGCConnectionController controller;


    private void Start()
    {
        lowAlphaText = GetComponent<Text>();
        controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();
    }

    void Update()
    {
        lowAlphaText.text = controller.lowAlpha_ts.ToString();
    }
}