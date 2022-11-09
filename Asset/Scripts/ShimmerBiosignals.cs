using ShimmerAPI;
using ShimmerLibrary;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Debug = UnityEngine.Debug;
using UnityEngine;
//using Valve.VR;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ShimmerBiosignals : MonoBehaviour
{

    Filter LPF_PPG;
    Filter HPF_PPG;
    private PPGToHRAlgorithm PPGtoHeartRateCalculation;
    int NumberOfHeartBeatsToAverage = 1;
    int TrainingPeriodPPG = 10; //10 second buffer
    double LPF_CORNER_FREQ_HZ = 5;
    double HPF_CORNER_FREQ_HZ = 0.5;
    ShimmerLogAndStreamSystemSerialPort Shimmer;
    double SamplingRate = 128;
    int Count = 0;
    bool FirstTime = true;
    public int heartRate;
    public int heartRateValue;
    //public string dataGSR;

    float levelTime;
    public static float lastChanged;
    public Text info;


    //The index of the signals originating from ShimmerBluetooth 

    int IndexGSR;
    int IndexPPG;
    Double SCL;
    int IndexTimeStamp;
    int dataGSR;
    public double gsr;
    public double ppg;
    public double ts;
    public int hr;    
    public string gsr_ts;
    public string ppg_ts;
    public string hr_ts;
    public List<double> gsrList = new List<double>();
    public List<double> ppgList = new List<double>();
    public List<double> tsList = new List<double>();
    public List<int> hrList = new List<int>();    
    public List<string> gsrList_ts = new List<string>();
    public List<string> ppgList_ts = new List<string>();
    public List<string> hrList_ts = new List<string>();

    int stage;

    private float time1;
    private float timer;
    private float lookDownTime;

    private float yLoc;
    private float camDir;

    //reference to logger
    private LogStart logger;


    void Start()

    {
        /*
       logger = GameObject.Find("Log").GetComponent<LogStart>();
       Debug.Log("Logging System is active");

        if (logger == null)
        {
            Debug.Log(" Unable to set reference to Logging System.");
        }
        */
        PPGtoHeartRateCalculation = new PPGToHRAlgorithm(SamplingRate, NumberOfHeartBeatsToAverage, TrainingPeriodPPG);
        LPF_PPG = new Filter(Filter.LOW_PASS, SamplingRate, new double[] { LPF_CORNER_FREQ_HZ });
        HPF_PPG = new Filter(Filter.HIGH_PASS, SamplingRate, new double[] { HPF_CORNER_FREQ_HZ });


        int enabledSensors = ((int)ShimmerBluetooth.SensorBitmapShimmer3.SENSOR_GSR | (int)ShimmerBluetooth.SensorBitmapShimmer3.SENSOR_INT_A13);
        Shimmer = new ShimmerLogAndStreamSystemSerialPort("Shimmer3-D38B 'RNI-SPP'", "COM10", SamplingRate, 0, ShimmerBluetooth.GSR_RANGE_AUTO, enabledSensors, false, false, false, 1, 0, Shimmer3Configuration.EXG_EMG_CONFIGURATION_CHIP1, Shimmer3Configuration.EXG_EMG_CONFIGURATION_CHIP2, true);
        Shimmer.UICallback += this.OneFunc;
        Shimmer.Connect();


        //print(Input.GetJoystickNames()[0] + " connected.");
        //timer = 1f;

        //logger.WriteBioHeaders("time, SCL, HR, stage");

        //StartCoroutine(nameof(UpdateTime));

    }
    void Update()
    {
        //timer -= Time.deltaTime;
        time1 = Time.realtimeSinceStartup;
    }
    //IEnumerator UpdateTime()
    //{
        //yield return new WaitForSeconds(0);
        //time1 = Time.realtimeSinceStartup;
        //levelTime = time1 - lastChanged;
    //}

    void OnApplicationQuit()
    {
        Shimmer.StopStreaming();
        Shimmer.Disconnect();
        StopAllCoroutines();
    }
    /*
    void OnApplicationPause()
    {
        Shimmer.StopStreaming();
        Shimmer.Disconnect();
        StopAllCoroutines();
    }
    */

    public void OneFunc(object sender, EventArgs args)
    {
        DateTime now = DateTime.Now;
        CustomEventArgs eventArgs = (CustomEventArgs)args;
        int indicator = eventArgs.getIndicator();

        switch (indicator)
        {
            case (int)ShimmerBluetooth.ShimmerIdentifier.MSG_IDENTIFIER_STATE_CHANGE:
                System.Diagnostics.Debug.Write(((ShimmerBluetooth)sender).GetDeviceName() + " State = " + ((ShimmerBluetooth)sender).GetStateString() + System.Environment.NewLine);
                int state = (int)eventArgs.getObject();
                if (state == (int)ShimmerBluetooth.SHIMMER_STATE_CONNECTED)
                {
                    Debug.Log("Shimmer is Connected");

                }
                else if (state == (int)ShimmerBluetooth.SHIMMER_STATE_CONNECTING)
                {
                    Debug.Log("Establishing Connection to Shimmer Device");
                }
                else if (state == (int)ShimmerBluetooth.SHIMMER_STATE_NONE)
                {
                    Debug.Log("Shimmer is Disconnected");
                }
                else if (state == (int)ShimmerBluetooth.SHIMMER_STATE_STREAMING)
                {
                    Debug.Log("Shimmer is Streaming");
                }
                break;
            case (int)ShimmerBluetooth.ShimmerIdentifier.MSG_IDENTIFIER_NOTIFICATION_MESSAGE:
                break;
            case (int)ShimmerBluetooth.ShimmerIdentifier.MSG_IDENTIFIER_DATA_PACKET:
                ObjectCluster objectCluster = (ObjectCluster)eventArgs.getObject();
                if (FirstTime)
                {

                    IndexGSR = objectCluster.GetIndex(Shimmer3Configuration.SignalNames.GSR, ShimmerConfiguration.SignalFormats.CAL);
                    IndexPPG = objectCluster.GetIndex(Shimmer3Configuration.SignalNames.INTERNAL_ADC_A13, ShimmerConfiguration.SignalFormats.CAL);
                    IndexTimeStamp = objectCluster.GetIndex(ShimmerConfiguration.SignalNames.SYSTEM_TIMESTAMP, ShimmerConfiguration.SignalFormats.CAL);
                    FirstTime = false;
                }

                SensorData dataGSR = objectCluster.GetData(IndexGSR);
                SensorData dataPPG = objectCluster.GetData(IndexPPG);
                SensorData dataTS = objectCluster.GetData(IndexTimeStamp);
                //dataGSR = dataGSR.Data;


                //Process PPG signal and calculate heart rate
                double dataFilteredLP = LPF_PPG.filterData(dataPPG.Data);
                double dataFilteredHP = HPF_PPG.filterData(dataFilteredLP);
                heartRate = (int)PPGtoHeartRateCalculation.ppgToHrConversion(dataFilteredHP, dataTS.Data);
                if (heartRate > 2)
                {
                    heartRateValue = heartRate;
                    hr = (int)heartRateValue;
                    hrList.Add(hr);
                    hr_ts = now.ToString("yyyyMMddHHmmssfff");
                    hrList_ts.Add(hr_ts);
                }
                gsr = (double)dataGSR.Data;
                gsrList.Add(gsr);
                gsr_ts = now.ToString("yyyyMMddHHmmssfff");
                gsrList_ts.Add(hr_ts);
                ppg = (double)dataPPG.Data;
                ppgList.Add(ppg);
                ppg_ts = now.ToString("yyyyMMddHHmmssfff");
                ppgList_ts.Add(hr_ts);
                ts = (double)dataTS.Data;
                tsList.Add(ts);

                if (Count % SamplingRate == 0) //only display data every second
                {
                    //Debug.Log(heartRate);
                    //var expType = SceneManager.GetActiveScene().name;
                    //var expLevel = (UIManager.expLevel).ToString();

                    //if (expType == "_preload" || expType == "Stroop" || expType == "Nature")
                    //{
                    //    expType = "N/A";
                    //    expLevel = "N/A";

                    ////}

                    //info.text = "User anxiety level: \n \t Current: Mild \n \t Average(minute) : None \n Elapsed time: \n \t Total: " + 
                    //    TimeSpan.FromSeconds(time1).ToString(@"hh\:mm\:ss") + 
                    //    " \n \t Current level: " + TimeSpan.FromSeconds(levelTime).ToString(@"hh\:mm\:ss") + 
                    //    "\n Current Exposure: \n \t Type: " + expType + "\n \t Level: " + expLevel;

                    SCL = (1000 / dataGSR.Data);
                   /* Debug.Log("Time Stamp: " + dataTS.Data + ", Theta waves = " + theta +
                               ", Delta waves = " + delta + ", lowAlpha waves = " + lowAlpha +
                               ", highAlpha waves = " + highAlpha + ", lowBeta waves = " + lowBeta +
                               ", highBeta waves = " + highBeta + ", lowGamma waves = " + lowGamma +
                               ", highGamma waves = " + highGamma + , GSR: " + dataGSR.Data + " " + dataGSR.Unit +
                               ", PPG: " + dataPPG.Data + " " + dataPPG.Unit + " HR: " + heartRateValue + " BPM " +
                               ", stage: " + stage);
                    */

                    
                    //logger.WriteBioToLog(time1, /*lowAlpha, highAlpha, lowBeta, highBeta, delta, theta, lowGamma, highGamma, */SCL, heartRate, stage);
                }
                Count++;
                break;
        }
        Shimmer.StartStreaming();

    }

}
