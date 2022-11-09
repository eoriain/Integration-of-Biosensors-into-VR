using UnityEngine;
using UnityEngine.UI;

public class valueEmpaticaTEMP : MonoBehaviour
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
        tempText.text = controller.temp.ToString();
    }
}