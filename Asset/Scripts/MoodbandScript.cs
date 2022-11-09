using UnityEngine;
using UnityEngine.UI;

public class MoodbandScript : MonoBehaviour
{  
    Text moodText;
    private Renderer moodColour;
    private valueMyndplayStatus controller;

    private void Start()
    {
        moodText = GetComponent<Text>();
        moodColour = GetComponent<Renderer>();
        controller = GameObject.Find("DuplicateStatus").GetComponent<valueMyndplayStatus>();
    }

    void Update()
    {
        if (controller.status == "STRESSED")
        {
            moodColour.material.color = Color.red;
        }
        if (controller.status == "CONCENTRATING")
        {
            moodColour.material.color = Color.blue;
        }
        if (controller.status == "RELAXED")
        {
            moodColour.material.color = Color.yellow;
        }
    }
}