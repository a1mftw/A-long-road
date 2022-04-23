using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class StatisticManager : MonoBehaviour
{
    public struct Action
    {
        public int Slider1;
        public int Slider2;
        public int Slider3;
        public int Slider4;
        public int Slider5;
        public int Slider6;
    }


    public int Slider1 = 0;
    public int Slider2 = 0;
    public int Slider3 = 0;
    public int Slider4 = 0;
    public int Slider5 = 0;
    public int Slider6 = 0;

    public List<Action> actionList;

    public void Awake()
    {
        actionList = new List<Action>();
    }
    public void AddNewAction(int value1, int value2, int value3, int value4, int value5, int value6)
    {
        Action action = new Action()
        {
            Slider1 = value1,
            Slider2 = value2,
            Slider3 = value3,
            Slider4 = value4,
            Slider5 = value5,
            Slider6 = value6
        };
    }



    public void CalculateStats()
    {
        foreach (var action in actionList)
        {
            AddStats(action.Slider1, Slider1);
            AddStats(action.Slider2, Slider2);
            AddStats(action.Slider3, Slider3);
            AddStats(action.Slider4, Slider4);
            AddStats(action.Slider5, Slider5);
            AddStats(action.Slider6, Slider6);
        }
    }

    private void AddStats(int value, int slider)
    {
        if (slider + value > 100)
            slider = 100;
        else if (slider + value < -100)
            slider = -100;
        else
            slider += value;
    }

}
