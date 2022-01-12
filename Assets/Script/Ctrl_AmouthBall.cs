using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ctrl_AmouthBall : MonoBehaviour
{
    private int amouthBall = 500;
    public Text textAmouthBall;
    private string codeSave = "amouthBall";

    public bool testAmouthBall = false;

    public bool testRowtoBall_Excusive = false;
    public bool testRowtoBall_Normal = false;
    public bool testRowtoBall_Badly = false;
    public bool testJackPot = false;

    private void Start()
    {
        amouthBall = PlayerPrefs.GetInt(codeSave,amouthBall);
    }
    private void Update()
    {
        textAmouthBall.text = amouthBall.ToString();
        if (testAmouthBall)
        {
            testAmouthBall = false;
            amouthBall -= 1;
            PlayerPrefs.SetInt(codeSave, amouthBall);
        }

        if (testJackPot)
        {
            testJackPot = false;
            amouthBall += 500;
            PlayerPrefs.SetInt(codeSave, amouthBall);
        }
        if (testRowtoBall_Excusive)
        {
            testRowtoBall_Excusive = false;
            amouthBall += 100;
            PlayerPrefs.SetInt(codeSave, amouthBall);
        }

        if (testRowtoBall_Normal)
        {
            testRowtoBall_Normal = false;
            amouthBall += 50;
            PlayerPrefs.SetInt(codeSave, amouthBall);
        }
        if (testRowtoBall_Badly)
        {
            testRowtoBall_Badly = false;
            amouthBall += 10;
            PlayerPrefs.SetInt(codeSave, amouthBall);

        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            PlayerPrefs.DeleteAll();
        }

    }
}
