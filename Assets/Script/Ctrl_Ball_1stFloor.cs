using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ctrl_Ball_1stFloor : MonoBehaviour
{
    public GameManager gameManager;
    public SpawnBall_2ndFloor ball_2nd;

    Rigidbody2D rb;
    GameObject target;

    float moveSpeed;
    Vector3 directionToTarget;

    public bool checktarget = false;
    public bool checkStop = false;

    void Start()
    {
        ball_2nd = GameObject.Find("SpawnBall2ndFloorManager").GetComponent<SpawnBall_2ndFloor>();
        target = GameObject.Find("WaypointBall_1");
        rb = GetComponent<Rigidbody2D>();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        moveSpeed = Random.Range(0.5f, 0.5f);
    }
    private void Update()
    {
        MoveDoor();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.gameObject.tag)
        {
            case "Waypoint":
                target = null;
                checktarget = true;
                break;
            case ("SpeedDown"):
                StartCoroutine(StopMove(Random.Range(0.3f, 1f)));
                break;
        }
        if (checkStop)
        {
            switch (col.gameObject.tag)
            {
                case ("Door"):
                    Destroy(this.gameObject);
                    ball_2nd.fireBall = true;
                    break;
                case ("NonDoor"):
                    gameManager.checkPoint_1 = true;
                    Destroy(gameObject);
                    break;
            }
        }
    }
    void MoveDoor()
    {
        if (target != null && !checktarget)
        {
            directionToTarget = (target.transform.position - transform.position).normalized;
            rb.velocity = new Vector2(directionToTarget.x * moveSpeed, directionToTarget.y * moveSpeed);
        }
    }
    IEnumerator StopMove(float sec)
    {

        yield return new WaitForSeconds(sec);
        gameManager.playParticleDoor_1st = true;
        checkStop = true;
    }
}
