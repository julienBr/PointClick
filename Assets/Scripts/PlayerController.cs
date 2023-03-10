using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    private float speed = 1.5f;
    private Vector2 mousPos;
    private Vector2 target;
    private Animator _animator;
    [SerializeField] public AudioSource _audioSource;
    private float perspectiveScale = 0.05f;
    private float scaleRatio = 7f;
    private Vector3 _scale;
    public static int cluesFound;
    private bool isHappy;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _scale = transform.localScale;
    }

    private void Update()
    {
        RescalePlayerDistance();
        Walk();
    }

    private void Walk()
    {
        Vector2 mousPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0) && !isHappy && !PauseMenu.isPaused)
        {
            GetComponent<SpriteRenderer>().flipX = mousPos.x <= target.x;
            target = mousPos;
            _animator.SetBool("Walk", true);
            _audioSource.Play();
            StartCoroutine(Move());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BgCollider"))
        {
            target = transform.position;
        }
    }

    IEnumerator Move()
    {
        do
        {
            transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime * speed);
            yield return null;
        } while (transform.position.x != target.x && transform.position.y != target.y);
        _animator.SetBool("Walk", false);
        _audioSource.Stop();
    }
    
    private void RescalePlayerDistance()
    {
        _scale.x = perspectiveScale * (scaleRatio - transform.position.y);
        _scale.y = perspectiveScale * (scaleRatio - transform.position.y);
        transform.localScale = _scale;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("arrowTopToMiddle")) gameManager.ChangeScene("3_Middle");
        if (col.gameObject.CompareTag("arrowMiddleToBottom")) gameManager.ChangeScene("4_Bottom");
        if (col.gameObject.CompareTag("arrowMiddleToTop")) gameManager.ChangeScene("2_Top");
        if (col.gameObject.CompareTag("arrowBottomToMiddle")) gameManager.ChangeScene("3_Middle");
        if (col.gameObject.CompareTag("Clue"))
        {
            isHappy = true;
            StartCoroutine(FoundClue());
        }
    }

    private IEnumerator FoundClue()
    {
        target = transform.position;
        cluesFound += 1;
        _animator.SetBool("Happy", true);
        yield return new WaitForSeconds(2f);
        _animator.SetBool("Happy", false);
        isHappy = false;
    }
}