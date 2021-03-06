using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ctrl_Door_1 : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject target;

    float moveSpeed;
    Vector3 directionToTarget;

    public bool checktarget = false;
    void Start()
    {
        target = GameObject.Find("Waypoint_1");
        rb = GetComponent<Rigidbody2D>();

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
                Destroy(gameObject);
                target = null;
                break;
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
}
