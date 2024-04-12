using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


/// <summary>
/// PlayerMovement handles the player movement, and the collisions with the gates for the progression mechanic, and when the player collides with the portal, and or Gym Members
/// </summary>
public class PlayerMovement : MonoBehaviour
{

    private PlayerPositionManager playerPositionManager;

    private float walkingSpeed;
    private Rigidbody2D rb;
    //private Animator animator;
    private SpriteRenderer spriteRenderer;

    private bool interactableWithGymMemberOne;
    private bool interactableWithGymMemberTwo;
    private bool interactableWithGymMemberThree;
    private bool interactableWithFinalBoss;


    private bool canOpenGateOne;
    private bool canOpenGateTwo;
    private bool canOpenGateThree;
    private bool canOpenGateFour;


    private TMP_Text interactableText;
    private GameObject interactableTextBox;
    [SerializeField] GameObject firstGate;
    [SerializeField] GameObject secondGate;
    [SerializeField] GameObject thirdGate;
    [SerializeField] GameObject fourthGate;

    [SerializeField] GameObject gymTrainerOne;
    [SerializeField] GameObject gymTrainerTwo;
    [SerializeField] GameObject gymTrainerThree;
    [SerializeField] GameObject finalBoss;


    // Start is called before the first frame update
    void Start()
    {
        
        walkingSpeed = 3.5f;
        rb = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        interactableTextBox = GameObject.Find("InteractableTextBackGround");
        interactableText = GameObject.Find("InteractableText").GetComponent<TMP_Text>();
        interactableTextBox.SetActive(false);
        firstGate = GameObject.Find("FirstGate");
        secondGate = GameObject.Find("SecondGate");
        thirdGate = GameObject.Find("ThirdGate");
        fourthGate = GameObject.Find("FourthGate");
        gymTrainerOne = GameObject.Find("GymTrainerOne");
        gymTrainerTwo = GameObject.Find("GymTrainerTwo");
        gymTrainerThree = GameObject.Find("GymTrainerThree");
        finalBoss = GameObject.Find("FinalBoss");


        playerPositionManager = PlayerPositionManager.Instance;

        if(!SceneManager.GetActiveScene().name.StartsWith("GymBattle"))
        {
            playerPositionManager.LoadLastSavedPosition();
        }
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        float verticalMovement = CrossPlatformInputManager.GetAxisRaw("Vertical");

        // Update horizontal movement
        rb.velocity = new Vector2(horizontalMovement * walkingSpeed, rb.velocity.y);
        //animator.SetFloat("movement", Mathf.Abs(horizontalMovement));

        // Update vertical movement
        rb.velocity = new Vector2(rb.velocity.x, verticalMovement * walkingSpeed);

    
        if (Input.GetKeyDown(KeyCode.E) && interactableWithGymMemberOne)
        {
            PlayerPositionManager.Instance.SavePlayerPosition(transform.position);
            SceneManager.LoadScene("GymBattleOne");  
        }
        else if(Input.GetKeyDown(KeyCode.E) && interactableWithGymMemberTwo)
        {
            PlayerPositionManager.Instance.SavePlayerPosition(transform.position);
            SceneManager.LoadScene("GymBattleTwo");
        }
        if (Input.GetKeyDown(KeyCode.E) && interactableWithGymMemberThree)
        {
            PlayerPositionManager.Instance.SavePlayerPosition(transform.position);
            SceneManager.LoadScene("GymBattleThree");
        }
        else if (Input.GetKeyDown(KeyCode.E) && interactableWithFinalBoss)
        {
            PlayerPositionManager.Instance.SavePlayerPosition(transform.position);
            SceneManager.LoadScene("GymBattleFour");
        }

        CanOpenTheFirstGate();
        CanOpenTheSecondGate();
        CanOpenTheThirdGate();
        CanOpenTheFourthGate();

        DefeatFirstTrainer();
        DefeatSecondTrainer();
        DefeatThirdTrainer();
        DefeatFinalBoss();

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("GymTrainerOne"))
        {
            interactableTextBox.SetActive(true);
            interactableWithGymMemberOne = true;
            interactableText.text = " Press (E) To Talk To The First Gym Member!";
        }
        else if (other.CompareTag("GymTrainerTwo"))
        {
            interactableTextBox.SetActive(true);
            interactableWithGymMemberTwo = true;
            interactableText.text = "Press (E) To Put This Menace In Their Place!";
        }
        if (other.CompareTag("GymTrainerThree"))
        {
            interactableTextBox.SetActive(true);
            interactableWithGymMemberThree = true;
            interactableText.text = "Press (E) To Show This Guy You Aren't A Slouch!";
        }
        else if (other.CompareTag("FinalBoss"))
        {
            interactableTextBox.SetActive(true);
            interactableWithFinalBoss = true;
            interactableText.text = "Press (E) To Test Your Full Power!";
        }
        if(other.CompareTag("FirstGate") && GameManager.Instance.ReturnHasFirstBadge() == true)
        {
            interactableTextBox.SetActive(true);
            canOpenGateOne = true;
            interactableText.text = "Press (E) To Open The Gate To The Next Battle Area";
        }
        else if (other.CompareTag("FirstGate") && !GameManager.Instance.ReturnHasFirstBadge())
        {
            interactableTextBox.SetActive(true);
            canOpenGateOne = false;
            interactableText.text = "You Cannot Progress Just Yet";
        }
        if (other.CompareTag("SecondGate") && GameManager.Instance.ReturnHasSecondBadge() == true)
        {
            interactableTextBox.SetActive(true);
            canOpenGateTwo = true;
            interactableText.text = "Press (E) To Open The Second Gate";
        }
        else if (other.CompareTag("SecondGate") && !GameManager.Instance.ReturnHasSecondBadge())
        {
            interactableTextBox.SetActive(true);
            canOpenGateTwo = false;
            interactableText.text = "You Cannot Progress Just Yet";
        }
        if (other.CompareTag("ThirdGate") && GameManager.Instance.ReturnHasThirdBadge() == true)
        {
            interactableTextBox.SetActive(true);
            canOpenGateThree = true;
            interactableText.text = "Press (E) To Open The Third Gate";
        }
        else if (other.CompareTag("ThirdGate") && !GameManager.Instance.ReturnHasThirdBadge())
        {
            interactableTextBox.SetActive(true);
            canOpenGateThree = false;
            interactableText.text = "You Cannot Progress Just Yet";
        }
        if (other.CompareTag("FourthGate") && GameManager.Instance.ReturnHasFourthBadge() == true)
        {
            interactableTextBox.SetActive(true);
            canOpenGateFour = true;
            interactableText.text = "Press (E) To Go Ahead And Take The Portal Home!";
        }
        else if (other.CompareTag("FourthGate") && !GameManager.Instance.ReturnHasFourthBadge())
        {
            interactableTextBox.SetActive(true);
            canOpenGateFour = false;
            interactableText.text = "You Cannot Progress Just Yet";
        }
        if(other.CompareTag("Portal"))
        {
            WipeTheScene();
            SceneManager.LoadScene("GameWinScene");
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("GymTrainerOne"))
        {
            interactableTextBox.SetActive(false);
            interactableWithGymMemberOne = false;
            interactableText.text = "";
        }
        else if (other.CompareTag("GymTrainerTwo"))
        {
            interactableTextBox.SetActive(false);
            interactableWithGymMemberTwo = false;
            interactableText.text = "";
        }
        if (other.CompareTag("GymTrainerThree"))
        {
            interactableTextBox.SetActive(false);
            interactableWithGymMemberThree = false;
            interactableText.text = "";
        }
        else if (other.CompareTag("FinalBoss"))
        {
            interactableTextBox.SetActive(false);
            interactableWithFinalBoss = false;
            interactableText.text = "";
        }
        if (other.CompareTag("FirstGate"))
        {
            interactableTextBox.SetActive(false);
            interactableText.text = " ";
        }
        else if (other.CompareTag("SecondGate"))
        {
            interactableTextBox.SetActive(false);
            interactableText.text = " ";
        }
        if (other.CompareTag("ThirdGate"))
        {
            interactableTextBox.SetActive(false);
            interactableText.text = " ";
        }
        else if (other.CompareTag("FourthGate"))
        {
            interactableTextBox.SetActive(false);
            interactableText.text = " ";
        }
    }

    public void CanOpenTheFirstGate()
    {
        if (Input.GetKeyDown(KeyCode.E) && canOpenGateOne)
        {
            firstGate.SetActive(false);
        }
    }
    public void CanOpenTheSecondGate()
    {
       if (Input.GetKeyDown(KeyCode.E) && canOpenGateTwo)
       {
            secondGate.SetActive(false);
        }
    }
    public void CanOpenTheThirdGate()
    {
        if (Input.GetKeyDown(KeyCode.E) && canOpenGateThree)
        {
            thirdGate.SetActive(false);
        }
    }
    public void CanOpenTheFourthGate()
    {
        if (Input.GetKeyDown(KeyCode.E) && canOpenGateFour)
        {
            fourthGate.SetActive(false);
        }
    }

    public TMP_Text ReturnInteractableText()
    {
        return interactableText;
    }

    public void TurnOnInteractableTextBox()
    {
        interactableTextBox.SetActive(true);
    }
    public void TurnOffInteractableTextBox()
    {
        interactableTextBox.SetActive(false);
    }

    void DefeatFirstTrainer()
    {
        if(GameManager.Instance.ReturnHasFirstBadge() == true)
        {
            Destroy(gymTrainerOne);
        }
    }
    void DefeatSecondTrainer()
    {
        if (GameManager.Instance.ReturnHasSecondBadge() == true)
        {
            Destroy(gymTrainerTwo);
        }
    }

    void DefeatThirdTrainer()
    {
        if (GameManager.Instance.ReturnHasThirdBadge() == true)
        {
            Destroy(gymTrainerThree);
        }
    }

    void DefeatFinalBoss()
    {
        if (GameManager.Instance.ReturnHasFourthBadge() == true)
        {
            Destroy(finalBoss);
        }
    }
    /// <summary>
    /// clears the objects from the game when the player wins
    /// </summary>
    public void WipeTheScene()
    {
        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();

        // Iterate through each GameObject and destroy it
        foreach (GameObject gameObject in allObjects)
        {
            Destroy(gameObject);
        }
    }
}
