using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class StatisticManager : MonoBehaviour
{
    public struct Action
    {
        public string actionName;
        public int Slider1;
        public int Slider2;
        public int Slider3;
        public int Slider4;
        public int Slider5;
        public int Slider6;
    }

    public int[] SliderValues = new int[] { 0,0,0,0,0,0};
    public List<Action> actionList;

    public void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        actionList = new List<Action>();
    }



    //Usar isto para adicionar uma nova acao
    public void AddNewAction(string name, int value1, int value2, int value3, int value4, int value5, int value6)
    {
        Action action = new Action()
        {
            actionName = name,
            Slider1 = value1,
            Slider2 = value2,
            Slider3 = value3,
            Slider4 = value4,
            Slider5 = value5,
            Slider6 = value6
        };

        //esqueceste-te disto pa
        actionList.Add(action);
    }


    //antes de mudar de scene usar esta funcao para calcular o valor final
    public void CalculateStats()
    {
        foreach (var action in actionList)
        {
            AddStats(action.Slider1, 0);
            AddStats(action.Slider2, 1);
            AddStats(action.Slider3, 2);
            AddStats(action.Slider4, 3);
            AddStats(action.Slider5, 4);
            AddStats(action.Slider6, 5);
        }
    }

    private void AddStats(int value, int slider)
    {
        if (SliderValues[slider] + value > 100)
            SliderValues[slider] = 100;
        else if (SliderValues[slider] + value < 0)
            SliderValues[slider] = 0;
        else
            SliderValues[slider] += value;
    }

}
