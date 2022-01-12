using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public Ctrl_AmouthBall ctrl_Amouth;

    public bool spinRow = false;
    public bool checkFirstSpinRow = false;

    public static event Action HandlePulled = delegate { };

    [SerializeField]
    private Ctrl_Row[] row;

    private bool resultsChecked = false;

    public bool playParticleDoor_1st = false;
    public bool playParticleDoor_2rd = false;
    public bool playParticleDoor_3nd = false;

    public bool checkPoint_1 = false;
    public bool checkPoint_2 = false;
    public bool checkPoint_3 = false;
    public bool perfect_3 = false;

    public GameObject[] popUp;

    private void Start()
    {
        checkFirstSpinRow = false;
    }
    private void Update()
    {
        if (checkPoint_1)
        {
            checkPoint_1 = false;
            StartCoroutine(ShowAndClosePopUp10(2f));
            ctrl_Amouth.testRowtoBall_Badly = true;
        }
        if (checkPoint_2)
        {
            checkPoint_2 = false;
            StartCoroutine(ShowAndClosePopUp10(2f));
            ctrl_Amouth.testRowtoBall_Badly = true;
        }
        if (checkPoint_3)
        {
            checkPoint_3 = false;
            StartCoroutine(ShowAndClosePopUp10(2f));
            ctrl_Amouth.testRowtoBall_Badly = true;

        }
        if (perfect_3)
        {
            perfect_3 = false;
            StartCoroutine(ShowAndClosePopUpPerfect(2f));
            ctrl_Amouth.testJackPot = true;
        }

        if (!row[0].rowStopped || !row[1].rowStopped || !row[2].rowStopped)
        {
            resultsChecked = false;
        }
        if (row[2].rowStopped && !resultsChecked)
        {
            CheckResults();
        }
        if (Input.GetKeyDown(KeyCode.Space) || spinRow)
        {
            spinRow = true;
            if (row[0].rowStopped && row[1].rowStopped && row[2].rowStopped)
            {
                StartCoroutine("PullHadle");
                spinRow = false;

            }
        }
    }

    IEnumerator PullHadle()
    {
        for (int i = 0; i < 15; i += 5)
        {
            yield return new WaitForSeconds(0.1f);
        }
        HandlePulled();
        for (int i = 0; i < 15; i += 5)
        {
            yield return new WaitForSeconds(0.1f);
        }

    }
    void CheckResults()
    {
        if (row[0].stoppedSlot == "1" && row[1].stoppedSlot == "1" && row[2].stoppedSlot == "1")
        {
            Debug.Log("ETC I");
            ctrl_Amouth.testRowtoBall_Excusive = true;
            StartCoroutine(ShowAndClosePopUpJackPot(2f));
        }
        else if (row[0].stoppedSlot == "2" && row[1].stoppedSlot == "2" && row[2].stoppedSlot == "2")
        {
            Debug.Log("ETC II");
            ctrl_Amouth.testRowtoBall_Excusive = true;
            StartCoroutine(ShowAndClosePopUpJackPot(2f));
        }
        else if (row[0].stoppedSlot == "3" && row[1].stoppedSlot == "3" && row[2].stoppedSlot == "3")
        {
            Debug.Log("ETC III");
            ctrl_Amouth.testRowtoBall_Excusive = true;
            StartCoroutine(ShowAndClosePopUpJackPot(2f));
        }
        else if (row[0].stoppedSlot == "4" && row[1].stoppedSlot == "4" && row[2].stoppedSlot == "4")
        {
            Debug.Log("ETC IV");
            ctrl_Amouth.testRowtoBall_Excusive = true;
            StartCoroutine(ShowAndClosePopUpJackPot(2f));
        }
        else if (row[0].stoppedSlot == "5" && row[1].stoppedSlot == "5" && row[2].stoppedSlot == "5")
        {
            Debug.Log("ETC V");
            ctrl_Amouth.testRowtoBall_Excusive = true;
            StartCoroutine(ShowAndClosePopUpJackPot(2f));
        }
        else if (row[0].stoppedSlot == "6" && row[1].stoppedSlot == "6" && row[2].stoppedSlot == "6")
        {
            Debug.Log("ETC VI");
            ctrl_Amouth.testRowtoBall_Excusive = true;
            StartCoroutine(ShowAndClosePopUpJackPot(2f));
        }
        else if (row[0].stoppedSlot == "7" && row[1].stoppedSlot == "7" && row[2].stoppedSlot == "7")
        {
            Debug.Log("ETC VII");
            ctrl_Amouth.testRowtoBall_Excusive = true;
            StartCoroutine(ShowAndClosePopUpJackPot(2f));
        }
        else if (row[0].stoppedSlot == "8" && row[1].stoppedSlot == "8" && row[2].stoppedSlot == "8")
        {
            Debug.Log("ETC VIII");
            ctrl_Amouth.testRowtoBall_Excusive = true;
            StartCoroutine(ShowAndClosePopUpJackPot(2f));
        }
        else if (row[0].stoppedSlot == "9" && row[1].stoppedSlot == "9" && row[2].stoppedSlot == "9")
        {
            Debug.Log("ETC VIIII");
            ctrl_Amouth.testRowtoBall_Excusive = true;
            StartCoroutine(ShowAndClosePopUpJackPot(2f));
        }

        else if (row[0].stoppedSlot == "1" && row[1].stoppedSlot == "1")
        {
            Debug.Log("(1) Normal [0] - [1]");
            ctrl_Amouth.testRowtoBall_Normal = true;
            StartCoroutine(ShowAndClosePopUp50(2f));
        }
        else if (row[0].stoppedSlot == "1" && row[2].stoppedSlot == "1")
        {
            Debug.Log("(1) Normal [0] - [2]");
            ctrl_Amouth.testRowtoBall_Normal = true;
            StartCoroutine(ShowAndClosePopUp50(2f));
        }
        else if (row[1].stoppedSlot == "1" && row[2].stoppedSlot == "1")
        {
            Debug.Log("(1) Normal [1] - [2]");
            ctrl_Amouth.testRowtoBall_Normal = true;
            StartCoroutine(ShowAndClosePopUp50(2f));
        }

        else if (row[0].stoppedSlot == "2" && row[1].stoppedSlot == "2")
        {
            Debug.Log("(2) Normal [0] - [1]");
            ctrl_Amouth.testRowtoBall_Normal = true;
            StartCoroutine(ShowAndClosePopUp50(2f));
        }
        else if (row[0].stoppedSlot == "2" && row[2].stoppedSlot == "2")
        {
            Debug.Log("(2) Normal [0] - [2]");
            ctrl_Amouth.testRowtoBall_Normal = true;
            StartCoroutine(ShowAndClosePopUp50(2f));
        }
        else if (row[1].stoppedSlot == "2" && row[2].stoppedSlot == "2")
        {
            Debug.Log("(2) Normal [1] - [2]");
            ctrl_Amouth.testRowtoBall_Normal = true;
            StartCoroutine(ShowAndClosePopUp50(2f));
        }

        else if (row[0].stoppedSlot == "3" && row[1].stoppedSlot == "3")
        {
            Debug.Log("(3) Normal [0] - [1]");
            ctrl_Amouth.testRowtoBall_Normal = true;
            StartCoroutine(ShowAndClosePopUp50(2f));
        }
        else if (row[0].stoppedSlot == "3" && row[2].stoppedSlot == "3")
        {
            Debug.Log("(3) Normal [0] - [2]");
            ctrl_Amouth.testRowtoBall_Normal = true;
            StartCoroutine(ShowAndClosePopUp50(2f));
        }
        else if (row[1].stoppedSlot == "3" && row[2].stoppedSlot == "3")
        {
            Debug.Log("(3) Normal [1] - [2]");
            ctrl_Amouth.testRowtoBall_Normal = true;
            StartCoroutine(ShowAndClosePopUp50(2f));
        }

        else if (row[0].stoppedSlot == "4" && row[1].stoppedSlot == "4")
        {
            Debug.Log("(4) Normal [0] - [1]");
            ctrl_Amouth.testRowtoBall_Normal = true;
            StartCoroutine(ShowAndClosePopUp50(2f));
        }
        else if (row[0].stoppedSlot == "4" && row[2].stoppedSlot == "4")
        {
            Debug.Log("(4) Normal [0] - [2]");
            ctrl_Amouth.testRowtoBall_Normal = true;
            StartCoroutine(ShowAndClosePopUp50(2f));
        }
        else if (row[1].stoppedSlot == "4" && row[2].stoppedSlot == "4")
        {
            Debug.Log("(4) Normal [1] - [2]");
            ctrl_Amouth.testRowtoBall_Normal = true;
            StartCoroutine(ShowAndClosePopUp50(2f));
        }

        else if (row[0].stoppedSlot == "5" && row[1].stoppedSlot == "5")
        {
            Debug.Log("(5) Normal [0] - [1]");
            ctrl_Amouth.testRowtoBall_Normal = true;
            StartCoroutine(ShowAndClosePopUp50(2f));
        }
        else if (row[0].stoppedSlot == "5" && row[2].stoppedSlot == "5")
        {
            Debug.Log("(5) Normal [0] - [2]");
            ctrl_Amouth.testRowtoBall_Normal = true;
            StartCoroutine(ShowAndClosePopUp50(2f));
        }
        else if (row[1].stoppedSlot == "5" && row[2].stoppedSlot == "5")
        {
            Debug.Log("(5) Normal [1] - [2]");
            ctrl_Amouth.testRowtoBall_Normal = true;
            StartCoroutine(ShowAndClosePopUp50(2f));
        }

        else if (row[0].stoppedSlot == "6" && row[1].stoppedSlot == "6")
        {
            Debug.Log("(6) Normal [0] - [1]");
            ctrl_Amouth.testRowtoBall_Normal = true;
            StartCoroutine(ShowAndClosePopUp50(2f));
        }
        else if (row[0].stoppedSlot == "6" && row[2].stoppedSlot == "6")
        {
            Debug.Log("(6) Normal [0] - [2]");
            ctrl_Amouth.testRowtoBall_Normal = true;
            StartCoroutine(ShowAndClosePopUp50(2f));
        }
        else if (row[1].stoppedSlot == "6" && row[2].stoppedSlot == "6")
        {
            Debug.Log("(6) Normal [1] - [2]");
            ctrl_Amouth.testRowtoBall_Normal = true;
            StartCoroutine(ShowAndClosePopUp50(2f));
        }

        else if (row[0].stoppedSlot == "7" && row[1].stoppedSlot == "7")
        {
            Debug.Log("(7) Normal [0] - [1]");
            ctrl_Amouth.testRowtoBall_Normal = true;
            StartCoroutine(ShowAndClosePopUp50(2f));
        }
        else if (row[0].stoppedSlot == "7" && row[2].stoppedSlot == "7")
        {
            Debug.Log("(7) Normal [0] - [2]");
            ctrl_Amouth.testRowtoBall_Normal = true;
            StartCoroutine(ShowAndClosePopUp50(2f));
        }
        else if (row[1].stoppedSlot == "7" && row[2].stoppedSlot == "7")
        {
            Debug.Log("(7) Normal [1] - [2]");
            ctrl_Amouth.testRowtoBall_Normal = true;
            StartCoroutine(ShowAndClosePopUp50(2f));
        }

        else if (row[0].stoppedSlot == "8" && row[1].stoppedSlot == "8")
        {
            Debug.Log("(8) Normal [0] - [1]");
            ctrl_Amouth.testRowtoBall_Normal = true;
            StartCoroutine(ShowAndClosePopUp50(2f));
        }
        else if (row[0].stoppedSlot == "8" && row[2].stoppedSlot == "8")
        {
            Debug.Log("(8) Normal [0] - [2]");
            ctrl_Amouth.testRowtoBall_Normal = true;
            StartCoroutine(ShowAndClosePopUp50(2f));
        }
        else if (row[1].stoppedSlot == "8" && row[2].stoppedSlot == "8")
        {
            Debug.Log("(8) Normal [1] - [2]");
            ctrl_Amouth.testRowtoBall_Normal = true;
            StartCoroutine(ShowAndClosePopUp50(2f));
        }

        else if (row[0].stoppedSlot == "9" && row[1].stoppedSlot == "9")
        {
            Debug.Log("(9) Normal [0] - [1]");
            ctrl_Amouth.testRowtoBall_Normal = true;
            StartCoroutine(ShowAndClosePopUp50(2f));
        }
        else if (row[0].stoppedSlot == "9" && row[2].stoppedSlot == "9")
        {
            Debug.Log("(9) Normal [0] - [2]");
            ctrl_Amouth.testRowtoBall_Normal = true;
            StartCoroutine(ShowAndClosePopUp50(2f));
        }
        else if (row[1].stoppedSlot == "9" && row[2].stoppedSlot == "9")
        {
            Debug.Log("(9) Normal [1] - [2]");
            ctrl_Amouth.testRowtoBall_Normal = true;
            StartCoroutine(ShowAndClosePopUp50(2f));
        }
        else 
        {
            if (checkFirstSpinRow)
            {
                ctrl_Amouth.testRowtoBall_Badly = true;
                StartCoroutine(ShowAndClosePopUp10(2f));
                Debug.Log("Badly");
            }

        }

        resultsChecked = true;

    }

    IEnumerator ShowAndClosePopUp10(float sec)
    {
        popUp[0].SetActive(true);
        yield return new WaitForSeconds(sec);
        popUp[0].SetActive(false);
    }
    IEnumerator ShowAndClosePopUp50(float sec)
    {
        popUp[1].SetActive(true);
        yield return new WaitForSeconds(sec);
        popUp[1].SetActive(false);
    }
    IEnumerator ShowAndClosePopUp100(float sec)
    {
        popUp[2].SetActive(true);
        yield return new WaitForSeconds(sec);
        popUp[2].SetActive(false);
    }
    IEnumerator ShowAndClosePopUpGood(float sec)
    {
        popUp[3].SetActive(true);
        yield return new WaitForSeconds(sec);
        popUp[3].SetActive(false);
    }
    IEnumerator ShowAndClosePopUpJackPot(float sec)
    {
        popUp[4].SetActive(true);
        yield return new WaitForSeconds(sec);
        popUp[4].SetActive(false);
    }
    IEnumerator ShowAndClosePopUpPerfect(float sec)
    {
        popUp[5].SetActive(true);
        yield return new WaitForSeconds(sec);
        popUp[5].SetActive(false);
    }

}
