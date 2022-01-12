using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnBall : MonoBehaviour
{
    public Ctrl_AmouthBall ctrl_Amouth;

    public Transform target;

    public Transform spawnPoint;
    public GameObject ball;

    public GameObject powerBarGO;
    public Image PowerBarMask;
    private float barChangeSpeed = 10;
    private float maxPowerBarValue = 360;
    public float currentPowerBarValue;

    public float minX = -1.5f;
    public float maxX = 2f;

    private bool buttonHoldDown = false;
    private bool delayFire = true;
    private bool updateFillAmouth = true;
    public bool useFunction = false;

    private void Start()
    {
        currentPowerBarValue = 0;
    }
    private void Update()
    {
        if (buttonHoldDown)
        {
            UpdatePowerBarUp();
        }
        if (!buttonHoldDown)
        {
            UpdatePowerBarDown();
        }
        if (useFunction)
        {
            Vector2 startPos = new Vector2(minX, 3f);
            target.transform.position = Vector3.MoveTowards(target.transform.position, startPos, 2f * Time.deltaTime);
            if (target.transform.position.x == minX)
            {
                useFunction = false;
            }
        }
    }
    public void UpdatePowerBarUp()
    {
        Fire();
        if (useFunction)
        {
            if (updateFillAmouth)
            {
                currentPowerBarValue += barChangeSpeed;


                float fill = currentPowerBarValue / maxPowerBarValue;
                PowerBarMask.fillAmount = fill;

                if (currentPowerBarValue < 0)
                {
                    float _fill = -currentPowerBarValue / maxPowerBarValue;
                    PowerBarMask.fillAmount = _fill;
                }
            }

            if (currentPowerBarValue >= maxPowerBarValue)
            {
                currentPowerBarValue = maxPowerBarValue;
            }
            useFunction = false;
        }
    }
    public void UpdatePowerBarDown()
    {
        if (useFunction)
        {
            if (updateFillAmouth)
            {
                currentPowerBarValue -= barChangeSpeed;

                float fill = -currentPowerBarValue / maxPowerBarValue;
                PowerBarMask.fillAmount = fill;

                if (currentPowerBarValue <  0)
                {
                    float _fill = currentPowerBarValue / maxPowerBarValue;
                    PowerBarMask.fillAmount = _fill;
                }
            }

            if (currentPowerBarValue <= 0)
            {
                if (currentPowerBarValue < 0)
                {
                    currentPowerBarValue = 0;
                }
            }
        }
    }
    public void SetBallPosition(float pos)
    {
        float angle = Mathf.Abs(pos);

        if (target.transform.position.x >= minX && target.transform.position.x <= maxX)
        {
            target.transform.position = new Vector2((Mathf.Sin(minX * -angle * 0.005f + minX)) * 1.5f, 3f);
        }
        if (target.transform.position.x <= minX)
        {
            target.transform.position = new Vector2(minX, 3f);
        }
        else if (target.transform.position.x >= maxX)
        {
            target.transform.position = new Vector2(maxX, 3f);
        }
    }
    public void ResetBallPosition()
    {
        useFunction = true;
    }

    public void HoldButton()
    {
        buttonHoldDown = true;
        useFunction = true;
    }
    public void ReleasseButton()
    {
        buttonHoldDown = false;
        useFunction = true;
    }
    public void DragToUpdateFillAmouth()
    {
        updateFillAmouth = false;
    }
    public void Fire()
    {
        if (delayFire)
        {
            ctrl_Amouth.testAmouthBall = true;

            Instantiate(ball, spawnPoint.position, transform.rotation);
            delayFire = false;
            StartCoroutine(DelayFire(1.5f));
        }
    }
    IEnumerator DelayFire(float sec)
    {
        yield return new WaitForSeconds(sec);
        delayFire = true;
    }
}
