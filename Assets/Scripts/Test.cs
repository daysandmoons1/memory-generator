using UnityEngine;

public class Test : MonoBehaviour
{
    public float _energy;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _energy = -10f;
            GameManager.Instance.Energy = _energy;
        }
        else if(Input.GetMouseButtonDown(1))
        {
            _energy = 10f;
            GameManager.Instance.Energy = _energy;
        }
    }    
}