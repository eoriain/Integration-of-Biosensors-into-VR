using UnityEngine;
using UnityEngine.UI;
using MindWave;

public class valueMyndplayMeditation : MonoBehaviour
{  
    Text meditationText;  
    private TGCConnectionController controller;


    private void Start()
    {
        meditationText = GetComponent<Text>();
        controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();
    }

    void Update()
    {
        meditationText.text = controller.Meditation.ToString();
    }
}