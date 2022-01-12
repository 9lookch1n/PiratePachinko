using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ctrl_Row : MonoBehaviour
{
    private int randomValue;
    private float timeInterval;

    public bool rowStopped;
    public string stoppedSlot;

    private void Start()
    {
        rowStopped = true;
        GameManager.HandlePulled += StartRotaing;
    }
    private void StartRotaing()
    {
        stoppedSlot = "";
        StartCoroutine("Rotate");
    }
    IEnumerator Rotate()
    {
        rowStopped = false;
        timeInterval = 0.025f;

        for (int i = 0; i < 29; i++)
        {
            if (transform.position.y <= -0.6f)
            {
                transform.position = new Vector2(transform.position.x, 8.4f);
            }
            transform.position = new Vector2(transform.position.x, transform.position.y - 1f);

            yield return new WaitForSeconds(timeInterval);
        }

        randomValue = Random.Range(50, 100);

        switch (randomValue % 2)
        {
            case 1:
                randomValue += 2;
                break;
            case 2:
                randomValue += 1;
                break;
        }

        for (int i = 0; i < randomValue; i++)
        {
            if (transform.position.y <= -0.6f)
            {
                transform.position = new Vector2(transform.position.x, 8.4f);
            }
            transform.position = new Vector2(transform.position.x, transform.position.y - 1f);

            if (i > Mathf.RoundToInt(randomValue * 0.25f))
            {
                timeInterval = 0.05f;
            }
            if (i > Mathf.RoundToInt(randomValue * 0.5f))
            {
                timeInterval = 0.1f;
            }
            if (i > Mathf.RoundToInt(randomValue * 0.75f))
            {
                timeInterval = 0.15f;
            }
            if (i > Mathf.RoundToInt(randomValue * 0.95f))
            {
                timeInterval = 0.2f;

                yield return new WaitForSeconds(timeInterval);
            }
        }

        if (transform.position.y <= 7.4f && transform.position.y >= 7.3f)
        {
            //2
            stoppedSlot = "2";
        }
        else if (transform.position.y <= 6.4f && transform.position.y >= 6.3f)
        {
            //3
            stoppedSlot = "3";
        }
        else if (transform.position.y <= 5.4f && transform.position.y >= 5.3f)
        {
            //4
            stoppedSlot = "4";
        }
        else if (transform.position.y <= 4.4f && transform.position.y >= 4.3f)
        {
            //5
            stoppedSlot = "5";
        }
        else if (transform.position.y <= 3.4f && transform.position.y >= 3.3f)
        {
            //6
            stoppedSlot = "6";
        }
        else if (transform.position.y <= 2.4f && transform.position.y >= 2.3f)
        {
            //7
            stoppedSlot = "7";
        }
        else if (transform.position.y <= 1.4f && transform.position.y >= 1.3f)
        {
            //8
            stoppedSlot = "8";
        }
        else if (transform.position.y <= 0.4f && transform.position.y >= 0.3f)
        {
            //9
            stoppedSlot = "9";
        }
        else if (transform.position.y <= -0.6f && transform.position.y >= 8.4)
        {
            //1
            stoppedSlot = "1";
        }

        rowStopped = true;

    }
    private void OnDestroy()
    {
        GameManager.HandlePulled -= StartRotaing;
    }
}
