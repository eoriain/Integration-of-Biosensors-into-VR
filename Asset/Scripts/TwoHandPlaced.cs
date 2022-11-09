using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoHandPlaced : MonoBehaviour
{
    public float posZ;
    // Start is called before the first frame update
    void Start()
    {
        posZ = 0.99f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "TwoHandTargetIntroPlatform")
        {
            GameObject.Find("IntroPlank").SetActive(false);
            GameObject.Find("Button_Area").SetActive(false);
            GameObject.Find("PartitionWall").SetActive(false);

            GameObject TaskThree = GameObject.Find("MoveToStepFour");
            TaskThree.transform.localPosition = new Vector3(-1.774f, 2.937f, -4.733f);

        }
    }
}

