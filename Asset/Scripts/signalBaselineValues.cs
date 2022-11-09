using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using MindWave;

public class signalBaselineValues : MonoBehaviour
{  
    private TGCConnectionController controller;
    private ButtonVR controller1;
    private ShimmerBiosignals controller2;
    private ICATEmpaticaBLEClient controller3;

    //Myndplay Data
    public int AttentionBaseline;
    string AttentionBaseline_ts;
    List<int> AttentionBaselineList = new List<int>();
    List<long> AttentionBaselineList_ts = new List<long>();
    public int MeditationBaseline;
    string MeditationBaseline_ts;
    List<int> MeditationBaselineList = new List<int>();
    List<long> MeditationBaselineList_ts = new List<long>();
    public int DeltaBaseline;
    string DeltaBaseline_ts;
    List<int> DeltaBaselineList = new List<int>();
    List<long> DeltaBaselineList_ts = new List<long>();
    public int ThetaBaseline;
    string ThetaBaseline_ts;
    List<int> ThetaBaselineList = new List<int>();
    List<long> ThetaBaselineList_ts = new List<long>();
    public int lowAlphaBaseline;
    string lowAlphaBaseline_ts;
    List<int> lowAlphaBaselineList = new List<int>();
    List<long> lowAlphaBaselineList_ts = new List<long>();
    public int highAlphaBaseline;
    string highAlphaBaseline_ts;
    List<int> highAlphaBaselineList = new List<int>();
    List<long> highAlphaBaselineList_ts = new List<long>();
    public int lowBetaBaseline;
    string lowBetaBaseline_ts;
    List<int> lowBetaBaselineList = new List<int>();
    List<long> lowBetaBaselineList_ts = new List<long>();
    public int highBetaBaseline;
    string highBetaBaseline_ts;
    List<int> highBetaBaselineList = new List<int>();
    List<long> highBetaBaselineList_ts = new List<long>();
    public int lowGammaBaseline;
    string lowGammaBaseline_ts;
    List<int> lowGammaBaselineList = new List<int>();
    List<long> lowGammaBaselineList_ts = new List<long>();
    public int highGammaBaseline;
    string highGammaBaseline_ts;
    List<int> highGammaBaselineList = new List<int>();
    List<long> highGammaBaselineList_ts = new List<long>();

    //Shimmer Data
    public double gsrShimmerBaseline;
    string gsrShimmerBaseline_ts;
    List<double> gsrShimmerBaselineList = new List<double>();
    List<long> gsrShimmerBaselineList_ts = new List<long>();
    public double ppgBaseline;
    string ppgBaseline_ts;
    List<double> ppgBaselineList = new List<double>();
    List<long> ppgBaselineList_ts = new List<long>();
    public int hrBaseline;
    string hrBaseline_ts;
    List<int> hrBaselineList = new List<int>();
    List<long> hrBaselineList_ts = new List<long>();

    //Empatica
    public float bpmBaseline;
    string bpmBaseline_ts;
    List<float> bpmBaselineList = new List<float>();
    List<long> bpmBaselineList_ts = new List<long>();
    public float tempBaseline;
    string tempBaseline_ts;
    List<float> tempBaselineList = new List<float>();
    List<long> tempBaselineList_ts = new List<long>();
    public float gsrBaseline;
    string gsrBaseline_ts;
    List<float> gsrBaselineList = new List<float>();
    List<long> gsrBaselineList_ts = new List<long>();
    public float bvpBaseline;
    string bvpBaseline_ts;
    List<float> bvpBaselineList = new List<float>();
    List<long> bvpBaselineList_ts = new List<long>();
    public float ibiBaseline;
    string ibiBaseline_ts;
    List<float> ibiBaselineList = new List<float>();
    List<long> ibiBaselineList_ts = new List<long>();


    public int BaselineMS;
    public long StartTS;

    public double AttentionBaselineAverage;
    public double MeditationBaselineAverage;
    public double DeltaBaselineAverage;
    public double ThetaBaselineAverage;
    public double lowAlphaBaselineAverage;
    public double highAlphaBaselineAverage;
    public double lowBetaBaselineAverage;
    public double highBetaBaselineAverage;
    public double lowGammaBaselineAverage;
    public double highGammaBaselineAverage;
    public double gsrShimmerBaselineAverage;
    public double ppgBaselineAverage;
    public double hrBaselineAverage;
    public double bpmBaselineAverage;
    public double tempBaselineAverage;
    public double gsrBaselineAverage;
    public double bvpBaselineAverage;
    public double ibiBaselineAverage;

    private void Start()
    {
        controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();
        controller1 = GameObject.Find("GoCollider").GetComponent<ButtonVR>();
        controller2 = GameObject.Find("ShimmerObject").GetComponent<ShimmerBiosignals>();
        controller3 = GameObject.Find("EmpaticaE4").GetComponent<ICATEmpaticaBLEClient>();
        BaselineMS = 0;
    }

    void Update()
    {
        DateTime now = DateTime.Now;
        StartTS = controller1.StartTSInt;
        if (StartTS == 0)
        {
            //Myndplay Data Retrieval
            AttentionBaseline = controller.Attention;
            AttentionBaselineList.Add(AttentionBaseline);
            AttentionBaseline_ts = now.ToString("yyyyMMddHHmmssfff");
            AttentionBaselineList_ts.Add(Int64.Parse(AttentionBaseline_ts));

            MeditationBaseline = controller.Meditation;
            MeditationBaselineList.Add(MeditationBaseline);
            MeditationBaseline_ts = now.ToString("yyyyMMddHHmmssfff");
            MeditationBaselineList_ts.Add(Int64.Parse(MeditationBaseline_ts));    
            
            DeltaBaseline = controller.Delta;
            DeltaBaselineList.Add(DeltaBaseline);
            DeltaBaseline_ts = now.ToString("yyyyMMddHHmmssfff");
            DeltaBaselineList_ts.Add(Int64.Parse(DeltaBaseline_ts));

            ThetaBaseline = controller.Theta;
            ThetaBaselineList.Add(ThetaBaseline);
            ThetaBaseline_ts = now.ToString("yyyyMMddHHmmssfff");
            ThetaBaselineList_ts.Add(Int64.Parse(ThetaBaseline_ts));

            lowAlphaBaseline = controller.lowAlpha;
            lowAlphaBaselineList.Add(lowAlphaBaseline);
            lowAlphaBaseline_ts = now.ToString("yyyyMMddHHmmssfff");
            lowAlphaBaselineList_ts.Add(Int64.Parse(lowAlphaBaseline_ts));

            highAlphaBaseline = controller.highAlpha;
            highAlphaBaselineList.Add(highAlphaBaseline);
            highAlphaBaseline_ts = now.ToString("yyyyMMddHHmmssfff");
            highAlphaBaselineList_ts.Add(Int64.Parse(highAlphaBaseline_ts));

            lowBetaBaseline = controller.lowBeta;
            lowBetaBaselineList.Add(lowBetaBaseline);
            lowBetaBaseline_ts = now.ToString("yyyyMMddHHmmssfff");
            lowBetaBaselineList_ts.Add(Int64.Parse(lowBetaBaseline_ts));

            highBetaBaseline = controller.highBeta;
            highBetaBaselineList.Add(highBetaBaseline);
            highBetaBaseline_ts = now.ToString("yyyyMMddHHmmssfff");
            highBetaBaselineList_ts.Add(Int64.Parse(highBetaBaseline_ts));

            lowGammaBaseline = controller.lowGamma;
            lowGammaBaselineList.Add(lowGammaBaseline);
            lowGammaBaseline_ts = now.ToString("yyyyMMddHHmmssfff");
            lowGammaBaselineList_ts.Add(Int64.Parse(lowGammaBaseline_ts));

            highGammaBaseline = controller.highGamma;
            highGammaBaselineList.Add(highGammaBaseline);
            highGammaBaseline_ts = now.ToString("yyyyMMddHHmmssfff");
            highGammaBaselineList_ts.Add(Int64.Parse(highGammaBaseline_ts));

            //Shimmer Data Retrieval
            gsrShimmerBaseline = controller2.gsr;
            gsrShimmerBaselineList.Add(gsrShimmerBaseline);
            gsrShimmerBaseline_ts = now.ToString("yyyyMMddHHmmssfff");
            gsrShimmerBaselineList_ts.Add(Int64.Parse(gsrShimmerBaseline_ts));

            ppgBaseline = controller2.ppg;
            ppgBaselineList.Add(ppgBaseline);
            ppgBaseline_ts = now.ToString("yyyyMMddHHmmssfff");
            ppgBaselineList_ts.Add(Int64.Parse(ppgBaseline_ts));

            hrBaseline = controller2.hr;
            hrBaselineList.Add(hrBaseline);
            hrBaseline_ts = now.ToString("yyyyMMddHHmmssfff");
            hrBaselineList_ts.Add(Int64.Parse(hrBaseline_ts));

            //Empatica Data Retrieval
            bpmBaseline = controller3.bpm;
            bpmBaselineList.Add(bpmBaseline);
            bpmBaseline_ts = now.ToString("yyyyMMddHHmmssfff");
            bpmBaselineList_ts.Add(Int64.Parse(bpmBaseline_ts));

            tempBaseline = controller3.temp;
            tempBaselineList.Add(tempBaseline);
            tempBaseline_ts = now.ToString("yyyyMMddHHmmssfff");
            tempBaselineList_ts.Add(Int64.Parse(tempBaseline_ts));

            gsrBaseline = controller3.gsr;
            gsrBaselineList.Add(gsrBaseline);
            gsrBaseline_ts = now.ToString("yyyyMMddHHmmssfff");
            gsrBaselineList_ts.Add(Int64.Parse(gsrBaseline_ts));

            bvpBaseline = controller3.bvp;
            bvpBaselineList.Add(bvpBaseline);
            bvpBaseline_ts = now.ToString("yyyyMMddHHmmssfff");
            bvpBaselineList_ts.Add(Int64.Parse(bvpBaseline_ts));

            ibiBaseline = controller3.ibi;
            ibiBaselineList.Add(ibiBaseline);
            ibiBaseline_ts = now.ToString("yyyyMMddHHmmssfff");
            ibiBaselineList_ts.Add(Int64.Parse(ibiBaseline_ts));
        }
        else if (StartTS > 0)
        {
            BaselineMS = DeltaBaselineList_ts.Count;

            AttentionBaselineAverage = AttentionBaselineList.Average();
            MeditationBaselineAverage = MeditationBaselineList.Average();
            DeltaBaselineAverage = DeltaBaselineList.Average();
            ThetaBaselineAverage = ThetaBaselineList.Average();
            lowAlphaBaselineAverage = lowAlphaBaselineList.Average();
            highAlphaBaselineAverage = highAlphaBaselineList.Average();
            lowBetaBaselineAverage = lowBetaBaselineList.Average();
            highBetaBaselineAverage = highBetaBaselineList.Average();
            lowGammaBaselineAverage = lowGammaBaselineList.Average();
            highGammaBaselineAverage = highGammaBaselineList.Average();
            gsrShimmerBaselineAverage = gsrBaselineList.Average();
            ppgBaselineAverage = ppgBaselineList.Average();
            hrBaselineAverage = hrBaselineList.Average();
            bpmBaselineAverage = bpmBaselineList.Average();
            tempBaselineAverage = tempBaselineList.Average();
            gsrBaselineAverage = gsrBaselineList.Average();
            bvpBaselineAverage = bvpBaselineList.Average();
            ibiBaselineAverage = ibiBaselineList.Average();
        }

    }
}