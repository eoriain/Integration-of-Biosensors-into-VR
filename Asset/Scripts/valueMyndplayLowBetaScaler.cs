using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using MindWave;

public class valueMyndplayLowBetaScaler : MonoBehaviour
{
    Slider lowBetaSlider;  
    private TGCConnectionController controller;
    public int maxLowBeta;

    private void Start()
    {
        lowBetaSlider = GetComponent<Slider>();
        controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();
    }

    void Update()
    {
        lowBetaSlider.value = controller.lowBeta;
        lowBetaSlider.maxValue = controller.lowBetaList.Max();
        maxLowBeta = controller.lowBetaList.Max();
    }
}