using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 target;

    private void Update()
    {
        Vector2 mousPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0)) target = new Vector2(mousPos.x, mousPos.y);
        transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime * 5f);
    }
}