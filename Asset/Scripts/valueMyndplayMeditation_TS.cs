using UnityEngine;
using UnityEngine.UI;
using MindWave;

public class valueMyndplayMeditation_TS : MonoBehaviour
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
        meditationText.text = controller.Meditation_ts.ToString();
    }
}