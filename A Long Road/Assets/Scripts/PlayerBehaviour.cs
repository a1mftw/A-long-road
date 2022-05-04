using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Animator myAnimator;
    private AnimatorClipInfo[] myClipInfo;
    private DialogueTrigger npcTrigger;
    private DialogueManager dialogueManager;
    private SpriteRenderer myRenderer;

    private bool isTurned;
    public bool inDialogue;

    Vector2 movement;
    Vector2 direction;

    public GameObject cursorSpriteObject;

    public Sprite[] cursorSprites;
    //int[3][3] arraydeints; [23, 534, 231, 3213]
    //                       [242, 3256, 21, 4515]
    //public int[] test;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myRenderer = GetComponent<SpriteRenderer>();
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //movement and blend tree anims
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        myAnimator.SetFloat("xAxis", Input.GetAxisRaw("Horizontal"));
        myAnimator.SetFloat("yAxis", Input.GetAxisRaw("Vertical"));

        //IdleTurned check
        if (Input.GetAxisRaw("Vertical") > 0)
            isTurned = true;
        else if (Input.GetAxisRaw("Vertical") <= 0)
        {
            if (Input.GetAxisRaw("Horizontal") > 0 || Input.GetAxisRaw("Horizontal") < 0 || Input.GetAxisRaw("Vertical") < 0)
                isTurned = false;
        }


        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            myAnimator.SetBool("isWalking", false);

            //idle check if turned
            if (isTurned)
                myAnimator.SetBool("isTurned", true);
            else
                myAnimator.SetBool("isTurned",false);
        }
        else
            myAnimator.SetBool("isWalking", true);

        //flipping
        if (Input.GetAxisRaw("Horizontal") > 0)
            myRenderer.flipX = true;
        else if(Input.GetAxisRaw("Horizontal") < 0)
            myRenderer.flipX = false;

        //movement
        direction = movement.normalized;

        //interact
        if (Input.GetKeyDown(KeyCode.E) && npcTrigger != null)
        {
            if(!inDialogue)
            {
                npcTrigger.TriggerDialogue();
                inDialogue = true;
            }
            else
            {
                dialogueManager.DisplayNextSentence(); 
            }
        }

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.transform.tag)
        {
            case "NPC":
                // collision.GetComponent<SpriteRenderer>().color = Color.red;
                //   cursorSpriteObject.GetComponent<SpriteRenderer>().sprite = variavel futura de tipo sprite
                npcTrigger = collision.GetComponent<DialogueTrigger>();
                //change cursor sprite to NPC sprite

                //move cursor to collision.transform.position
                cursorSpriteObject.transform.position = collision.GetComponentInChildren<Transform>().position - new Vector3(-1.2f, -1.2f);
                //activate sprite component
                cursorSpriteObject.GetComponent<SpriteRenderer>().enabled = true;
                break;


            case "Interactible":
                //change cursor sprite to Interactible sprite
                break;

            default:
                break;

        }
    }
       
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (transform.position.y > collision.transform.position.y && collision.CompareTag("NPC")) 
        {
            myRenderer.sortingOrder = -1;

        }
        else
        {
            myRenderer.sortingOrder = 1;
        }
    }
      

    private void OnTriggerExit2D(Collider2D collision)
    {
        //collision.GetComponent<SpriteRenderer>().color = Color.black;
        cursorSpriteObject.GetComponent<SpriteRenderer>().enabled = false;
        //destctivate sprite component cursor
        dialogueManager.EndDialogue();
        inDialogue = false;
        npcTrigger = null;
    }


}
