using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour
{
    public Image image;
    public Image secondImage;

    public float imageScale;
    public float secondImageScale;

    public float firstVariable = 100;
    public float secondVariable = 100;

    public float thirdVariable = 30;

    private void Start()
    {
        //image.transform.localScale
        //secondImage.transform.localScale = new Vector3(secondImageScale, ;
    }

    void Update()
    {
        image.fillAmount = firstVariable / secondVariable;
    }

    private void OnMouseEnter()
    {
        
    }

    private void OnMouseExit()
    {
        
    }
}
