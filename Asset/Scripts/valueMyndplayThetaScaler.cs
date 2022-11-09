using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using MindWave;

public class valueMyndplayThetaScaler : MonoBehaviour
{  
    Slider thetaSlider;  
    private TGCConnectionController controller;
    public int maxTheta;

    private void Start()
    {
        thetaSlider = GetComponent<Slider>();
        controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();
    }

    void Update()
    {
        thetaSlider.value = controller.Theta;
        thetaSlider.maxValue = controller.ThetaList.Max();
        maxTheta = controller.ThetaList.Max();
    }
}