using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawController : MonoBehaviour
{
    private float moveSpeed = 3f;
    private float turnSpeed = 5f;
    private Vector2 destination;

    private Camera camera;
    private Transform tr;
    private CircleCollider2D target;

    void Start()
    {
        camera = Camera.main;
        tr = GetComponent<Transform>();
        target = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        float r = Input.GetAxisRaw("Mouse X");
        tr.Rotate(-Vector3.forward * turnSpeed * r);

        if(Input.GetMouseButtonDown(0))
        {
            tr.Translate(Vector2.up, Space.Self);
        }
    }
}