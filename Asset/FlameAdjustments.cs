using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameAdjustments : MonoBehaviour
{

    ParticleSystem particleLauncher;
    private valueMyndplayStressPercent controller1;
    public float ParticleRateOverTime;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        controller1 = GameObject.Find("DuplicateStressValue").GetComponent<valueMyndplayStressPercent>();
        particleLauncher = GetComponent<ParticleSystem>();
        particleLauncher.Play(true);
        var emission = particleLauncher.emission;
        audioSource = GetComponent<AudioSource>();
        audioSource.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller1.stressPercentage >= 45)
        {
            var emission = particleLauncher.emission;
            emission.rateOverTime = 0;
            ParticleRateOverTime = 0;
            audioSource.Pause();
        }
        else if (controller1.stressPercentage >= 30 && controller1.stressPercentage < 45)
        {
            var emission = particleLauncher.emission;
            emission.rateOverTime = 0.5f;
            ParticleRateOverTime = 0.5f;
        }
        else if (controller1.stressPercentage >= 15 && controller1.stressPercentage < 30)
        {
            var emission = particleLauncher.emission;
            emission.rateOverTime = 1.5f;
            ParticleRateOverTime = 1.5f;
        }                       
        else if (controller1.stressPercentage < 15)
        {
            var emission = particleLauncher.emission;
            emission.rateOverTime = 5;
            ParticleRateOverTime = 5;
        }
    }
}
