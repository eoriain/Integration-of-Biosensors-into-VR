using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePlacedIntro : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "TargetIntroPlatform")
        {
            GameObject.Find("StepThreeBlock").SetActive(false);
        }
    }
}
