using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPositionManager : MonoBehaviour
{
    public static PlayerPositionManager Instance;

    private const string PlayerPositionKey = "PlayerPosition";
    private Vector2 defaultPosition = new Vector2(0, 0);

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
        LoadPlayerPosition();
    }

    public void SavePlayerPosition(Vector2 position)
    {
        PlayerPrefs.SetFloat(PlayerPositionKey + "X", position.x);
        PlayerPrefs.SetFloat(PlayerPositionKey + "Y", position.y);
        PlayerPrefs.Save();
    }

    public Vector2 LoadPlayerPosition()
    {
        float x = PlayerPrefs.GetFloat(PlayerPositionKey + "X", defaultPosition.x);
        float y = PlayerPrefs.GetFloat(PlayerPositionKey + "Y", defaultPosition.y);
        return new Vector2(x, y);
    }
}


   



