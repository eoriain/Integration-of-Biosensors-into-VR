using UnityEngine;
using UnityEngine.UI;

public class valueShimmerTS : MonoBehaviour
{  
    Text tsShimmerText;  
    private ShimmerBiosignals controller;


    private void Start()
    {
        tsShimmerText = GetComponent<Text>();
        controller = GameObject.Find("ShimmerObject").GetComponent<ShimmerBiosignals>();
    }

    void Update()
    {
        tsShimmerText.text = controller.ts.ToString("F2");
    }
}