using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolTip : MonoBehaviour
{
    public string toolTipText = "";
    private string currentToolTipText = "";
    private GUIStyle guiStyleFore;
    private GUIStyle guiStyleBack;

    // Start is called before the first frame update
    void Start()
    {
        guiStyleFore = new GUIStyle();
        guiStyleFore.normal.textColor = Color.white;
        guiStyleFore.alignment = TextAnchor.UpperLeft;
        guiStyleFore.fontSize = 35;
        guiStyleFore.wordWrap = true;
        guiStyleBack = new GUIStyle();
        guiStyleBack.normal.textColor = Color.black;
        guiStyleBack.alignment = TextAnchor.UpperLeft;
        guiStyleBack.fontSize = 35;
        guiStyleBack.wordWrap = true;
    }

    private void OnMouseEnter()
    {
        currentToolTipText = toolTipText;
        currentToolTipText = currentToolTipText.Replace("\\n", "\n");
    }
    private void OnMouseExit()
    {
        currentToolTipText = "";
    }

    private void OnGUI()
    {
        if(currentToolTipText!="")
        {
            float x = Event.current.mousePosition.x;
            float y = Event.current.mousePosition.y;
            GUI.Label(new Rect(x - 149, y + 23, 300, 60), currentToolTipText, guiStyleBack);
            GUI.Label(new Rect(x - 150, y + 20, 300, 60), currentToolTipText, guiStyleFore);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
