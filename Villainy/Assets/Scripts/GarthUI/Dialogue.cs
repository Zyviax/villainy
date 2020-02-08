using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public List<string> panels;
    private int panelNo;

    private GameObject parent;

    public GameObject next;
    public GameObject prev;


    // Start is called before the first frame update
    void Start()
    {
        parent = GameObject.FindWithTag("Dialogue");
        Transform child = parent.GetComponentsInChildren<Transform>(true)[1];
        child.gameObject.SetActive(false);
        panelNo = 0;
        prev.SetActive(false);
        if(panels.Count > 0)
        {
            child.gameObject.SetActive(true);
            Text text = parent.GetComponentInChildren<Text>();
            text.text = panels[panelNo] + "\n" + panelNo;
        }
    }

    public void NextPanel()
    {
        prev.SetActive(true);
        Text text = parent.GetComponentInChildren<Text>();
        if(panelNo+1 < panels.Count)
        {
            next.SetActive(true);
            text.text = panels[++panelNo] + "\n" + panelNo;
        }
        if(panelNo+1 == panels.Count) {
            next.SetActive(false);
        }
        
    }

    public void PrevPanel()
    {
        next.SetActive(true);
        Text text = parent.GetComponentInChildren<Text>();
        if(panelNo > 0)
        {
            text.text = panels[--panelNo] + "\n" + panelNo;
        }
        if(panelNo == 0)
        {
            prev.SetActive(false);
        }
    }
}
