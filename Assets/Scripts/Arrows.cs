using System;
using System.Collections;
using UnityEngine;

public class Arrows : MonoBehaviour
{
    private float fadeTime = 2f;

    private void Start()
    {
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        while (true)
        {
            Color tmpColor = GetComponent<SpriteRenderer>().color;
            while (tmpColor.a > 0f)
            {
                //Debug.Log("FADEOUT");
                tmpColor.a -= Time.deltaTime / fadeTime;
                GetComponent<SpriteRenderer>().color = tmpColor;
                if (tmpColor.a <= 0f) tmpColor.a = 0f;
                yield return null;
            }
            GetComponent<SpriteRenderer>().color = tmpColor;
            while (tmpColor.a < 1f)
            {
                //Debug.Log("FADEIN");
                tmpColor.a += Time.deltaTime / fadeTime;
                GetComponent<SpriteRenderer>().color = tmpColor;
                if (tmpColor.a >= 1f) tmpColor.a = 1f;
                yield return null;
            }
            GetComponent<SpriteRenderer>().color = tmpColor;
        }
    }
}