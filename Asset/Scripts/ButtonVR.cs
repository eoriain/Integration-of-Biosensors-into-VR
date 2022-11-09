using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ButtonVR : MonoBehaviour
{
    private signalBaselineValues controller;

    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    GameObject presser;
    AudioSource sound;
    bool isPressed;
    public string testString;
    public string StartTS;
    public long StartTSInt;
    public string StartValue;
    public string ExitTS;
    public string ExitValue;

    void Start()
    {
        controller = GameObject.Find("SignalBaselines").GetComponent<signalBaselineValues>();
        sound = GetComponent<AudioSource>();
        isPressed = false;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed)
        {
            button.transform.localPosition = new Vector3(0, 0.003f, 0);
            presser = other.gameObject;
            onPress.Invoke();
            sound.Play();
            isPressed = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == presser)
        {
            button.transform.localPosition = new Vector3(0, 0.015f, 0);
            onRelease.Invoke();
            isPressed = false;
        }
    }

    public void EmergencyExit()
    {        
        DateTime now = DateTime.Now;
        ExitTS = now.ToString("yyyyMMddHHmmssf");
        ExitValue = "User selected Emergency Exit";
        System.Threading.Thread.Sleep(500);
        SceneManager.LoadScene("Forest");

    }
    public void Restart()
    {
        DateTime now = DateTime.Now;
        ExitTS = now.ToString("yyyyMMddHHmmssf");
        ExitValue = "User has restarted";
        System.Threading.Thread.Sleep(500);
        SceneManager.LoadScene("Biosensor_Scene");
    }    
    public void TestButton()
    {
        GameObject.Find("GJCube").SetActive(false);
        GameObject.Find("GJCube (1)").SetActive(false);
    }    
    public void PressMeButton()
    {
        GameObject intro = GameObject.Find("IntroInstructionsCanvas");
        intro.transform.localPosition = new Vector3(-3.011f, 2.584f, 0.178f);
    }    
    public void ContinueButton()
    {
        GameObject.Find("WallToStepOne").SetActive(false);
        GameObject.Find("IntroInstructionsCanvas").SetActive(false);
        GameObject ProceedToStepOne = GameObject.Find("ProceedToStepOneCanvas");
        ProceedToStepOne.transform.localPosition = new Vector3(-3.011f, 2.584f, 0.178f);
        //GameObject.Find("WallToStepOne").GetComponent<BoxCollider>().enabled = false;
    }    
    public void StartButton()
    {
        DateTime now = DateTime.Now;
        StartTS = now.ToString("yyyyMMddHHmmssf");
        StartValue = "Baseline Establish - Test Commencing";
        StartTSInt = Int64.Parse(StartTS);

        GameObject.Find("IntroductionArea").SetActive(false);

    }
    public void StepOneButton()
    {
        GameObject.Find("Step_Intro").SetActive(false);
        GameObject.Find("GestureArea").SetActive(false);
        GameObject Proceed = GameObject.Find("MoveToStepTwo");
        Proceed.transform.localPosition = new Vector3(-1.774f, 2.937f, -4.733f);
    }    
    public void OneButton()
    {

    }
    public void TwoButton()
    {

    }
    public void ThreeButton()
    {

    }
    public void FourButton()
    {

    }
    public void FiveButton()
    {

    }
    public void SixButton()
    {

    }
    public void SevenButton()
    {

    }
    public void EightButton()
    {

    }
    public void NineButton()
    {
        GameObject introPlank = GameObject.Find("IntroPlank");
        introPlank.transform.localPosition = new Vector3(-3.244f, 0.73f, 0.038999f);
        GameObject.Find("StepFourBlock").SetActive(false);
        GameObject.Find("StepTwoInstructions").SetActive(false);
        GameObject.Find("MoveToStepTwo").SetActive(false);
    }

}
