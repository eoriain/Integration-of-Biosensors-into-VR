using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using MindWave;

public class valueShimmerGSRScaler : MonoBehaviour
{
    Slider gsrSlider;  
    private ShimmerBiosignals controller;

    private void Start()
    {
        gsrSlider = GetComponent<Slider>();
        controller = GameObject.Find("ShimmerObject").GetComponent<ShimmerBiosignals>();
    }

    void Update()
    {
        gsrSlider.value = (float)controller.gsr;
        gsrSlider.maxValue = (float)controller.gsrList.Max();
    }
}