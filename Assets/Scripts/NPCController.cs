using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    private float maxSpeed = 5f;
    private float moveSpeed;

    private Vector3 yFlip = new Vector3(0, 180, 0);

    private RaycastHit2D hit;
    private float hitDistance = 0.5f;

    Transform tr;
    Rigidbody2D rigid;
    CapsuleCollider2D col;

    void Start()
    {
        tr = GetComponent<Transform>();
        rigid = GetComponent<Rigidbody2D>();
        col = GetComponent<CapsuleCollider2D>();

        moveSpeed = Random.Range(1f, maxSpeed);
    }

    void Update()
    {
        tr.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }

    private void Turn()
    {
        if(tr.rotation.y < 0)
            tr.rotation = Quaternion.Euler(Vector2.zero);
        else
            tr.rotation = Quaternion.Euler(yFlip);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.CompareTag("BLOCK"))
            Turn();
    }
}