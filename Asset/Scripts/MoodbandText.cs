using UnityEngine;
using UnityEngine.UI;

public class MoodbandText : MonoBehaviour
{  
    Text moodText;
    private valueMyndplayStatus controller;

    private void Start()
    {
        moodText = GetComponent<Text>();
        controller = GameObject.Find("DuplicateStatus").GetComponent<valueMyndplayStatus>();
    }

    void Update()
    {
        moodText.text = controller.status;
    }
}