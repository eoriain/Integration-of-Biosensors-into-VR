using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using MindWave;

public class PlankAnimation : MonoBehaviour
{
    Animator PlankMotion;
    AudioSource audioSource;
    private valueMyndplayStressPercent controller;

    // Start is called before the first frame update
    void Start()
    {
        PlankMotion = GetComponent<Animator>();
        controller = GameObject.Find("DuplicateStressValue").GetComponent<valueMyndplayStressPercent>();
        audioSource = GetComponent<AudioSource>();
        audioSource.Play(0);
    }

    // Update is called once per frame
    void Update()
    {
        //A stress level of 45-65% is the desired value.
        if (controller.stressPercentage >= 0 && controller.stressPercentage < 20)
        {
            PlankMotion.SetBool("PerformIdle", false);
            PlankMotion.SetBool("PerformLightShake", false);
            PlankMotion.SetBool("PerformHeavyShake", true);
            audioSource.UnPause();
            //Debug.Log(controller.stressPercentage + " = Heavy");
        }
        else if (controller.stressPercentage >= 20 && controller.stressPercentage < 40)
        {
            PlankMotion.SetBool("PerformIdle", false);
            PlankMotion.SetBool("PerformLightShake", true);
            PlankMotion.SetBool("PerformHeavyShake", false);
            audioSource.UnPause();
            //Debug.Log(controller.stressPercentage + " = light");
        }
        else if (controller.stressPercentage >= 40 && controller.stressPercentage < 60)
        {
            PlankMotion.SetBool("PerformIdle", true);
            PlankMotion.SetBool("PerformLightShake", false);
            PlankMotion.SetBool("PerformHeavyShake", false);
            audioSource.Pause();
            //Debug.Log(controller.stressPercentage + " = Idle");
        }
        else if (controller.stressPercentage >= 60)
        {
            PlankMotion.SetBool("PerformIdle", true);
            PlankMotion.SetBool("PerformLightShake", false);
            PlankMotion.SetBool("PerformHeavyShake", false);
            audioSource.UnPause();
        }
    }
}
