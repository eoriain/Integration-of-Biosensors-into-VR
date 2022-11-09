using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class CubePlaced : MonoBehaviour
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
            PlacementValue = "User placed the 1kg object on the platform";
            GameObject.Find("Task_1").SetActive(false);

            GameObject TaskTwo = GameObject.Find("Task_2");
            TaskTwo.transform.localPosition = new Vector3(-13.17f, 1.4f, 5.24f);

            GameObject Anvil = GameObject.Find("Anvil_RigidBody");
            PositionConstraint positionConstraint = Anvil.GetComponent<PositionConstraint>();
            positionConstraint.constraintActive = true;
        }
    }
}
