using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    private int spawnLimit = 10;
    private Vector3 pos = new Vector3(-10f, 0.7f, 0f);

    [SerializeField] private GameObject prefab;
    [SerializeField] private Sprite[] npcSprites;
    [SerializeField] private Sprite[] memorySprites;

    void Start()
    {
        StartCoroutine("SpawnNPC");
    }

    IEnumerator SpawnNPC()
    {
        int random;
        GameObject npc = prefab.gameObject;
        while(!GameManager.Instance.IsGameOver)
        {
            random = Random.Range(0, npcSprites.Length);
            npc.GetComponent<SpriteRenderer>().sprite = npcSprites[random];
            
            random = Random.Range(0, memorySprites.Length);
            npc.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite = memorySprites[random];

            Instantiate(npc, pos, Quaternion.identity);

            yield return new WaitForSeconds(3f);
        }
    }
}