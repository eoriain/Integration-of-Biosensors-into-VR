using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using MindWave;

public class valueMyndplayStressScaler : MonoBehaviour
{  
    Slider stressSlider;  
    private valueMyndplayStressPercent controller;

    private void Start()
    {
        stressSlider = GetComponent<Slider>();
        controller = GameObject.Find("DuplicateStressValue").GetComponent<valueMyndplayStressPercent>();
    }

    void Update()
    {
       
        stressSlider.maxValue = 100;
        stressSlider.minValue = 0;
        stressSlider.value = controller.stressPercentage;
    }
}