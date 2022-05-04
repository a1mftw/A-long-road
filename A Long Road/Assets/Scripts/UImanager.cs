using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    // Start is called before the first frame update

    public Slider slider1;
    public Slider slider2;
    public Slider slider3;
    public Slider slider4;
    public Slider slider5;
    public Slider slider6;
    public Text topText;
    StatisticManager manager;
    void Start()
    {
        manager = GameObject.Find("StatisticManager").GetComponent<StatisticManager>();
        Populate();
    }

    void Populate()
    {

        if (manager.actionList.Count > 0)
        {
            topText.text = "Great job out there! Its wonderful to see someone who isn't boring! Thank you for playing!";
        }
        else
        {
            topText.text = "Well, nothing I can do if you chose to leave, one must take the path they find right! Thank you for playing!";
        }

        slider1.value = manager.Slider1;
        slider2.value = manager.Slider2;
        slider3.value = manager.Slider3;
        slider4.value = manager.Slider4;
        slider5.value = manager.Slider5;
        slider6.value = manager.Slider6;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
