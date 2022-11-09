using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class beat1 : MonoBehaviour
{
    Texture2D hrImage;
    private ShimmerBiosignals controller;

    // Start is called before the first frame update
    void Start()
    {
        hrImage = GetComponent<Texture2D>();
        controller = GameObject.Find("ShimmerObject").GetComponent<ShimmerBiosignals>();

        InvokeRepeating("Beat1", 0, (controller.hr/60));
    }

    // Update is called once per frame
    void Beat1()
    {
        hrImage.width = 120;
        hrImage.height = 120;
        Thread.Sleep(500);
        hrImage.width = 100;
        hrImage.height = 100;
    }
}
