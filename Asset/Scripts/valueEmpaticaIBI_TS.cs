using UnityEngine;
using UnityEngine.UI;

public class valueEmpaticaIBI_TS : MonoBehaviour
{  
    Text ibiText;  
    private ICATEmpaticaBLEClient controller;


    private void Start()
    {
        ibiText = GetComponent<Text>();
        controller = GameObject.Find("EmpaticaE4").GetComponent<ICATEmpaticaBLEClient>();
    }

    void Update()
    {
        ibiText.text = controller.ibi_ts.ToString();
    }
}