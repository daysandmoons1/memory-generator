using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameObject ending;

    private static SceneController instance;
    public static SceneController Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = FindObjectOfType<SceneController>();
                if (obj != null)
                {
                    instance = obj;
                }
                else
                {
                    var newSingleton = new GameObject("SceneController").AddComponent<SceneController>();
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

    private void Awake()
    {
        var objs = FindObjectsOfType<SceneController>();
        if (objs.Length != 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void LoadTitleScene()
    {
        SceneManager.LoadScene("Title");
    }
    
    public void LoadMainScene()
    {
        SceneManager.LoadScene("Main");
    }

    public void LoadEndingScene()
    {
        SceneManager.LoadScene("Ending");
    }

    public void Exit()
    {
        Application.Quit();
    }
}