using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class AnvilGrabbed : MonoBehaviour
{
    private OVRGrabbable OVRGrabbable;
    public string PickUpTS;
    public string PickUpValue;
    private bool flag;
    private bool constraintStatus;
    GameObject TaskOne;

    // Start is called before the first frame update
    void Start()
    {
        OVRGrabbable = GetComponent<OVRGrabbable>();
        flag = true;
        constraintStatus = false;
        TaskOne = GameObject.Find("Task_1");
    }

    // Update is called once per frame
    void Update()
    {
        

        if (TaskOne.activeInHierarchy == false && OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) > 0.1)
        {
            if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) > 0.1)
            {
                GameObject Anvil = GameObject.Find("Anvil_RigidBody");
                PositionConstraint positionConstraint = Anvil.GetComponent<PositionConstraint>();
                positionConstraint.constraintActive = true;
                constraintStatus = true;
            }
        }
        else if (TaskOne.activeInHierarchy == false && OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) <= 0.1)
        {
            if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) <= 0.1)
            {
                GameObject Anvil = GameObject.Find("Anvil_RigidBody");
                PositionConstraint positionConstraint = Anvil.GetComponent<PositionConstraint>();
                positionConstraint.constraintActive = false;
            }
        }
        if (constraintStatus == true && flag == true)
        {
            DateTime now = DateTime.Now;
            PickUpTS = now.ToString("yyyyMMddHHmmssfff");
            PickUpValue = "User picked up Boulder";


            flag = false;
        }

    }
    /* void OnCollisionEnter(Collision col)
     {
         if (col.gameObject.name == "CustomHandLeft" && col.gameObject.name == "CustomHandRight" && OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) == 1.0 && OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) == 1.0 && flag == true)
         {
             DateTime now = DateTime.Now;
             PickUpTS = now.ToString("yyyyMMddHHmmssfff");
             PickUpValue = "User picked up Anvil";

             flag = false;
         }
         else if (col.gameObject.name == "CustomHandLeft" && col.gameObject.name == "CustomHandRight" && OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger)==1.0 && OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger)==1.0)
         {
             GameObject Anvil = GameObject.Find("Anvil_RigidBody");
             PositionConstraint positionConstraint = Anvil.GetComponent<PositionConstraint>();
             positionConstraint.constraintActive = true;
         }
         else
         {
            // GameObject Anvil = GameObject.Find("Anvil_RigidBody");
             //PositionConstraint positionConstraint = Anvil.GetComponent<PositionConstraint>();
             //positionConstraint.constraintActive = false;
         }
     }*/
}
