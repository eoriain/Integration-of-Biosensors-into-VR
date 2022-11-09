using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MindWave;

public class ThunderClap : MonoBehaviour
{
    valueMyndplayStressPercent controller;
    AudioSource audioSource;

    void Start()
    {
        controller = GameObject.Find("DuplicateStressValue").GetComponent<valueMyndplayStressPercent>();
        audioSource = GetComponent<AudioSource>();
        audioSource.Pause();

    }

    void Update()
    {
        if (controller.stressPercentage > 20)
            audioSource.Pause();
        else if (controller.stressPercentage <= 20)
            audioSource.UnPause();
    }
}
