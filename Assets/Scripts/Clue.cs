using UnityEngine;

public class Clue : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            ClueManager.clueList.Add(gameObject.name);
        }
    }
}