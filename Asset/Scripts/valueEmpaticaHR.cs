using UnityEngine;
using UnityEngine.UI;

public class valueEmpaticaHR : MonoBehaviour
{  
    Text hrText;  
    private ICATEmpaticaBLEClient controller;


    private void Start()
    {
        hrText = GetComponent<Text>();
        controller = GameObject.Find("EmpaticaE4").GetComponent<ICATEmpaticaBLEClient>();
    }

    void Update()
    {
        hrText.text = controller.bpm.ToString();
    }
}