using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private static PlayerController _playerController;
    private NavMeshAgent _agent;
    private float speed = 1.5f;
    private Vector2 mousPos;
    private Vector2 target;
    //private Vector2 posStart = new (2.927f, 3.613f);
    private Animator _animator;
    private float perspectiveScale = 0.05f;
    private float scaleRatio = 7f;
    private Vector3 _scale;

    private void Awake()
    {
        if (!_playerController)
        {
            _playerController = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
        _animator = GetComponent<Animator>();
        target = transform.position;
        Vector3 _scale = transform.localScale;
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    private void Update()
    {
        RescalePlayerDistance();
        Walk();
        _agent.SetDestination(new Vector3(target.x, target.y, transform.position.z));
    }

    private void Walk()
    {
        Vector2 mousPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<SpriteRenderer>().flipX = mousPos.x <= target.x;
            target = mousPos;
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
            target = transform.position;
            _animator.SetBool("Walk", false);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("arrowTopToMiddle"))
        {
            // Position on Start Top Middle Map
            target = new Vector2(6f, 1.3f);
            GameObject.Find("GameManager").GetComponent<GameManager>().ChangeScene("3_Middle");
        }
        if (col.gameObject.CompareTag("arrowMiddleToBottom"))
        {
            // Position on Start Top Bottom Map
            target = new Vector2(6f, 1.3f);
            GameObject.Find("GameManager").GetComponent<GameManager>().ChangeScene("4_Bottom");
        }
        if (col.gameObject.CompareTag("arrowMiddleToTop"))
        {
            // Position on Start Bottom Top Map
            target = new Vector2(6f, 1.3f);
            GameObject.Find("GameManager").GetComponent<GameManager>().ChangeScene("2_Top");
        }
        if (col.gameObject.CompareTag("arrowBottomToMiddle"))
        {
            // Position on Start Bottom Middle Map
            target = new Vector2(6f, 1.3f);
            GameObject.Find("GameManager").GetComponent<GameManager>().ChangeScene("3_Middle");
        }
    }
}