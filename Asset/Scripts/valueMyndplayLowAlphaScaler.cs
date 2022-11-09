using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using MindWave;

public class valueMyndplayLowAlphaScaler : MonoBehaviour
{
    Slider lowAlphaSlider;  
    private TGCConnectionController controller;
    public int maxLowAlpha;

    private void Start()
    {
        lowAlphaSlider = GetComponent<Slider>();
        controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();
    }

    void Update()
    {
        lowAlphaSlider.value = controller.lowAlpha;
        lowAlphaSlider.maxValue = controller.lowAlphaList.Max();
        maxLowAlpha = controller.lowAlphaList.Max();
    }
}