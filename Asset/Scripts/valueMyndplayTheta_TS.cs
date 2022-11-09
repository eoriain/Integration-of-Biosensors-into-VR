using UnityEngine;
using UnityEngine.UI;
using MindWave;

public class valueMyndplayTheta_TS : MonoBehaviour
{  
    Text thetaText;  
    private TGCConnectionController controller;


    private void Start()
    {
        thetaText = GetComponent<Text>();
        controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();
    }

    void Update()
    {
        thetaText.text = controller.Theta_ts.ToString();
    }
}