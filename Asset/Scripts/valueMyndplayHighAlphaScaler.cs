using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using MindWave;

public class valueMyndplayHighAlphaScaler : MonoBehaviour
{
    Slider highAlphaSlider;  
    private TGCConnectionController controller;
    public int maxHighAlpha;

    private void Start()
    {
        highAlphaSlider = GetComponent<Slider>();
        controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();
    }

    void Update()
    {
        highAlphaSlider.value = controller.highAlpha;
        highAlphaSlider.maxValue = controller.highAlphaList.Max();
        maxHighAlpha = controller.highAlphaList.Max();
    }
}