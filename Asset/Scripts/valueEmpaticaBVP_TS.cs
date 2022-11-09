using UnityEngine;
using UnityEngine.UI;

public class valueEmpaticaBVP_TS : MonoBehaviour
{  
    Text bvpText;  
    private ICATEmpaticaBLEClient controller;


    private void Start()
    {
        bvpText = GetComponent<Text>();
        controller = GameObject.Find("EmpaticaE4").GetComponent<ICATEmpaticaBLEClient>();
    }

    void Update()
    {
        bvpText.text = controller.bvp_ts.ToString();
    }
}