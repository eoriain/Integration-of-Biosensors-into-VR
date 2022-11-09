using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using MindWave;

public class valueEmpaticaIBIScaler : MonoBehaviour
{
    Slider ibiSlider;  
    private ICATEmpaticaBLEClient controller;

    private void Start()
    {
        ibiSlider = GetComponent<Slider>();
        controller = GameObject.Find("EmpaticaE4").GetComponent<ICATEmpaticaBLEClient>();
    }

    void Update()
    {
        ibiSlider.value = controller.ibi;
        ibiSlider.maxValue = controller.ibiList.Max();
    }
}