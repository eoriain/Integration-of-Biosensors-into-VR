using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using MindWave;

public class valueMyndplayHighBetaScaler : MonoBehaviour
{
    Slider highBetaSlider;  
    private TGCConnectionController controller;
    public int maxHighBeta;

    private void Start()
    {
        highBetaSlider = GetComponent<Slider>();
        controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();
    }

    void Update()
    {
        highBetaSlider.value = controller.highBeta;
        highBetaSlider.maxValue = controller.highBetaList.Max();
        maxHighBeta = controller.highBetaList.Max();
    }
}