using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using MindWave;

public class valueMyndplayAttentionScaler : MonoBehaviour
{
    Slider attentionSlider;  
    private TGCConnectionController controller;
    public int maxAttention;

    private void Start()
    {
        attentionSlider = GetComponent<Slider>();
        controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();
    }

    void Update()
    {
        attentionSlider.value = controller.Attention;
        attentionSlider.maxValue = controller.AttentionList.Max();
        maxAttention = controller.AttentionList.Max();
    }
}