using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class FlashArrows : MonoBehaviour
{

    private float arrowAlpha;

    private void Awake()
    {
        arrowAlpha = GetComponent<Image>().tintColor.a;
    }

    private void Flash()
    {
        StartCoroutine(FlashDelay);
    }

    IEnumerator FlashDelay()
    {
        for(int i = 0; i < 5; i++)
        {
            arrowAlpha = 0f;
            yield return WaitForSeconds(1f);
            GetComponent<Renderer>().material.color = whateverColor;
            yield return WaitForSeconds(.1);
        }
        GetComponent<Renderer>().material.color = Color.white;
    }
}