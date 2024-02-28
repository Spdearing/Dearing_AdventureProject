using UnityEngine;

public class PlayerPositionManager : MonoBehaviour
{
    public static PlayerPositionManager Instance;

    private const string PlayerPositionKey = "PlayerPosition";
    private Vector2 lastSavedPosition = Vector2.zero; // Variable to store the last saved position

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        
    }

    public void SavePlayerPosition(Vector2 position)
    {
        lastSavedPosition = position;
        PlayerPrefs.SetFloat(PlayerPositionKey + "X", position.x);
        PlayerPrefs.SetFloat(PlayerPositionKey + "Y", position.y);
        PlayerPrefs.Save();
    }

    public Vector2 LoadLastSavedPosition()
    {
        float x = PlayerPrefs.GetFloat(PlayerPositionKey + "X", 0);
        float y = PlayerPrefs.GetFloat(PlayerPositionKey + "Y", 0);
        lastSavedPosition = new Vector2(x, y);
        return lastSavedPosition;
    }

    private void OnDisable()
    {
        SavePlayerPosition(transform.position); // Save the player position before disabling the GameObject
    }
}
