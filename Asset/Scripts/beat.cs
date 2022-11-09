using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class beat : MonoBehaviour
{
    private RectTransform heartImage;
    private ICATEmpaticaBLEClient controller;
    public int beatRate;

    

    // Start is called before the first frame update
    void Start()
    {
        heartImage = GetComponent<RectTransform>();
        controller = GameObject.Find("EmpaticaE4").GetComponent<ICATEmpaticaBLEClient>();
        if (controller.bpm > 10)
        {
            beatRate = (int)(controller.bpm/60)*1000;
        }
        else
        {
            beatRate = 1000;
        }
        
        //InvokeRepeating("Beat", 0, (controller.bpm/60));
    }

    // Update is called once per frame
    void Update()
    {
        //heartImage.rectTransform.sizeDelta = new Vector2(120, 120);
        Thread.Sleep(500);
        //heartImage.rectTransform.sizeDelta = new Vector2(100, 100);
        Thread.Sleep(beatRate);
    }
}
