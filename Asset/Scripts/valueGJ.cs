using UnityEngine;
using UnityEngine.UI;

public class valueGJ : MonoBehaviour
{  
    Text gjText;  
    ButtonVR controller;
    public string test;


    private void Start()
    {
        gjText = GetComponent<Text>();
        controller = GameObject.Find("TestCollider").GetComponent<ButtonVR>();
    }

    void Update()
    {
        test = controller.testString;
        gjText.text = controller.testString;
    }
}