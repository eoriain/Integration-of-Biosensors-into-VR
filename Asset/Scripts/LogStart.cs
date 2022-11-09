/*
 * LoggingSystem.cs
 *
 * Project: Log2CSV - Simple Logging System for Unity applications
 *
 * Supported Unity version: 5.4.1f1 Personal (tested)
 *
 * Author: Nico Reski
 * Web: http://reski.nicoversity.com
 * Twitter: @nicoversity
 */

using UnityEngine;
using System.Collections;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MindWave;

public class LogStart : MonoBehaviour
{
    private signalValues controller;
    private bool header;

    // static log file names and formatters
    private static string LOGFILE_DIRECTORY = "BiometricLogFile";
    private static string LOGFILE_NAME_BASE = "_BiodataParticipantNo.csv";
    private static string LOGFILE_NAME_TIME_FORMAT = "yyyy-MM-dd_HH-mm-ss"; // prefix of the logfile, created when application starts (year - month - day - hour - minute - second)

    // logfile reference of the current session
    private string logFile;

    // bool representing whether the logging system should be used or not (set in the Unity Inspector)
    public bool activeLogging;

    /// <summary>
    /// Start this instance.
    /// </summary>
    void Start()
    {
        header = true;
        controller = GameObject.Find("SignalLog").GetComponent<signalValues>();
        if (this.activeLogging)
        {
            // check if directory exists (and create it if not)
            if (!Directory.Exists(LOGFILE_DIRECTORY)) Directory.CreateDirectory(LOGFILE_DIRECTORY);

            // create file for this session using time prefix based on standard UTC time
            this.logFile = LOGFILE_DIRECTORY
                + "/"
                + System.DateTime.UtcNow.ToString(LOGFILE_NAME_TIME_FORMAT)
                //+ System.DateTime.UtcNow.AddHours(2.0).ToString(LOGFILE_NAME_TIME_FORMAT)	// manually adjust time zone, e.g. + 2 UTC hours for summer time in location Stockholm/Sweden
                + LOGFILE_NAME_BASE;
            File.Create(this.logFile);
            
            if (File.Exists(this.logFile)) Debug.Log("[LoggingSystem] LogFile created at " + this.logFile);
            else Debug.LogError("[LoggingSystem] Error creating LogFile");
        }
    }

    void Update()
    {
        TextWriter tw = new StreamWriter(this.logFile, true);

        if (header == true)
        {    
            tw.WriteLine("Timestamp, Stress %, Concentration %, Relax %, Attention, Meditation, Delta, Theta, lowAlpha, highAlpha, lowBeta, highBeta, lowGamma, highGamma, Shimmergsr, ShimmerPPG, ShimmerHR, EmpaticaHR, EmpaticaTempurature, EmpaticaGSR, EmpaticaBVP, EmpaticaIBI, PressGo, PressExit, 1KGPickedUp, 1KGPlaced, BoulderPickedUp, BoulderPlaced");
            tw.WriteLine(controller.valueToBeLogged);
            header = false;
        }
        tw.WriteLine(controller.valueToBeLogged);
        tw.Close();
    }

}