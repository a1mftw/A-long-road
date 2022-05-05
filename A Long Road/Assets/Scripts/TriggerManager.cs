using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject bigRoof;
    public GameObject firstRoof;
    public GameObject wall;
    public GameObject pillar;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Porche")
        {
            bigRoof.SetActive(true);
            firstRoof.SetActive(false);
            wall.SetActive(true);
            pillar.SetActive(true);
        }


        if (collision.name == "Hall")
        {
            bigRoof.SetActive(false);
            firstRoof.SetActive(false);
            wall.SetActive(false);
            pillar.SetActive(false);
        }


        if (collision.name == "Outside")
        {
            bigRoof.SetActive(true);
            firstRoof.SetActive(true);
            wall.SetActive(true);
            pillar.SetActive(true);
        }
    }


}
