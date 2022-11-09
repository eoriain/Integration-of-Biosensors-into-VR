using UnityEngine;
using UnityEngine.UI;

public class valueEmpaticaTEMP_TS : MonoBehaviour
{  
    Text tempText;  
    private ICATEmpaticaBLEClient controller;


    private void Start()
    {
        tempText = GetComponent<Text>();
        controller = GameObject.Find("EmpaticaE4").GetComponent<ICATEmpaticaBLEClient>();
    }

    void Update()
    {
        tempText.text = controller.temp_ts.ToString();
    }
}