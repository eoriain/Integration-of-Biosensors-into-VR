using UnityEngine;
using UnityEngine.UI;

public class valueEmpaticaIBI : MonoBehaviour
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
        ibiText.text = controller.ibi.ToString();
    }
}