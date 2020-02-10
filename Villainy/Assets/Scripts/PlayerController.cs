using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is probably not going to be used
public class PlayerController : MonoBehaviour
{
    /*
    Spells:
    0 = no spell selected
    1 = Stun Spell
    2 = Heal Spell
    3 = Speed Spell
         */

    //todo: different costs for different spells?

    int currentSpell = 0;
    public Transform aimPrefab;
    static SpellArea spellArea;

    public void useSpell(int spell)
    {
        if(currentSpell!=0)
        {
            spellArea.endCircle();
        }

        //hardcoded 100
        if(100 <= GameyManager.levelMana) {
            currentSpell = spell;
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Transform spellCircle = Instantiate(aimPrefab, new Vector3(mousePosition.x, mousePosition.y, 0), Quaternion.identity);
            spellArea = spellCircle.GetComponent<SpellArea>();
            spellArea.spell = spell;
            //todo: change the -= to not be hardcoded
            GameyManager.levelMana -= 100;
        }
        
    }

    void Update()
    {
        if (currentSpell != 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                spellArea.activateCircle();
                currentSpell = 0;
            }
            if(Input.GetMouseButtonDown(1))
            {
                currentSpell = 0;
                GameyManager.levelMana += 100;
                Destroy(spellArea.gameObject);
            }
        }
    }
}
