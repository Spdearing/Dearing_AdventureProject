using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This is to keep reference for the Interactable Text Box which is used to show when you can interact with something, and on the top right of the screen when you have badges
/// </summary>
public class PanelManager : MonoBehaviour
{
    public static PanelManager Instance;

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
}
