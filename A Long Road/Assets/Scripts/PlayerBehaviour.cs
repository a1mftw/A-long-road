using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;

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
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        direction = movement.normalized;

        //if (Input.GetKeyDown(KeyCode.E))
        //    CheckInteraction();

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
                collision.GetComponent<SpriteRenderer>().color = Color.red;
             //   cursorSpriteObject.GetComponent<SpriteRenderer>().sprite = variavel futura de tipo sprite

                //change cursor sprite to NPC sprite
                break;

            case "Interactible":
                //change cursor sprite to Interactible sprite
                break;

            default:
                break;

        }

        //move cursor to collision.transform.position
        cursorSpriteObject.transform.position = collision.GetComponentInChildren<Transform>().position;
        //activate sprite component
        cursorSpriteObject.GetComponent<SpriteRenderer>().enabled = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.GetComponent<SpriteRenderer>().color = Color.black;
        cursorSpriteObject.GetComponent<SpriteRenderer>().enabled = false;
        //destctivate sprite component cursor
    }
}
