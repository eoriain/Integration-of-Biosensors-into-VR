using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using MindWave;

public class valueMyndplayMeditationScaler : MonoBehaviour
{  
    Slider meditationSlider;  
    private TGCConnectionController controller;
    public int maxMeditation;

    private void Start()
    {
        meditationSlider = GetComponent<Slider>();
        controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();
    }

    void Update()
    {
        meditationSlider.value = controller.Meditation;
        meditationSlider.maxValue = controller.MeditationList.Max();
        maxMeditation = controller.MeditationList.Max();
    }
}