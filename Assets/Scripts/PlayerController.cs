using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 1.5f;
    private Vector2 mousPos;
    private Vector2 target;
    private Animator _animator;
    private float perspectiveScale = 0.05f;
    private float scaleRatio = 7f;
    private Vector3 _scale;
    private MenuController _menuController;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        target = new Vector2(transform.position.x, transform.position.y);
        Vector3 _scale = transform.localScale;
    }

    private void Update()
    {
        RescalePlayerDistance();
        Walk();
    }

    private void Walk()
    {
        Vector2 mousPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<SpriteRenderer>().flipX = mousPos.x <= target.x;
            target = new Vector2(mousPos.x, mousPos.y);
            _animator.SetBool("Walk", true);
        }
        transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime * speed);
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            _animator.SetBool("Walk", false);
        }
    }
    
    private void RescalePlayerDistance()
    {
        _scale.x = perspectiveScale * (scaleRatio - transform.position.y);
        _scale.y = perspectiveScale * (scaleRatio - transform.position.y);
        transform.localScale = _scale;
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("BgCollider"))
        {
            target = new Vector2(transform.position.x, transform.position.y);
            _animator.SetBool("Walk", false);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("arrowTopToMiddle"))
        {
            _menuController.ChangeScene("2_Middle");
        }
    }
}