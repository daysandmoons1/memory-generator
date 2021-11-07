using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryGenerator : MonoBehaviour
{
    private float perEnery = 5f;
    public GameObject hanger;

    void Start()
    {
        StartCoroutine("ExtractMemory");
    }

    public bool Hang(GameObject npc)
    {
        if(hanger.GetComponent<SpriteRenderer>().sprite != null)
            return false;
        else
        {
            hanger.GetComponent<SpriteRenderer>().sprite = npc.GetComponent<SpriteRenderer>().sprite;
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
        yield return new WaitForSeconds(1f);
        GetEnergy(perEnery);
        hanger.GetComponent<SpriteRenderer>().sprite = null;
    }
}
