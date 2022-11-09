using UnityEngine;
using UnityEngine.UI;
using MindWave;

public class valueMyndplayHighAlpha : MonoBehaviour
{  
    Text highAlphaText;  
    private TGCConnectionController controller;


    private void Start()
    {
        highAlphaText = GetComponent<Text>();
        controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();
    }

    void Update()
    {
        highAlphaText.text = controller.highAlpha.ToString();
    }
}