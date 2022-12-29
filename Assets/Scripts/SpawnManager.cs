using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Transform player;
    private static string previousScene;
    private string currentScene;
    private Vector3 posPlayer;
    private void OnDestroy()
    {
        previousScene = gameObject.scene.name;
    }

    private void Awake()
    {
        currentScene = gameObject.scene.name;
        if (currentScene == "2_Top" && previousScene == "3_Middle")
        {
            posPlayer = new Vector3(6.039f, 0.315f, 0f);
            player.position = posPlayer;
        }

        if (currentScene == "3_Middle" && previousScene == "4_Bottom")
        {
            posPlayer = new Vector3(6.048f, 0.315f, 0f);
            player.position = posPlayer;
        }

        if (currentScene == "3_Middle" && previousScene == "2_Top")
        {
            Debug.Log("COUCOUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUU");
        }
        
        /*if (currentScene == "2_Top" && previousScene == "1_Start")
        {
            Debug.Log("COUCOUUUUUUUUUUUUUUUUUUUU");
            posPlayer = new Vector3(3.01f, 3.59f, 0f);
            player.position = posPlayer;
        }*/
    }
}