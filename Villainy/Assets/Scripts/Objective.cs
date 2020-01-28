using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objective : MonoBehaviour
{
    public float health;

    private float maxHealth;

    public Image HP;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        HP.fillAmount = health / maxHealth;

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
