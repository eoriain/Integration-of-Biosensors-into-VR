using UnityEngine;
using UnityEngine.UI;

public class valueShimmerGSR : MonoBehaviour
{  
    Text gsrShimmerText;  
    private ShimmerBiosignals controller;


    private void Start()
    {
        gsrShimmerText = GetComponent<Text>();
        controller = GameObject.Find("ShimmerObject").GetComponent<ShimmerBiosignals>();
    }

    void Update()
    {
        gsrShimmerText.text = controller.gsr.ToString("F2") + " kOhms";
    }
}