using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InventorySystem : MonoBehaviour
{


    bool ball = false;
    bool ladder = false;
    bool holding = false;
    bool nextToObject = false;
    GameObject go;
    GameObject holdingObject;
    public GameObject ladderPrefab;
    public GameObject ballPrefab;
    public GameObject holder;

    private void PickUp(GameObject item)
    {
        if (item.name.Contains("ball"))
        {
            Drop(item.transform);
            ball = true;
            item.transform.parent = holder.transform;
            item.transform.localPosition = Vector3.zero;
            item.GetComponent<CircleCollider2D>().enabled = false;

        }
        else if(item.name.Contains("ladder"))
        {
            Drop(item.transform);
            ladder = true;
            item.transform.parent = holder.transform;
            item.transform.localPosition = Vector3.zero;
            item.GetComponent<BoxCollider2D>().enabled = false;
            
        }

        holdingObject = item;
        nextToObject = false;
        holding = true;


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

        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    SceneManager.LoadScene(2);
        //}

        if (nextToObject && Input.GetKeyDown(KeyCode.E))
        {
            PickUp(go);
        }


        if (Input.GetKeyDown(KeyCode.Q) && holding)
        {
            Drop();
        }

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
