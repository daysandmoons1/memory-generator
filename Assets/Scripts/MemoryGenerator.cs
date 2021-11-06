using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryGenerator : MonoBehaviour
{
    private Sprite hangerSprite;

    public GameObject hanger;

    void Start()
    {
        hangerSprite = hanger.GetComponent<SpriteRenderer>();    
    }

    public bool Hang(GameObject npc)
    {
        if(hangerSprite!=null)
            return false;
        else
        {
            hangerSprite = npc.GetComponent<SpriteRenderer>().sprite;
            StartCoroutine("ExtractMemory");
            return true;
        }
    }

    private void GetEnergy(float _energy)
    {
        GameManager.Instance.Energy = _energy;
    }

    IEnumerator ExtractMemory()
    {

    }
}
