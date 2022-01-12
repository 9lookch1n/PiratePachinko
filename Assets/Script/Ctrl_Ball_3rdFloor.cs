using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ctrl_Ball_3rdFloor : MonoBehaviour
{
    public GameManager gameManager;

    Rigidbody2D rb;
    GameObject target;

    float moveSpeed;
    Vector3 directionToTarget;

    public bool checktarget = false;
    public bool checkStop = false;

    void Start()
    {
        target = GameObject.Find("WaypointBall_3");
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
                    gameManager.perfect_3 = true;
                    Destroy(gameObject);
                    break;
                case ("NonDoor"):
                    gameManager.checkPoint_3 = true;
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
        gameManager.playParticleDoor_3nd = true;
        checkStop = true;
    }
}
