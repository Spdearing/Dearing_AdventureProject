using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private bool hasFirstBadge;
    private bool hasSecondBadge;
    private bool hasThirdBadge;
    private bool hasFourthBadge;

    [SerializeField] GameObject badgeOne;
    [SerializeField] GameObject badgeTwo;
    [SerializeField] GameObject badgeThree;
    [SerializeField] GameObject badgeFour;

    
    
    private void Awake()
    {
        if (Instance == null)
        {

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(Instance);
        }
    }

    private void Start()
    {
        badgeOne = GameObject.FindWithTag("BadgeOne");
        badgeTwo = GameObject.FindWithTag("BadgeTwo");
        badgeThree = GameObject.FindWithTag("BadgeThree");
        badgeFour = GameObject.FindWithTag("BadgeFour");
        badgeOne.SetActive(false);
        badgeTwo.SetActive(false);
        badgeThree.SetActive(false);
        badgeFour.SetActive(false);

    }
    private void Update()
    {
        ShowBadgesAquired();
    }
    void ShowBadgesAquired()
    {
        if(hasFirstBadge) 
        {
            badgeOne.SetActive(true);
        }
        else if(hasSecondBadge) 
        {
            badgeTwo.SetActive(true);
        }
        if (hasThirdBadge)
        {
            badgeThree.SetActive(true);
        }
        else if (hasFourthBadge)
        {
            badgeFour.SetActive(true);
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
    public GameObject ReturnBadgeOne()
    {
        return badgeOne;
    }
    public GameObject ReturnBadgeTwo()
    {
        return badgeTwo;
    }
    public GameObject ReturnBadgeThree()
    {
        return badgeThree;
    }
    public GameObject ReturnBadgeFour()
    {
        return badgeFour;
    }

}
