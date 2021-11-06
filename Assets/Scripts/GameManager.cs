using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private float timeLimit = 10f;

    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = FindObjectOfType<GameManager>();
                if (obj != null)
                {
                    instance = obj;
                }
                else
                {
                    var newSingleton = new GameObject("GameManager").AddComponent<GameManager>();
                    instance = newSingleton;
                }
            }
            return instance;
        }
        private set
        {
            instance = value;
        }
    }

    private float energy = 100f;
    public float Energy
    {
        get { return energy; }
        set
        {
            energy += value;
            energyGauge.fillAmount = energy * 0.01f;
        }
    }

    private bool isGameover = false;
    public bool IsGameOver
    {
        get { return isGameover; }
        set
        {
            isGameover = value;
            if(isGameover)
                GameOver();
        }
    }

    public Image energyGauge;
    public Text timeTxt;

    private void Awake()
    {
        var objs = FindObjectsOfType<GameManager>();
        if (objs.Length != 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        Debug.Log(this.name);

        StartCoroutine("Timer");
    }

    IEnumerator Timer()
    {
        float _time = timeLimit;
        timeTxt.text = timeLimit.ToString();
        while(_time > 0)
        {
            yield return new WaitForSeconds(1f);
            _time = _time - 1f;
            timeTxt.text = _time.ToString();
        }
        IsGameOver = true;
    }

    private void GameOver()
    {
        // 플레이어 조작키 비활성화
        // NPC 스포너 비활성화
        // 엔딩 씬으로 넘어가기
        Debug.Log("게임오버!");
    }
}