using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class TwoHandGrabbed : MonoBehaviour
{
    private OVRGrabbable OVRGrabbable;
    private bool constraintStatus1;
    private Transform IntroPlank;

    // Start is called before the first frame update
    void Start()
    {
        IntroPlank = GameObject.Find("IntroPlank").GetComponent<Transform>();
        OVRGrabbable = GetComponent<OVRGrabbable>();
        constraintStatus1 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (IntroPlank.position.y > 0 && OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) > 0.1)
        {
            if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) > 0.1)
            {
                GameObject TwoHandSphere = GameObject.Find("TwoHandSphere");
                PositionConstraint positionConstraint = TwoHandSphere.GetComponent<PositionConstraint>();
                positionConstraint.constraintActive = true;
                constraintStatus1 = true;
            }
        }
        else if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) <= 0.1)
        {
            if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) <= 0.1)
            {
                GameObject TwoHandSphere = GameObject.Find("TwoHandSphere");
                PositionConstraint positionConstraint = TwoHandSphere.GetComponent<PositionConstraint>();
                positionConstraint.constraintActive = false;
                constraintStatus1 = false;
            }
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
