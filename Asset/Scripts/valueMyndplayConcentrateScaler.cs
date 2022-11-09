using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using MindWave;

public class valueMyndplayConcentrateScaler : MonoBehaviour
{  
    Slider concentrateSlider;
    private valueMyndplayConcentratePercent controller;

    private void Start()
    {
        concentrateSlider = GetComponent<Slider>();
        controller = GameObject.Find("DuplicateConcentrateValue").GetComponent<valueMyndplayConcentratePercent>();
    }

    void Update()
    {

        concentrateSlider.maxValue = 100;
        concentrateSlider.minValue = 0;
        concentrateSlider.value = controller.concentratePercentage;
    }
}