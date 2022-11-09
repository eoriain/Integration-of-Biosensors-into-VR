using UnityEngine;
using UnityEngine.UI;
using MindWave;

public class valueMyndplayAttention_TS : MonoBehaviour
{  
    Text attentionText;  
    private TGCConnectionController controller;


    private void Start()
    {
        attentionText = GetComponent<Text>();
        controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();
    }

    void Update()
    {
        attentionText.text = controller.Attention_ts.ToString();
    }
}