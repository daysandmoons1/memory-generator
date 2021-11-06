using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryGenerator : MonoBehaviour
{
    public void Hang(GameObject npc)
    {
        
    }

    private void GetEnergy(float _energy)
    {
        GameManager.Instance.Energy = _energy;
    }
}
