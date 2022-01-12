using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ctrl_Ball : MonoBehaviour
{
    public GameManager gameManager;
    public SpawnBall_1stFloor ball_1st;

    public float speed = 0.01f;

    private GameObject gun;
    private GameObject target;

    public float gunX;
    public float targetX;


    private float dist;
    private float nextX;
    private float baseY;
    private float height;

    bool checkTarget = false;
    public bool checkStopp = false;

    void Start()
    {
        ball_1st = GameObject.Find("SpawnBall1stFloorManager").GetComponent<SpawnBall_1stFloor>();
        gun = GameObject.FindGameObjectWithTag("Gun");
        target = GameObject.FindGameObjectWithTag("Target");
    }

    void Update()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        nextX = Mathf.MoveTowards(transform.position.x, targetX, speed);

        gunX = gun.transform.position.x;
        targetX = target.transform.position.x;

        if (!checkTarget)
        {
            dist = targetX - gunX;
            nextX = Mathf.MoveTowards(transform.position.x, targetX, speed);
            baseY = Mathf.Lerp(gun.transform.position.y, target.transform.position.y, (nextX - gunX) / dist);
            height = 1.5f * (nextX - gunX) * (nextX - targetX) / (-0.25f * dist * dist);

            Vector3 movePositon = new Vector3(nextX, baseY + height, transform.position.z);
            transform.rotation = LookAtTarget(movePositon - transform.position);
            transform.position = movePositon;
        }

        if (transform.position == target.transform.position)
        {
            checkTarget = true;
        }
    }
    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Cog")
        {
            StartCoroutine(RemoveBallBug(10f));
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        switch (col.gameObject.tag)
        {
            case ("DestoryBall"):
                Destroy(gameObject);
                break;
            case ("SpinRow"):
                gameManager.spinRow = true;
                gameManager.checkFirstSpinRow = true;
                Destroy(gameObject);

                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.gameObject.tag)
        {
            case ("SpeedDown"):
                StartCoroutine(StopMove(Random.Range(0.3f,1f)));
                break;
            case ("SpawnBall_1st"):
                Destroy(gameObject);
                ball_1st.fireBall = true;
                break;
        }
        if (checkStopp)
        {
            switch (col.gameObject.tag)
            {
                case ("Door"):
                    Destroy(gameObject);
                    break;
                case ("NonDoor"):
                    Destroy(gameObject);
                    break;
            }
        }
    }
    public static Quaternion LookAtTarget(Vector2 rotation)
    {
        return Quaternion.Euler(0, 0, Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg);
    }
    IEnumerator StopMove(float sec)
    {
        yield return new WaitForSeconds(sec);
        checkStopp = true;

    }
    IEnumerator RemoveBallBug(float sec)
    {
        yield return new WaitForSeconds(sec);
        Destroy(gameObject);
    }

}
