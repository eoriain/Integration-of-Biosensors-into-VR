using UnityEngine;
using UnityEngine.UI;

public class valueShimmerPPG_TS : MonoBehaviour
{  
    Text ppgShimmerText;  
    private ShimmerBiosignals controller;


    private void Start()
    {
        ppgShimmerText = GetComponent<Text>();
        controller = GameObject.Find("ShimmerObject").GetComponent<ShimmerBiosignals>();
    }

    void Update()
    {
        ppgShimmerText.text = controller.ppg_ts.ToString();
    }
}