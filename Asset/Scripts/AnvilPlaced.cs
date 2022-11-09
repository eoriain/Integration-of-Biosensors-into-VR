using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnvilPlaced : MonoBehaviour
{
    public string PlacementTS;
    public string PlacementValue;

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
        if (col.gameObject.name == "TargetPlatform")
        {
            DateTime now = DateTime.Now;
            PlacementTS = now.ToString("yyyyMMddHHmmssfff");
            PlacementValue = "User placed the boulder on the platform";
            GameObject.Find("Task_2").SetActive(false);


            GameObject TaskThree = GameObject.Find("Congratulations");
            TaskThree.transform.localPosition = new Vector3(-13.348f, 1.217f, 5.327f);
        }
    }
}

