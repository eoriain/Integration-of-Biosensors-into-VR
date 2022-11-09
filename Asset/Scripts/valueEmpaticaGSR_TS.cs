using UnityEngine;
using UnityEngine.UI;

public class valueEmpaticaGSR_TS : MonoBehaviour
{  
    Text gsrText;  
    private ICATEmpaticaBLEClient controller;


    private void Start()
    {
        gsrText = GetComponent<Text>();
        controller = GameObject.Find("EmpaticaE4").GetComponent<ICATEmpaticaBLEClient>();
    }

    void Update()
    {
        gsrText.text = controller.gsr_ts.ToString();
    }
}