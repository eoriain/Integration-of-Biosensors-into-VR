using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("Biosensor_Scene");
    }

    public void TestButton()
    {
        SceneManager.LoadScene("MainScene");
    }
}
