using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GymOverWorldUI : MonoBehaviour
{   
    public static GymOverWorldUI Instance;

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

    void Start()
    {
        if (PlayerEnemyDialogue.Instance.ReturnTravels() >= 1)
        {
            PlaceThePlayer();
        }
    }
    public void SavingPlayerPosition()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            playerPosition = player.transform.position;
            lastKnownLocation = playerPosition;
        }
    }

    //void InitializePlayerPosition() 
    //{
    //    Vector2 initialPlayerPosition;
    //    GameObject player = GameObject.FindGameObjectWithTag("Player");

    //    if (player != null)
    //    {
    //        initialPlayerPosition = player.transform.position;
    //        player.transform.position = initialPlayerPosition;
    //    }
    //}
    void PlaceThePlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
       
        if (player != null)
        {
            player.transform.position = lastKnownLocation;
        }
    }
}