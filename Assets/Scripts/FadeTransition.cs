using System.Collections;
using UnityEngine;

public class FadeTransition : MonoBehaviour
{
    private Animator animator;
    private float transitionTime = 0.5f;
    private int nextScene;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void ThrowFadeOut()
    {
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        animator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(transitionTime);
    }
}