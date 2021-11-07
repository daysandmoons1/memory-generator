using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingManager : MonoBehaviour
{
    public GameObject ending;
    public SpriteRenderer fadeout;

    void Start()
    {
        StartCoroutine("Ending");
    }

    IEnumerator Ending()
    {
        yield return new WaitForSeconds(2f);
        ending.transform.GetChild(0).gameObject.SetActive(false);
        yield return new WaitForSeconds(2f);
        ending.transform.GetChild(1).gameObject.SetActive(false);
        yield return new WaitForSeconds(2f);

        StartCoroutine("CoFadeOut");
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
        
        SceneController.Instance.LoadTitleScene();
    }
}
