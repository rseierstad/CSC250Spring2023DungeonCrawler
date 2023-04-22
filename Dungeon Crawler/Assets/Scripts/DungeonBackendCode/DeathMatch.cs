using System;
using System.Threading;
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
    private int com1hp, com2hp;
    private int com1ac, com2ac;
    private int com1damage, com2damage;

    public DeathMatch(Inhabitant combatant1, Inhabitant combatant2, GameObject combatant1GO, GameObject combatant2GO)
    {
        this.combatant1 = combatant1;
        this.combatant2 = combatant2;
        this.combatant1GO = combatant1GO;
        this.combatant2GO = combatant2GO;
        this.com1hp = this.combatant1.getHP();
        this.com1ac = this.combatant1.getAC();
        this.com1damage = this.combatant1.getDamage();
        this.com2hp = this.combatant2.getHP();
        this.com2ac = this.combatant2.getAC();
        this.com2damage = this.combatant2.getDamage();
    }

    public void fight()
    {
        //goes back and forth having our Inhabitants "try" to attack each other
        //a successful attack means that a D20 is at least as high as the target's AC
        //upon successful attack, the target's HP will reduce by the attacker's damage
        //an unsuccessful attack results in no change in HP
        //go back and forth like this until an Inhabitant dies
        
        System.Random r = new System.Random();

        if(this.com1hp > 0 && this.com2hp > 0)
        {
            this.roll = 20;
            if(this.roll >= this.com2ac)
            {
                this.com2hp = this.com2hp - this.com1damage;
            }

            if(this.com1hp > 0 && this.com2hp > 0)
            {
                this.roll = 20;
                if(this.roll >= this.com1ac)
                {
                    this.com1hp = this.com1hp - this.com2damage;
                }
            }
        }
        /*if(this.com1hp > 0 && this.com2hp <= 0)
        {
            return this.combatant1.getName();
            break;
        }
        if(this.com2hp > 0 && this.com1hp <= 0)
        {
            return this.combatant2.getName();
            break;
        }*/
    }

    /*public void attack(Inhabitant attacker)
    {
        System.Random r = new System.Random();
        if(attacker.getName().Equals(this.combatant1.getName()))
        {
            this.combatant1GO.transform.position = new Vector3(2f, 0.5f, 0);
            Thread.Sleep(1000);
            this.roll = r.Next(1, 21);
            if(this.roll >= this.com2ac)
            {
                this.com2hp = this.com2hp - this.com1damage;
            }
            this.combatant1GO.transform.position = new Vector3(2.5f, 0.5f, 0);
            Thread.Sleep(1000);
        }
        if(attacker.getName().Equals(this.combatant2.getName()))
        {
            this.combatant2GO.transform.position = new Vector3(-2f, 0.5f, 0);
            Thread.Sleep(1000);
            this.roll = r.Next(1, 21);
            if(this.roll >= this.com1ac)
            {
                this.com1hp = this.com1hp - this.com2damage;
            }
            this.combatant2GO.transform.position = new Vector3(-2.5f, 0.5f, 0);
            Thread.Sleep(1000);
        }
    }*/
}
