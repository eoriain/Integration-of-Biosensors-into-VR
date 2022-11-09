using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogAdjustment : MonoBehaviour
{
    private valueMyndplayStressPercent controller;
    public float fogDistance;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("DuplicateStressValue").GetComponent<valueMyndplayStressPercent>();

        RenderSettings.fog = true;
        RenderSettings.fogMode = FogMode.Linear;
        fogDistance = RenderSettings.fogEndDistance;
        fogDistance = 150;
      
        InvokeRepeating("FogChange", 0, 4);

    }

    // Update is called once per frame
    void FogChange()
    {
        if (controller.stressPercentage > 60)
        {
            fogDistance -= 10;
        }
        else if (controller.stressPercentage < 40)
        {
            fogDistance += 10;
        }

        if (fogDistance > 500)
        {
            fogDistance = 500;
        }
        else if (fogDistance < 150)
        {
            fogDistance = 150;
        }
    }
}
