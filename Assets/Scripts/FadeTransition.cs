using UnityEngine;

public class FadeTransition : MonoBehaviour
{
    private Animator animator;
    private int nextScene;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void ThrowFade()
    {
        animator.SetTrigger("FadeOut");
    }
}