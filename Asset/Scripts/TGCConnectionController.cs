using MindWave.LitJson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

namespace MindWave
{
    public class TGCConnectionController : MonoBehaviour
    {
        private TcpClient client;
        private Stream stream;
        private byte[] buffer;

        public delegate void UpdateIntValueDelegate(int value);

        public delegate void UpdateFloatValueDelegate(float value);

        public event UpdateIntValueDelegate UpdatePoorSignalEvent;
        public event UpdateIntValueDelegate UpdateAttentionEvent;
        public event UpdateIntValueDelegate UpdateMeditationEvent;
        public event UpdateIntValueDelegate UpdateRawdataEvent;
        public event UpdateIntValueDelegate UpdateBlinkEvent;

        public event UpdateFloatValueDelegate UpdateDeltaEvent;
        public event UpdateFloatValueDelegate UpdateThetaEvent;
        public event UpdateFloatValueDelegate UpdateLowAlphaEvent;
        public event UpdateFloatValueDelegate UpdateHighAlphaEvent;
        public event UpdateFloatValueDelegate UpdateLowBetaEvent;
        public event UpdateFloatValueDelegate UpdateHighBetaEvent;
        public event UpdateFloatValueDelegate UpdateLowGammaEvent;
        public event UpdateFloatValueDelegate UpdateHighGammaEvent;

        private bool m_waitForExit = true;


        public int Attention;
        public int Meditation;
        public int Delta;
        public int Theta;
        public int lowAlpha;
        public int highAlpha;
        public int lowBeta;
        public int highBeta;
        public int lowGamma;
        public int highGamma;

        public string Attention_ts;
        public string Meditation_ts;
        public string Delta_ts;
        public string Theta_ts;
        public string lowAlpha_ts;
        public string highAlpha_ts;
        public string lowBeta_ts;
        public string highBeta_ts;
        public string lowGamma_ts;
        public string highGamma_ts;

        public List<int> AttentionList = new List<int>();
        public List<int> MeditationList = new List<int>();
        public List<int> DeltaList = new List<int>();
        public List<int> ThetaList = new List<int>();
        public List<int> lowAlphaList = new List<int>();
        public List<int> highAlphaList = new List<int>(); 
        public List<int> lowBetaList = new List<int>();
        public List<int> highBetaList = new List<int>();
        public List<int> lowGammaList = new List<int>();
        public List<int> highGammaList = new List<int>();

        public List<long> AttentionList_ts = new List<long>();
        public List<long> MeditationList_ts = new List<long>();
        public List<long> DeltaList_ts = new List<long>();
        public List<long> ThetaList_ts = new List<long>();
        public List<long> lowAlphaList_ts = new List<long>();
        public List<long> highAlphaList_ts = new List<long>(); 
        public List<long> lowBetaList_ts = new List<long>();
        public List<long> highBetaList_ts = new List<long>();
        public List<long> lowGammaList_ts = new List<long>();
        public List<long> highGammaList_ts = new List<long>();

        private void Start()
        {
            ThreadStart ts = new ThreadStart(Connect);
            Thread thread = new Thread(ts);
            thread.Start();
        }

        public void Disconnect()
        {
            stream.Close();
        }

        public void Connect()
        {
            client = new TcpClient("127.0.0.1", 13854);
            stream = client.GetStream();
            buffer = new byte[1024];
            byte[] myWriteBuffer = Encoding.ASCII.GetBytes(@"{""enableRawOutput"": true, ""format"": ""Json""}");
            stream.Write(myWriteBuffer, 0, myWriteBuffer.Length);

            while (m_waitForExit)
            {
                ParseData();
                Thread.Sleep(100);
            }
        }

        public class PowerData
        {
            public float delta = 0;
            public float theta = 0;
            public float lowAlpha = 0;
            public float highAlpha = 0;
            public float lowBeta = 0;
            public float highBeta = 0;
            public float lowGamma = 0;
            public float highGamma = 0;
            public PowerData()
            {
            }
        }

        public class SenseData
        {
            public int attention = 0;
            public int meditation = 0;
            public PowerData eegPower = null;
            public SenseData()
            {
            }
        }

        public class PackatData
        {
            public string status = string.Empty;
            public int poorSignalLevel = 0;
            public int rawEeg = 0;
            public int blinkStrength = 0;
            public SenseData eSense = null;
            public PackatData()
            {

            }
        }

        int GetObjectCount(String json)
        {
            int level = 0;
            int count = 0;
            for (int i = 0; i < json.Length; ++i)
            {
                if (json[i].Equals('{'))
                {
                    if (level == 0)
                    {
                        ++count;
                    }
                    ++level;
                }
                if (json[i].Equals('}'))
                {
                    --level;
                }
            }
            return count;
        }

        private void ParseData()
        {
            DateTime now = DateTime.Now;
            if (stream.CanRead)
            {
                try
                {
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);

                    List<PackatData> packets = new List<PackatData>();

                    String packet = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    if (!string.IsNullOrEmpty(packet))
                    {
                        //Debug.Log(packet);

                        // Additions
                        // 

                        if (packet.Contains("eSense"))
                        {
                            // Break down the string
                            // Get the values
                            String[] strings = packet.Split("eSense\":{\"");

                            foreach(String s in strings)
                            {
                                if (s.Contains("poorSignalLevel"))
                                {
                                    String[] values = s.Split("},\"poorSignalLevel");
                                    foreach(String e in values)
                                    {
                                        if (e.Contains("attention"))
                                        {
                                            String[] figures = e.Split("},\"eegPower\":{");
                                            foreach (String f in figures)
                                            {
                                                if (f.Contains(","))
                                                {
                                                    String[] numbers = f.Split(",");
                                                    foreach (String n in numbers)
                                                    {
                                                        //Debug.Log(n);
                                                        if (n.Contains(":"))
                                                        {
                                                            if (n.Length < 2) break;

                                                            String[] signals = n.Split(":");
                                                            //Debug.Log(signals[1]);
                                                            //Debug.Log(signals[0] + ", " + signals[1]);

                                                            // convert to number
                                                            int num = int.Parse(signals[1]);

                                                            if (signals[0].Contains("attention"))
                                                            {
                                                                Attention = num;
                                                                AttentionList.Add(Attention);
                                                                Attention_ts = now.ToString("yyyyMMddHHmmssfff");
                                                                AttentionList_ts.Add(Int64.Parse(Attention_ts));
                                                            }
                                                            else if (signals[0].Contains("meditation"))
                                                            {
                                                                Meditation = num;
                                                                MeditationList.Add(Meditation);
                                                                Meditation_ts = now.ToString("yyyyMMddHHmmsfff");
                                                                MeditationList_ts.Add(Int64.Parse(Meditation_ts));
                                                            }
                                                            else if( signals[0].Contains("delta"))
                                                            {
                                                                Delta = num;
                                                                DeltaList.Add(Delta);
                                                                Delta_ts = now.ToString("yyyyMMddHHmmssfff");
                                                                DeltaList_ts.Add(Int64.Parse(Delta_ts));
                                                            }
                                                            else if (signals[0].Contains("theta"))
                                                            {
                                                                Theta = num;
                                                                ThetaList.Add(Theta);
                                                                Theta_ts = now.ToString("yyyyMMddHHmmssfff");
                                                                ThetaList_ts.Add(Int64.Parse(Theta_ts));
                                                            }
                                                            else if (signals[0].Contains("lowAlpha"))
                                                            {
                                                                lowAlpha = num;
                                                                lowAlphaList.Add(lowAlpha);
                                                                lowAlpha_ts = now.ToString("yyyyMMddHHmmssfff");
                                                                lowAlphaList_ts.Add(Int64.Parse(lowAlpha_ts));
                                                            }
                                                            else if (signals[0].Contains("highAlpha"))
                                                            {
                                                                highAlpha = num;
                                                                highAlphaList.Add(highAlpha);
                                                                highAlpha_ts = now.ToString("yyyyMMddHHmmssfff");
                                                                highAlphaList_ts.Add(Int64.Parse(highAlpha_ts));
                                                            }
                                                            else if (signals[0].Contains("lowBeta"))
                                                            {
                                                                lowBeta = num;
                                                                lowBetaList.Add(lowBeta);
                                                                lowBeta_ts = now.ToString("yyyyMMddHHmmssfff");
                                                                lowBetaList_ts.Add(Int64.Parse(lowBeta_ts));
                                                            }
                                                            else if (signals[0].Contains("highBeta"))
                                                            {
                                                                highBeta = num;
                                                                highBetaList.Add(highBeta);
                                                                highBeta_ts = now.ToString("yyyyMMddHHmmssfff");
                                                                highBetaList_ts.Add(Int64.Parse(highBeta_ts));
                                                            }
                                                            else if (signals[0].Contains("lowGamma"))
                                                            {
                                                                lowGamma = num;
                                                                lowGammaList.Add(lowGamma);
                                                                lowGamma_ts = now.ToString("yyyyMMddHHmmssfff");
                                                                lowGammaList_ts.Add(Int64.Parse(lowGamma_ts));
                                                            }
                                                            else if (signals[0].Contains("highGamma"))
                                                            {
                                                                highGamma = num;
                                                                highGammaList.Add(highGamma);
                                                                highGamma_ts = now.ToString("yyyyMMddHHmmssfff");
                                                                highGammaList_ts.Add(Int64.Parse(highGamma_ts));
                                                            }
                                                            
                                                        }
                                                                                                           
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        //Debug.Log("Attention = " + Attention + "%  |  Meditation = " + Meditation + "%");


                        if (packet.Contains("}"))
                        {
                            int count = GetObjectCount(packet);
                            if (count == 1)
                            {
                                PackatData data = JsonMapper.ToObject<PackatData>(packet);
                                packets.Add(data);
                            }
                            else if (count > 1)
                            {
                                // Billys code

                                String[] strings = packet.Split("}");

                                foreach(String s in strings)
                                {
                                    String[] s2 = s.Split("{\"rawEeg\":");

                                    if (s2.Length > 1)
                                    {
                                        string rawEEGString = s2[1];
                                        rawEEGString = rawEEGString.Trim();


                                        int outEeg = int.Parse(rawEEGString);

                                        PackatData pd = new PackatData();
                                        pd.rawEeg = outEeg;

                                        packets.Add(pd);

                                    }
                                }

                                /*
                                PackatData[] data = JsonMapper.ToObject<PackatData[]>(packet);
                                Debug.Log("HERE");
                                for (int index = 0; index < data.Length; ++index)
                                {
                                    Debug.Log(data[index]);
                                    packets.Add(data[index]);
                                }
                                */

                            }
                        }
                    }

                    foreach (PackatData data in packets)
                    {
                        if (null == data)
                        {
                            continue;
                        }
                        if (data.poorSignalLevel != 0)
                        {
                            //Debug.Log("data.poorSignalLevel: " + data.poorSignalLevel);
                            if (null != UpdatePoorSignalEvent)
                            {
                                UpdatePoorSignalEvent.Invoke(data.poorSignalLevel);
                            }

                            if (null != data.eSense)
                            {
                                if (UpdateAttentionEvent != null)
                                {
                                    UpdateAttentionEvent(data.eSense.attention);
                                }
                                if (UpdateMeditationEvent != null)
                                {
                                    UpdateMeditationEvent(data.eSense.meditation);
                                }

                                if (null != data.eSense.eegPower)
                                {
                                    if (UpdateDeltaEvent != null)
                                    {
                                        Debug.Log(packets.Count);
                                        UpdateDeltaEvent(data.eSense.eegPower.delta);
                                    }
                                    if (UpdateThetaEvent != null)
                                    {
                                        UpdateThetaEvent(data.eSense.eegPower.theta);
                                    }
                                    if (UpdateLowAlphaEvent != null)
                                    {
                                        UpdateLowAlphaEvent(data.eSense.eegPower.lowAlpha);
                                    }
                                    if (UpdateHighAlphaEvent != null)
                                    {
                                        UpdateHighAlphaEvent(data.eSense.eegPower.highAlpha);
                                    }
                                    if (UpdateLowBetaEvent != null)
                                    {
                                        UpdateLowBetaEvent(data.eSense.eegPower.lowBeta);
                                    }
                                    if (UpdateHighBetaEvent != null)
                                    {
                                        UpdateHighBetaEvent(data.eSense.eegPower.highBeta);
                                    }
                                    if (UpdateLowGammaEvent != null)
                                    {
                                        UpdateLowGammaEvent(data.eSense.eegPower.lowGamma);
                                    }
                                    if (UpdateHighGammaEvent != null)
                                    {
                                        UpdateHighGammaEvent(data.eSense.eegPower.highGamma);
                                    }
                                }


                            }

                            else if (data.rawEeg != 0)
                            {
                                Debug.Log(data.rawEeg);
                                if (null != UpdateRawdataEvent)
                                {
                                    UpdateRawdataEvent(data.rawEeg);
                                }
                            }
                            else if (data.blinkStrength != 0)
                            {
                                if (null != UpdateRawdataEvent)
                                {
                                    UpdateBlinkEvent(data.blinkStrength);
                                }
                            }
                        }
                    }
                }
                catch (IOException e)
                {
                    Debug.Log("IOException " + e);
                }
                catch (System.Exception e)
                {
                    Debug.Log("Exception " + e);
                }
            }
            
        } // end ParseData


        void OnDisable()
        {
            m_waitForExit = false;
            Disconnect();
        }

        private void OnApplicationQuit()
        {
            m_waitForExit = false;
            Disconnect();
        }


    }
}