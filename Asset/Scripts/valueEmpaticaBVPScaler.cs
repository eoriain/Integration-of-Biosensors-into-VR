using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using MindWave;

public class valueEmpaticaBVPScaler : MonoBehaviour
{
    Slider bvpSlider;  
    private ICATEmpaticaBLEClient controller;

    private void Start()
    {
        bvpSlider = GetComponent<Slider>();
        controller = GameObject.Find("EmpaticaE4").GetComponent<ICATEmpaticaBLEClient>();
    }

    void Update()
    {
        bvpSlider.value = controller.bvp;
        bvpSlider.maxValue = controller.bvpList.Max();
    }
}