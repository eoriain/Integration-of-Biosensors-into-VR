using UnityEngine;
using UnityEngine.UI;

public class fps : MonoBehaviour
{
    Text fpsText;
    public int refreshRate = 10;
    int frameCounter;
    float totalTime;
    public float averageFps;
    
    void Start()
    {
        fpsText = GetComponent<Text>();
        frameCounter = 0;
        totalTime = 0;
    }


    void Update()
    {

        if (frameCounter == refreshRate)
        {
            averageFps = (1.0f / (totalTime / refreshRate));
            fpsText.text = averageFps.ToString("F1");
            frameCounter = 0;
            totalTime = 0;
        }
        else 
        {
            totalTime += Time.deltaTime;
            frameCounter++;
        }
    }
}
