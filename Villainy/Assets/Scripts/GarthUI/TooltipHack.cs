using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipHack : MonoBehaviour
{
    public GameObject tooltipObj;

    void Start()
    {
        tooltipObj.SetActive(false);
    }

    public void ToggleOn()
    {
        tooltipObj.SetActive(true);
    }

    public void ToggleOff()
    {
        tooltipObj.SetActive(false);
    }
}
