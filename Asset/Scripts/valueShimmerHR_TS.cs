using UnityEngine;
using UnityEngine.UI;

public class valueShimmerHR_TS : MonoBehaviour
{  
    Text hrShimmerText;  
    private ShimmerBiosignals controller;


    private void Start()
    {
        hrShimmerText = GetComponent<Text>();
        controller = GameObject.Find("ShimmerObject").GetComponent<ShimmerBiosignals>();
    }

    void Update()
    {
        hrShimmerText.text = controller.hr_ts.ToString();
    }
}