using UnityEngine;

public class AudioPitch : MonoBehaviour
{
    ICATEmpaticaBLEClient controller;
    public double startingPitch = 1.0;
    AudioSource audioSource;

    void Start()
    {
        controller = GameObject.Find("EmpaticaE4").GetComponent<ICATEmpaticaBLEClient>();
        audioSource = GetComponent<AudioSource>();
        audioSource.pitch = (float)startingPitch;
    }

    void Update()
    {
        if (controller.ibi < 0.2)
        {
            audioSource.pitch = (float)startingPitch;
        }
        else if (controller.ibi > 2.0)
        {
            audioSource.pitch = (float)startingPitch;
        }
        else
        {
            audioSource.pitch = (float)(1/controller.ibi);
        }
    }
}