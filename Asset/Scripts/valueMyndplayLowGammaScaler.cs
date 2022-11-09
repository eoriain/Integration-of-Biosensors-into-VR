using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using MindWave;

public class valueMyndplayLowGammaScaler : MonoBehaviour
{  
    Slider lowGammaSlider;  
    private TGCConnectionController controller;
    public int maxLowGamma;


    private void Start()
    {
        lowGammaSlider = GetComponent<Slider>();
        controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();
    }

    void Update()
    {
        lowGammaSlider.value = controller.lowGamma;
        lowGammaSlider.maxValue = controller.lowGammaList.Max();
        maxLowGamma = controller.lowGammaList.Max();
    }
}