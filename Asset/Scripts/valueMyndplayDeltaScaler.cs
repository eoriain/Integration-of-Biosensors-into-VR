using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using MindWave;

public class valueMyndplayDeltaScaler : MonoBehaviour
{  
    Slider deltaSlider;  
    private TGCConnectionController controller;
    public int maxDelta;

    private void Start()
    {
        deltaSlider = GetComponent<Slider>();
        controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();
    }

    void Update()
    {
        deltaSlider.value = controller.Delta;
        deltaSlider.maxValue = controller.DeltaList.Max();
        maxDelta = controller.DeltaList.Max();
    }
}