using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowEffect : MonoBehaviour
{
    public GameObject[] popUp;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            popUp[0].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            popUp[1].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            popUp[2].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.F4))
        {
            popUp[3].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.F5))
        {
            popUp[4].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.F6))
        {
            popUp[5].SetActive(true);
        }
    }
}
