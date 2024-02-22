using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GymOverWorldUI : MonoBehaviour
{
    public static GymOverWorldUI Instance;
    private GameObject player;

    public Vector2 playerPosition;
    public Vector2 lastKnownLocation;

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
        player = GameObject.Find("Player");

        if(lastKnownLocation != Vector2.zero)
        {
            PlaceThePlayer();
        }
    }

    public void UpdateLastKnownLocation(Vector2 location)
    {
        lastKnownLocation = location;
    }

    private void OnEnable()
    {
        if (lastKnownLocation != Vector2.zero)
        {
            PlaceThePlayer();
        }
    }

    public void SavingPlayerPosition()
    {
        if (player != null)
        {
            playerPosition = player.transform.position;
            lastKnownLocation = playerPosition;
        }
    }

    public void PlaceThePlayer()
    {
        if (player != null)
        {
            player.transform.position = lastKnownLocation;
        }
    }
}