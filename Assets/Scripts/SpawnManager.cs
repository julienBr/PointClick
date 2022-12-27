using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private static string previousScene;
    private string currentScene;
    
    private void OnDestroy()
    {
        previousScene = gameObject.scene.name;
    }

    private void Awake()
    {
        currentScene = gameObject.scene.name;
        if (currentScene == "2_Top" && previousScene == "3_Middle")
        {
            Debug.Log("COUCOUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUU");
            player.transform.position = new Vector3(6.039f, 0.315f, 0f);
        }
    }
}