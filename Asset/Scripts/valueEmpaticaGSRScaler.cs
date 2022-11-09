using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using MindWave;

public class valueEmpaticaGSRScaler : MonoBehaviour
{
    Slider gsrSlider;  
    private ICATEmpaticaBLEClient controller;

    private void Start()
    {
        gsrSlider = GetComponent<Slider>();
        controller = GameObject.Find("EmpaticaE4").GetComponent<ICATEmpaticaBLEClient>();
    }

    void Update()
    {
        gsrSlider.value = controller.gsr;
        gsrSlider.maxValue = controller.gsrList.Max();
    }
}