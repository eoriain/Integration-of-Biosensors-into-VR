using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMovement : MonoBehaviour
{
    public OVRPlayerController player;
    private Transform OVRCameraRig;
    private Transform CenterEyeAnchor;
    public float startPosX;
    public float startPosY;
    public float startPosZ;
    public float startRotX;
    public float startRotY;
    public float startRotZ;

    // Start is called before the first frame update
    void Start()
    {
        CenterEyeAnchor = GameObject.Find("CenterEyeAnchor").GetComponent<Transform>();
        OVRCameraRig = GameObject.Find("OVRCameraRig").GetComponent<Transform>();

        startPosX = CenterEyeAnchor.position.x;
        startPosY = CenterEyeAnchor.position.y;
        startPosZ = CenterEyeAnchor.position.z;
        startRotX = CenterEyeAnchor.rotation.x;
        startRotY = CenterEyeAnchor.rotation.y;
        startRotZ = CenterEyeAnchor.rotation.z;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (CenterEyeAnchor.position.y < (startPosY - 0.18))
        {
        }
        else if (CenterEyeAnchor.rotation.x < (startRotX - 10.0))
        {
        }
        else if (CenterEyeAnchor.rotation.x > (startRotX + 10.0))
        {
        }
        else if (CenterEyeAnchor.rotation.z < (startRotZ - 10.0))
        {
        }
        else if (CenterEyeAnchor.rotation.z > (startRotZ + 10.0))
        {
        }
        else
        {*/
        Vector3 offset = CenterEyeAnchor.position - player.transform.position;
        //Debug.Log(offset);
        player.transform.position -= new Vector3(offset.x, 0, offset.z);
        OVRCameraRig.position -= new Vector3(offset.x, 0, offset.z);
        //}
    }
}
