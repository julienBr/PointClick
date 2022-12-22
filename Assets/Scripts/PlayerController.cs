using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 target;
    private Animator _animator;
    [SerializeField] private float perspectiveScale = 0.09f;
    [SerializeField] private float scaleRatio = 5f;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        target = new Vector2(transform.position.x, transform.position.y);
    }

    private void Update()
    {
        AdjustSize();
        Vector2 mousPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<SpriteRenderer>().flipX = mousPos.x <= target.x;
            target = new Vector2(mousPos.x, mousPos.y);
            _animator.SetBool("Walk", true);
        }
        transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime * 1.5f);
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            _animator.SetBool("Walk", false);
        }// quand je touche un collider de mon mur, garder la position initial du player on colliderenter2d
    }
    
    void AdjustSize()
    {
        Vector3 scale = transform.localScale;
        scale.x = perspectiveScale * (scaleRatio - transform.position.y);
        scale.y = perspectiveScale * (scaleRatio - transform.position.y);
        transform.localScale = scale;
    }
}