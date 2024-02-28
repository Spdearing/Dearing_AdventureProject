using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

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

    [SerializeField] GameObject firstTrainer;
    [SerializeField] GameObject secondTrainer;
    [SerializeField] GameObject thirdTrainer;
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
        firstTrainer = GameObject.Find("FirstTrainer");
        secondTrainer = GameObject.Find("SecondTrainer");
        thirdTrainer = GameObject.Find("ThirdTrainer");
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

    
        if (CrossPlatformInputManager.GetButtonDown("InteractButton") && interactableWithGymMemberOne)
        {
            PlayerPositionManager.Instance.SavePlayerPosition(transform.position);
            SceneManager.LoadScene("GymBattleOne");  
        }
        else if(CrossPlatformInputManager.GetButtonDown("InteractButton") && interactableWithGymMemberTwo)
        {
            PlayerPositionManager.Instance.SavePlayerPosition(transform.position);
            SceneManager.LoadScene("GymBattleTwo");
        }
        if (CrossPlatformInputManager.GetButtonDown("InteractButton") && interactableWithGymMemberThree)
        {
            PlayerPositionManager.Instance.SavePlayerPosition(transform.position);
            SceneManager.LoadScene("GymBattleThree");
        }
        else if (CrossPlatformInputManager.GetButtonDown("InteractButton") && interactableWithFinalBoss)
        {
            PlayerPositionManager.Instance.SavePlayerPosition(transform.position);
            SceneManager.LoadScene("GymBattleFour");
        }

        CanOpenTheFirstGate();
        CanOpenTheSecondGate();
        CanOpenTheThirdGate();
        CanOpenTheFourthGate();
        //if (CrossPlatformInputManager.GetButtonDown("InteractButton") && canOpenGateOne)
        //{
        //    firstGate.SetActive(false);
        //}
        //else if (CrossPlatformInputManager.GetButtonDown("InteractButton") && canOpenGateTwo)
        //{
        //    Destroy(secondGate);
        //}

        //if (horizontalMovement < 0)
        //{
        //    spriteRenderer.flipX = true; 
        //}
        //else if (horizontalMovement > 0)
        //{
        //    spriteRenderer.flipX = false; 
        //}


    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("GymTrainerOne"))
        {
            interactableTextBox.SetActive(true);
            interactableWithGymMemberOne = true;
            interactableText.text = "Talk to the first gym member!";
        }
        else if (other.CompareTag("GymTrainerTwo"))
        {
            interactableTextBox.SetActive(true);
            interactableWithGymMemberTwo = true;
            interactableText.text = "Put this menace in their place!";
        }
        if (other.CompareTag("GymTrainerThree"))
        {
            interactableTextBox.SetActive(true);
            interactableWithGymMemberThree = true;
            interactableText.text = "Put this menace in their place!";
        }
        else if (other.CompareTag("FinalBoss"))
        {
            interactableTextBox.SetActive(true);
            interactableWithFinalBoss = true;
            interactableText.text = "Test your full power!";
        }
        if(other.CompareTag("FirstGate") && GameManager.Instance.ReturnHasFirstBadge() == true)
        {
            interactableTextBox.SetActive(true);
            canOpenGateOne = true;
            interactableText.text = "Open the gate to the next battle area";
        }
        else if (other.CompareTag("FirstGate") && !GameManager.Instance.ReturnHasFirstBadge() == false)
        {
            interactableTextBox.SetActive(true);
            canOpenGateOne = false;
            interactableText.text = "You cannot progress just yet";
        }
        if (other.CompareTag("SecondGate") && GameManager.Instance.ReturnHasSecondBadge() == true)
        {
            interactableTextBox.SetActive(true);
            canOpenGateTwo = true;
            interactableText.text = "Open the second gate";
        }
        else if (other.CompareTag("SecondGate") && !GameManager.Instance.ReturnHasSecondBadge() == false)
        {
            interactableTextBox.SetActive(true);
            canOpenGateTwo = false;
            interactableText.text = "You cannot progress just yet";
        }
        if (other.CompareTag("ThirdGate") && GameManager.Instance.ReturnHasThirdBadge() == true)
        {
            interactableTextBox.SetActive(true);
            canOpenGateThree = true;
            interactableText.text = "Open the third gate";
        }
        else if (other.CompareTag("ThirdGate") && !GameManager.Instance.ReturnHasThirdBadge() == false)
        {
            interactableTextBox.SetActive(true);
            canOpenGateThree = false;
            interactableText.text = "You cannot progress just yet";
        }
        if (other.CompareTag("FourthGate") && GameManager.Instance.ReturnHasFourthBadge() == true)
        {
            interactableTextBox.SetActive(true);
            canOpenGateFour = true;
            interactableText.text = "Go ahead and take the teleporter home!";
        }
        else if (other.CompareTag("FourthGate") && !GameManager.Instance.ReturnHasFourthBadge() == false)
        {
            interactableTextBox.SetActive(true);
            canOpenGateFour = false;
            interactableText.text = "You cannot progress just yet";
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
        if (CrossPlatformInputManager.GetButtonDown("InteractButton") && canOpenGateOne)
        {
            firstGate.SetActive(false);
        }
    }
    public void CanOpenTheSecondGate()
    {
       if (CrossPlatformInputManager.GetButtonDown("InteractButton") && canOpenGateTwo)
       {
            secondGate.SetActive(false);
        }
    }
    public void CanOpenTheThirdGate()
    {
        if (CrossPlatformInputManager.GetButtonDown("InteractButton") && canOpenGateThree)
        {
            thirdGate.SetActive(false);
        }
    }
    public void CanOpenTheFourthGate()
    {
        if (CrossPlatformInputManager.GetButtonDown("InteractButton") && canOpenGateFour)
        {
            fourthGate.SetActive(false);
        }
    }

    public TMP_Text ReturnInteractableText()
    {
        return interactableText;
    }

    public void InitalizeTheInteracbleText()
    {
        if (interactableTextBox.activeSelf)
        {
            // If active, set it inactive
            interactableTextBox.SetActive(false);
        }
        else
        {
            // If inactive, set it active
            interactableTextBox.SetActive(true);
        }
    }

    void DefeatFirstTrainer()
    {
        if(GameManager.Instance.ReturnHasFirstBadge())
        {
            Destroy(firstTrainer);
        }
    }
    void DefeatSecondTrainer()
    {
        if (GameManager.Instance.ReturnHasFirstBadge())
        {
            Destroy(secondTrainer);
        }
    }

    void DefeatThirdTrainer()
    {
        if (GameManager.Instance.ReturnHasFirstBadge())
        {
            Destroy(thirdTrainer);
        }
    }

    void DefeatFinalBoss()
    {
        if (GameManager.Instance.ReturnHasFirstBadge())
        {
            Destroy(finalBoss);
        }
    }

}
