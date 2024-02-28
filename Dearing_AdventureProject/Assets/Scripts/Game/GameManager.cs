using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private PlayerMovement player;

    private bool hasFirstBadge;
    private bool hasSecondBadge;
    private bool hasThirdBadge;
    private bool hasFourthBadge;

    [SerializeField] GameObject badgeOne;
    [SerializeField] GameObject badgeTwo;
    [SerializeField] GameObject badgeThree;
    [SerializeField] GameObject badgeFour;

    [SerializeField] GameObject friendlyCreaturePanel;
    [SerializeField] GameObject friendlyCreatureEvolving;
    [SerializeField] GameObject friendlyCreatureEvolved;

    
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
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
        friendlyCreaturePanel.SetActive(false);
        friendlyCreatureEvolving.SetActive(false);
        friendlyCreatureEvolved.SetActive(false);
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        

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

    public IEnumerator PlayersCreatureIsEvolving()
    {
        yield return new WaitForSeconds(1.0f);
        
        friendlyCreaturePanel.SetActive(true);
        friendlyCreatureEvolving.SetActive(true);

        player.InitalizeTheInteracbleText();//Turns the text box and panel on at the bottom of the screen

        player.ReturnInteractableText().text = "WHATS HAPPENING TO REXASOURUS!?!?!";

        Image image = friendlyCreatureEvolving.GetComponent<Image>();

        float fadeSpeed = 2f;//speed that the image fades in white and black

        for (int i = 0; i < 5; i++) // Repeat the fading effect 5 times
        {
            // Fade from white to black
            for (float t = 0f; t < 1.0f; t += Time.deltaTime * fadeSpeed)
            {
                image.color = Color.Lerp(Color.white, Color.black, t);
                yield return null;
            }

            yield return new WaitForSeconds(0.5f); // Wait for a short duration between fades

            // Fade from black to white
            for (float t = 0f; t < 1.0f; t += Time.deltaTime * fadeSpeed)
            {
                image.color = Color.Lerp(Color.black, Color.white, t);
                yield return null;
            }

            yield return new WaitForSeconds(0.5f); // Wait for a short duration between fades
        }

        // After all iterations, set the friendlyCreatureEvolving GameObject inactive
        friendlyCreatureEvolving.SetActive(false);

        // Set the friendlyCreatureEvolved GameObject active
        friendlyCreatureEvolved.SetActive(true);
        yield return new WaitForSeconds(0.75f);
        player.ReturnInteractableText().text = "Rexasourus has evolved into Rexladon!";
        yield return new WaitForSeconds(3.0f);
        friendlyCreaturePanel.SetActive(false);
        friendlyCreatureEvolved.SetActive(false);
        PlayerEnemyDialogue.Instance.TurnOffText();
        player.InitalizeTheInteracbleText();

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
