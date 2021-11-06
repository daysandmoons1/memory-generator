using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Transform tr;
    private bool movable = true;
    public bool Movable
    {
        get {return movable;}
        set {movable = value;}
    }

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
        if(movable)
            tr.Translate(Vector2.right * h * moveSpeed * Time.deltaTime);
    }
}
