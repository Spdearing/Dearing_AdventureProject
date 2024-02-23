using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    private bool hasFirstBadge;
    private bool hasSecondBadge;
    private bool hasThirdBadge;
    private bool hasFourthBadge;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject gameManager = new GameObject("GameManager");
                instance = gameManager.AddComponent<GameManager>();
                DontDestroyOnLoad(gameManager);
            }

            return instance;
        }
    }
    
    public void SetHasFirstBadge(bool value)
    {
        hasFirstBadge = value;
    }
    public void SetHasSecondBadge(bool value) 
    { 
        hasSecondBadge = value;
    }   
    public void SetHasThirdBadge(bool value) 
    { 
        hasThirdBadge = value;
    }
    public void SetHasFourthBadge(bool value) 
    { 
        hasFourthBadge = value;
    }
    public bool ReturnHasFirstBadge() 
    { 
        return hasFirstBadge;
    }
    public bool ReturnHasSecondBadge() 
    {
        return hasSecondBadge;
    }
    public bool ReturnHasThirdBadge()
    {
        return hasThirdBadge;
    }
    public bool ReturnHasFourthBadge()
    {
        return hasFourthBadge;
    }

}
