﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitQueue : MonoBehaviour
{
    public Transform unit1;
    public Transform unit2;

    public Vector3 coords = new Vector3(0,0,0);

    //public GameObject textObject;
    private Text text;

    

    //public Queue<Transform> queue;


    public int maxUnits = 10;
    public int noUnits = 0; //etc etc

    private void Start()
    {
        coords = new Vector3(0, 285, 0);

    }

    public void addUnit1()
    {
        Transform unit = Instantiate(unit1);
        unit.SetParent(transform);
        coords.y -= 45;
        noUnits++;
        unit.transform.localPosition = coords; //ignore all of this stuff lmao
        //queue.Enqueue(unit1);
    }

    public void addUnit2()
    {
        Transform unit = Instantiate(unit2);
        unit.SetParent(transform);
        coords.y -= 45;
        noUnits++;
        unit.transform.localPosition = coords;
        //queue.Enqueue(unit2);
    }
}
