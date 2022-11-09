using UnityEngine;
using UnityEngine.UI;
using MindWave;

public class valueMyndplayDelta : MonoBehaviour
{  
    Text deltaText;  
    private TGCConnectionController controller;


    private void Start()
    {
        deltaText = GetComponent<Text>();
        controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();
    }

    void Update()
    {
        deltaText.text = controller.Delta.ToString();
    }
}