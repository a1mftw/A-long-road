using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InventorySystem : MonoBehaviour
{


    public bool ball = false;
    public bool ladder = false;
    public bool holding = false;
    bool nextToObject = false;
    private bool hasPickedBall = false;
    private bool hasPickedLadder = false;
    private bool hasSavedCat = false;
    GameObject go;
    GameObject holdingObject;
    public GameObject ladderPrefab;
    public GameObject ballPrefab;
    public GameObject holder;
    private StatisticManager manager;


    private void Start()
    {
        manager = GameObject.Find("StatisticManager").GetComponent<StatisticManager>();
    }

    private void PickUp(GameObject item)
    {
        if (item.name.Contains("ball"))
        {
            //action add
            //if(!hasPickedBall)
            //{
            //    manager.AddNewAction("used the ball",20,0,10,10,0,10);
            //    hasPickedBall = true;
            //}

            Drop(item.transform);
            ball = true;
            item.transform.parent = holder.transform;
            item.transform.localPosition = Vector3.zero;
            item.GetComponent<CircleCollider2D>().enabled = false;


            holdingObject = item;
            nextToObject = false;
            holding = true;

        }
        else if(item.name.Contains("ladder"))
        {
            //if(!hasPickedLadder)
            //{
                
            //    hasPickedLadder = true;
            //}

            Drop(item.transform);
            ladder = true;
            item.transform.parent = holder.transform;
            item.transform.localPosition = Vector3.zero;
            item.GetComponent<BoxCollider2D>().enabled = false;


            holdingObject = item;
            nextToObject = false;
            holding = true;

        }
        else if(item.name.Contains("TREECAT"))
        {
            if(!hasSavedCat)
            {
                if(ball)
                    manager.AddNewAction("threw the ball at the cat", 20, 0, 10, 10, 0, 10);
                else if(ladder)
                    manager.AddNewAction("climbed the ladder and scared the cat", 0, 0, 10, 20, 0, 30);
                else
                    manager.AddNewAction("shook the cat out of the tree", 20, 0, 20, 10, 0, 40);
                item.GetComponent<Animator>().SetTrigger("Triggered");
                hasSavedCat = true;
            }
        }
    }


    public void Drop(Transform pos)
    {
        if (ladder)
        {
            ladder = false;
            holdingObject.transform.parent = null;
            holdingObject.transform.position = pos.position;
            holdingObject.GetComponent<BoxCollider2D>().enabled = true;
        }
        else if (ball)
        {
            ball = false;
            holdingObject.transform.parent = null;
            holdingObject.transform.position = pos.position;
            holdingObject.GetComponent<CircleCollider2D>().enabled = true;
        }
    }

    public void Drop()
    {
        if (ladder)
        {
            ladder = false;
            holdingObject.transform.parent = null;
            holdingObject.GetComponent<BoxCollider2D>().enabled = true;
        }
        else if (ball)
        {
            ball = false;
            holdingObject.transform.parent = null;
            holdingObject.GetComponent<CircleCollider2D>().enabled = true;
        }


        holding = false;
        holdingObject = null;
    }


    private void Update()
    {

      

        if (nextToObject && Input.GetKeyDown(KeyCode.E))
        {
            PickUp(go);
        }


        if (Input.GetKeyDown(KeyCode.Q) && holding)
        {
            Drop();
        }

        if (Input.GetAxisRaw("Horizontal") > 0)
            holder.transform.localPosition = new Vector2(2.1f, holder.transform.localPosition.y);
        else if (Input.GetAxisRaw("Horizontal") < 0)
            holder.transform.localPosition = new Vector2(-2.1f, holder.transform.localPosition.y);

        if(holding)
            GetComponent<Animator>().SetBool("isHolding",true);
        else
            GetComponent<Animator>().SetBool("isHolding", false);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Item")
        {
            nextToObject = true;
            go = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Item")
        {
            nextToObject = false;
            go = null;
        }
    }


}
