using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using MindWave;

public class valueMyndplayHighGammaScaler : MonoBehaviour
{
    Slider highGammaSlider;  
    private TGCConnectionController controller;
    public int maxHighGamma;

    private void Start()
    {
        highGammaSlider = GetComponent<Slider>();
        controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();
    }

    void Update()
    {
        highGammaSlider.value = controller.highGamma;
        highGammaSlider.maxValue = controller.highGammaList.Max();
        maxHighGamma = controller.highGammaList.Max();
    }
}