using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using MindWave;

public class valueMyndplayRelaxScaler : MonoBehaviour
{  
    Slider relaxSlider;
    private valueMyndplayRelaxPercent controller;

    private void Start()
    {
        relaxSlider = GetComponent<Slider>();
        controller = GameObject.Find("DuplicateRelaxValue").GetComponent<valueMyndplayRelaxPercent>();
    }

    void Update()
    {

        relaxSlider.maxValue = 100;
        relaxSlider.minValue = 0;
        relaxSlider.value = controller.relaxPercentage;
    }
}