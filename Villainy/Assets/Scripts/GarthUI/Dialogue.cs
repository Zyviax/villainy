using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
    public List<string> panels;
    public List<GameObject> highlights;
    private int panelNo;

    private GameObject parent;

    public GameObject next;
    public GameObject prev;


    // Start is called before the first frame update
    void Start()
    {
        parent = GameObject.FindWithTag("Dialogue");
        if(parent == null) return;
        Transform child = parent.GetComponentsInChildren<Transform>(true)[1];
        child.gameObject.SetActive(false);
        panelNo = 0;
        prev.SetActive(false);
        if(panels.Count > 0)
        {
            child.gameObject.SetActive(true);
            Text text = parent.GetComponentInChildren<Text>();
            text.text = panels[panelNo];
            text.text = text.text.Replace("\\n", "\n"); 
            ShowHighlight();
        }
    }

    void Update()
    {
        if(GameyManager.gameState != GameyManager.GameState.Tutorial)
        {
            if(parent == null) return;
            Transform child = parent.GetComponentsInChildren<Transform>(true)[1];
            child.gameObject.SetActive(false);
            foreach(GameObject hl in highlights) {
                if(hl != null)
                {
                    hl.SetActive(false);
                }
            }
            //LevelManager.tutorialDone = true;
        }
    }

    public void ExitTut()
    {
        GameyManager.gameState = GameyManager.GameState.Queue;
    }

    public void BeginTut()
    {
        //LevelManager.tutorialDone = false;
        //reload level
        GameyManager.visitedLevels.Remove(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameyManager.gameState = GameyManager.GameState.Tutorial;
    }

    public void NextPanel()
    {
        prev.SetActive(true);
        Text text = parent.GetComponentInChildren<Text>();
        if(panelNo+1 < panels.Count)
        {
            next.SetActive(true);
            text.text = panels[++panelNo];
            text.text = text.text.Replace("\\n", "\n"); 
        }
        if(panelNo+1 == panels.Count) {
            next.SetActive(false);
        }
        ShowHighlight();
        
    }

    public void PrevPanel()
    {
        next.SetActive(true);
        Text text = parent.GetComponentInChildren<Text>();
        if(panelNo > 0)
        {
            text.text = panels[--panelNo];
            text.text = text.text.Replace("\\n", "\n"); 
        }
        if(panelNo == 0)
        {
            prev.SetActive(false);
        }
        ShowHighlight();
        
    }

    private void ShowHighlight()
    {
        if(panelNo-1 >= 0 && highlights[panelNo-1] != null) 
        {
            highlights[panelNo-1].SetActive(false);
        }
        
        if(panelNo < highlights.Count && highlights[panelNo] != null) 
        {
            highlights[panelNo].SetActive(true);
        }

        if(panelNo+1 < highlights.Count && highlights[panelNo+1] != null) 
        {
            highlights[panelNo+1].SetActive(false);
        }

        //if called next force user to click this element
        if(highlights[panelNo] != null && highlights[panelNo].name == "next")
        {
            next.SetActive(false);
        }
    }
}
