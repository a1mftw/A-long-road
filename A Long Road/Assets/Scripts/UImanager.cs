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
    public Text downText;
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

        slider1.value = manager.SliderValues[0];
        slider2.value = manager.SliderValues[1];
        slider3.value = manager.SliderValues[2];
        slider4.value = manager.SliderValues[3];
        slider5.value = manager.SliderValues[4];
        slider6.value = manager.SliderValues[5];

        for(int i=manager.actionList.Count-1; i >= 0; i--)
        {
            downText.text = "You "+manager.actionList[i].actionName+" you got "+manager.actionList[i].Slider1+" points in Action, "
                + manager.actionList[i].Slider2 + " points in Social," + manager.actionList[i].Slider3 +" points in Mastery,"
                + manager.actionList[i].Slider4 +" points in Achievement,"+ manager.actionList[i].Slider5 +" points in Immersion and"
                + manager.actionList[i].Slider6 +" points in Creativity. \n";
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
