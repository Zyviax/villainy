using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitQueue : MonoBehaviour
{
    public Transform unit1;
    public Transform unit2;

    private Vector3 coords;

    //public GameObject textObject;
    //private Text text;

    

    //public Queue<Transform> queue;


    public int maxResource = 10;
    public int usedResource = 0; //etc etc

    private void Start()
    {
        coords = new Vector3(0, 285, 0);

    }

    public void addUnit1()
    {
        Transform unit = Instantiate(unit1);
        unit.SetParent(transform);
        coords.y -= 45;
        usedResource += 3;
        unit.transform.localPosition = coords; //ignore all of this stuff lmao
        //queue.Enqueue(unit1);
    }
}
