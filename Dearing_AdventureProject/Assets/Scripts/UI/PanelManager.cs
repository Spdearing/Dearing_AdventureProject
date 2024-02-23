using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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