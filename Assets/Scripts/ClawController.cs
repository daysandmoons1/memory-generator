using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawController : MonoBehaviour
{
    private float moveSpeed = 8f;
    private float turnSpeed = 5f;
    private Vector2 pos;

    private Transform tr;
    private CircleCollider2D target;

    private PlayerController player;
    private MemoryGenerator memoryGenerator;

    public GameObject generator;
    public GameObject catchedNPC;


    void Start()
    {
        tr = GetComponent<Transform>();
        target = GetComponent<CircleCollider2D>();
        player = tr.parent.GetComponent<PlayerController>();
        memoryGenerator = generator.GetComponent<MemoryGenerator>();

        pos = tr.localPosition;
    }

    void Update()
    {
        if(player.Movable)
        {
            float r = Input.GetAxisRaw("Mouse X");
            tr.Rotate(-Vector3.forward * turnSpeed * r);
        }

        if(Input.GetMouseButtonDown(0))
        {
            StartCoroutine("GoClaw");
        }
        
        // npc 포획 성공하면, GoClaw 코루틴 멈추고 돌아오는 코루틴 활성화
    }

    IEnumerator GoClaw()
    {
        player.Movable = false;
        float _time = 0;
        while((_time += Time.deltaTime) < 0.7f)
        {
            tr.Translate(Vector2.up * moveSpeed * Time.deltaTime, Space.Self);
            yield return null;
        }
        StartCoroutine("BackClaw");
    }

    IEnumerator BackClaw()
    {
        while(tr.localPosition.y > pos.y)
        {
            tr.Translate(-Vector2.up * moveSpeed * Time.deltaTime, Space.Self);
            yield return null;
        }
        tr.localPosition = pos;
        
        if(catchedNPC.GetComponent<SpriteRenderer>().sprite != null)
            memoryGenerator.Hang(catchedNPC);
            
        player.Movable = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("NPC") && catchedNPC.GetComponent<SpriteRenderer>().sprite == null)
            Catch(other.gameObject);
    }

    private void Catch(GameObject _npc)
    {
        Debug.Log("_npc sprite : " + _npc.GetComponent<SpriteRenderer>().sprite);
        catchedNPC.GetComponent<SpriteRenderer>().sprite = _npc.GetComponent<SpriteRenderer>().sprite;
        Debug.Log("catchedNPC sprite : " + catchedNPC);
        Destroy(_npc);
    }
}