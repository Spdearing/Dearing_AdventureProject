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
    private float sprintingSpeed;
    private Rigidbody2D rb;
    //private Animator animator;
    private SpriteRenderer spriteRenderer;

    private bool interactable;
    private bool canOpenGateOne;
    private TMP_Text interactableText;
    private GameObject interactableTextBox;
    private GameObject firstGate;
    




   

    // Start is called before the first frame update
    void Start()
    {
        canOpenGateOne = true;
        walkingSpeed = 2.0f;
        rb = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        interactableTextBox = GameObject.Find("InteractableTextBackGround");
        interactableText = GameObject.Find("InteractableText").GetComponent<TMP_Text>();
        interactableTextBox.SetActive(false);
        firstGate = GameObject.Find("FirstGate");


        playerPositionManager = PlayerPositionManager.Instance;
        Vector2 savedPosition = playerPositionManager.LoadPlayerPosition();
        transform.position = savedPosition;
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

    
        if (CrossPlatformInputManager.GetButtonDown("InteractButton") && interactable)
        {
            PlayerPositionManager.Instance.SavePlayerPosition(transform.position);
            SceneManager.LoadScene("GymBattleOne");
            
        }
        else if (CrossPlatformInputManager.GetButtonDown("InteractButton") && canOpenGateOne == true)
        {
            firstGate.SetActive(false);
        }

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
            interactable = true;
            interactableText.text = "Talk to the gym member!";
        }
        else if(other.CompareTag("FirstGate") && GameManager.Instance.ReturnHasFirstBadge() == true)
        {
            interactableTextBox.SetActive(true);
            canOpenGateOne = true;
            interactableText.text = "Open the gate to the next battle area";
        }
        if (other.CompareTag("FirstGate") && GameManager.Instance.ReturnHasFirstBadge() == false)
        {
            interactableTextBox.SetActive(true);
            canOpenGateOne = false;
            interactableText.text = "You cannot progress just yet";
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("GymTrainerOne"))
        {
            interactableTextBox.SetActive(false);
            interactable = false;
            interactableText.text = "";
        }
        else if (other.CompareTag("FirstGate"))
        {
            interactableTextBox.SetActive(false);
            interactableText.text = " ";
        }
    }
}
