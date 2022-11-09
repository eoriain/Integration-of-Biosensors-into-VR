using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using MindWave;

public class valueShimmerPPGScaler : MonoBehaviour
{
    Slider ppgSlider;  
    private ShimmerBiosignals controller;

    private void Start()
    {
        ppgSlider = GetComponent<Slider>();
        controller = GameObject.Find("ShimmerObject").GetComponent<ShimmerBiosignals>();
    }

    void Update()
    {
        ppgSlider.value = (float)controller.ppg;
        ppgSlider.maxValue = (float)controller.ppgList.Max();
    }
}