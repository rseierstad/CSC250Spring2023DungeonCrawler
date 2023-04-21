using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMatch
{
    private Inhabitant combatant1;
    private Inhabitant combatant2;
    private GameObject combatant1GO;
    private GameObject combatant2GO;

    public DeathMatch(Inhabitant combatant1, Inhabitant combatant2, GameObject combatant1GO, GameObject combatant2GO)
    {
        this.combatant1 = combatant1;
        this.combatant2 = combatant2;
        this.combatant1GO = combatant1GO;
        this.combatant2GO = combatant2GO;
    }

    public void fight()
    {
        //goes back and forth having our Inhabitants "try" to attack each other
        //a successful attack means that a D20 is at least as high as the target's AC
        //upon successful attack, the target's HP will reduce by the attacker's damage
        //an unsuccessful attack results in no change in HP
        //go back and forth like this until an Inhabitant dies
    }
}
