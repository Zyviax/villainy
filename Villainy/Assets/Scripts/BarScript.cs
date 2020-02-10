using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class BarScript : MonoBehaviour
{
    public Image image;

    public int selected = 0;

    private int resourceMax;
    private float manaMax;

    private void Start()
    {
        resourceMax = GameyManager.levelResources;
        manaMax = GameyManager.levelMana;
    }

    private void Update()
    {
        switch (selected)
        {
            case 0:
                image.fillAmount = (float)GameyManager.levelResources / resourceMax;
                break;
            case 1:
                image.fillAmount = (float)GameyManager.levelMana / manaMax;
                break;
        }
        
    }
}
