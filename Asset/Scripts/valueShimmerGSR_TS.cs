using UnityEngine;
using UnityEngine.UI;

public class valueShimmerGSR_TS : MonoBehaviour
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
        gsrShimmerText.text = controller.gsr_ts.ToString();
    }
}