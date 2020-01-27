using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /*
    Spells:
    0 = no spell selected
    1 = Stun Spell
    2 = Heal Spell
    3 = Speed Spell
         */
    static int currentSpell = 0;
    static Transform aimPrefab;

    static void useSpell(int spell)
    {
        currentSpell = spell;
    }

    private void Update()
    {
        if(currentSpell!=0)
        {

        }
    }
}
