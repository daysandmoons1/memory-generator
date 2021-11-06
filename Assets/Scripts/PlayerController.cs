using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Transform tr;

    [SerializeField]
    private float moveSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float r = Input.GetAxisRaw("Mouse X");

        // ¿Ãµø
        tr.Translate(Vector2.right * h * moveSpeed * Time.deltaTime);
    }
}
