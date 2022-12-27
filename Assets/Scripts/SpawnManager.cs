using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private static string previousScene;
    private string currentScene;
    public Vector3 posPlayer;
    private void OnDestroy()
    {
        previousScene = gameObject.scene.name;
    }

    private void Awake()
    {
        posPlayer = player.GetComponent<Transform>().transform.position;
        currentScene = gameObject.scene.name;
        if (currentScene == "2_Top" && previousScene == "3_Middle")
        {
            Debug.Log(posPlayer);
            posPlayer = new Vector3(6.039f, 0.315f, 0f);
            Debug.Log(posPlayer);
        }
    }
}