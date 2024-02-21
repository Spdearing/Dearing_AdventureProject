using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    /// <summary>
    /// Player Elements
    /// </summary>
    private float walkingSpeed;
    private float sprintingSpeed;
    private Rigidbody2D rb;
    //private Animator animator;
    private SpriteRenderer spriteRenderer;

    private bool interactable;
    private TMP_Text interactableText;

    private GymOverWorldUI gymOverWorldUI;





    // Start is called before the first frame update
    void Start()
    {
        walkingSpeed = 2.0f;
        rb = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        interactableText = GameObject.Find("InteractableText").GetComponent<TMP_Text>();
        gymOverWorldUI = GameObject.Find("UIOverworldData").GetComponent <GymOverWorldUI>();
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

        if (Input.GetKeyDown(KeyCode.E) && interactable)
        {
            
            gymOverWorldUI.SavingPlayerPosition();
            SceneManager.LoadScene("GymBattleOne");

        }


        else if (CrossPlatformInputManager.GetButtonDown("InteractButton") && interactable)
        {
            
            gymOverWorldUI.SavingPlayerPosition();
            SceneManager.LoadScene("GymBattleOne");
            
        }
        else if(CrossPlatformInputManager.GetButtonDown("InteractButton") && !interactable)
        {
            Debug.Log("What are you doing");
        }

        //if (horizontalMovement < 0)
        //{
        //    spriteRenderer.flipX = true; 
        //}
        //else if (horizontalMovement > 0)
        //{
        //    spriteRenderer.flipX = false; 
        //}

        Debug.Log(interactable);
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("GymTrainerOne"))
        {
            interactable = true;
            interactableText.text = "Talk to the gym member!";
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("GymTrainerOne"))
        {
            interactable = false;
            interactableText.text = "";
        }
    }
}
