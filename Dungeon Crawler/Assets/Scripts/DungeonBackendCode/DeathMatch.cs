using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMatch
{
    private Inhabitant combatant1;
    private Inhabitant combatant2;
    private GameObject combatant1GO;
    private GameObject combatant2GO;
    private int roll;
    private int com1ac, com2ac;
    private int com1damage, com2damage;
    private Vector3 attackPosition1, attackPosition2;
    private Vector3 combatant1StartPosition, combatant2StartPosition;
    public string turnText;

    public DeathMatch(Inhabitant combatant1, Inhabitant combatant2, GameObject combatant1GO, GameObject combatant2GO, GameObject attackPosition1, GameObject attackPosition2)
    {
        this.combatant1 = combatant1;
        this.combatant2 = combatant2;
        this.combatant1GO = combatant1GO;
        this.combatant2GO = combatant2GO;
        this.com1ac = this.combatant1.getAC();
        this.com1damage = this.combatant1.getDamage();
        this.com2ac = this.combatant2.getAC();
        this.com2damage = this.combatant2.getDamage();
        this.attackPosition1 = attackPosition1.transform.position;
        this.attackPosition2 = attackPosition2.transform.position;
        this.combatant1StartPosition = this.combatant1GO.transform.position;
        this.combatant2StartPosition = this.combatant2GO.transform.position;
        this.turnText = "Fight!";
    }

    public async Task fight()
    {
        //goes back and forth having our Inhabitants "try" to attack each other
        //a successful attack means that a D20 is at least as high as the target's AC
        //upon successful attack, the target's HP will reduce by the attacker's damage
        //an unsuccessful attack results in no change in HP
        //go back and forth like this until an Inhabitant dies
        
        System.Random r = new System.Random();
        
        while(true)
        {
            if(this.combatant1.hp > 0 && this.combatant2.hp > 0)
            {
                this.turnText = this.combatant1.getName() + "'s Turn";
                await Task.Delay(2000);
                this.roll = r.Next(1, 21);
                if(this.roll >= this.com2ac)
                {
                    this.turnText = "Hit!";
                    await Task.Delay(2000);
                    this.combatant2.hp = this.combatant2.hp - this.com1damage;
                }
                else if(this.roll < this.com2ac)
                {
                    this.turnText = "Miss!";
                    await Task.Delay(2000);
                }

                if(this.combatant1.hp > 0 && this.combatant2.hp > 0)
                {
                    this.turnText = this.combatant2.getName() + "'s Turn";
                    await Task.Delay(2000);
                    this.roll = r.Next(1, 21);
                    if(this.roll >= this.com1ac)
                    {
                        this.turnText = "Hit!";
                        await Task.Delay(2000);
                        this.combatant1.hp = this.combatant1.hp - this.com2damage;
                    }
                    else if(this.roll < this.com1ac)
                    {
                        this.turnText = "Miss!";
                        await Task.Delay(2000);
                    }
                }
            }
            if(this.combatant1.hp <= 0)
            {
                this.turnText = this.combatant2.getName() + " has won!";
                break;
            }
            if(this.combatant2.hp <= 0)
            {
                this.turnText = this.combatant1.getName() + " has won!";
                break;
            }
        }
    }
}
