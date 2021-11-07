using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private PlayerController playerController;

    private float timeLimit = 30f;
    private float gaugeSpeed = 3f;

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
            if(energy < 0)
                IsGameOver = true;
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
    public GameObject gameoverObj;
    public Image fadeout;

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

        playerController = FindObjectOfType<PlayerController>();

        StartCoroutine("Timer");
        StartCoroutine("EnergyGauge");
    }

    IEnumerator Timer()
    {
        float _time = timeLimit;
        timeTxt.text = timeLimit.ToString();
        while(_time > 0 && !(isGameover))
        {
            yield return new WaitForSeconds(1f);
            _time = _time - 1f;
            timeTxt.text = _time.ToString();
        }
        IsGameOver = true;
    }

    IEnumerator EnergyGauge()
    {
        float _time = 0;
        while(energy > 0)
        {
            energy -= 0.05f;
            energyGauge.fillAmount = energy * 0.01f;
            yield return null;
        }
        IsGameOver = true;
    }

    private void GameOver()
    {
        // 플레이어 조작키 비활성화
        playerController.Movable = false;

        timeTxt.text = "00";
         energyGauge.fillAmount = 0;

        // gameoverObj.SetActive(true);
        StartCoroutine("FadeOut");
    }

    IEnumerator FadeOut()
    {
        fadeout.gameObject.SetActive(true);
        yield return StartCoroutine("CoFadeOut");
    }

    IEnumerator CoFadeOut()
    {
        Color color = fadeout.color;
        while(color.a < 1f)
        {
            color.a += Time.deltaTime / 3f;
            fadeout.color = color;

            if(color.a >= 1f) color.a = 1f;

            yield return null;
        }
        fadeout.color = color;
        
        SceneController.Instance.LoadEndingScene();
    }
}