using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMatch
{
    private Inhabitant combatant1;
    private Inhabitant combatant2;
    private GameObject combatant1GO;
    private GameObject combatant2GO;
    public string turnText = "Fight!";
    private Rigidbody currRigidBodyOfAttacker;
    private Vector3 attackerOriginalPosition;
    private float attackMoveDistance = 1.5f;
    private Inhabitant currentAttacker;
    private GameObject currentAttackerGO;
    private Inhabitant currentTarget;
    private GameObject currentTargetGO;
    private MonoBehaviour refereeInstance;
    private Animator animatorTarget;

    public DeathMatch(Inhabitant combatant1, Inhabitant combatant2, GameObject combatant1GO, GameObject combatant2GO, MonoBehaviour refereeInstance)
    {
        this.combatant1 = combatant1;
        this.combatant2 = combatant2;
        this.combatant1GO = combatant1GO;
        this.combatant2GO = combatant2GO;
        this.currentAttacker = this.combatant2;
        this.currentAttackerGO = this.combatant2GO;
        this.currentTarget = this.combatant1;
        this.currentTargetGO = this.combatant1GO;
        this.refereeInstance = refereeInstance;
    }

    //this is basically a thread
    IEnumerator MoveObjectRoutine()
    {
        yield return new WaitForSeconds(1.0f);
        Vector3 originalPosition = this.attackerOriginalPosition;
        Vector3 targetPosition = originalPosition + this.currentAttackerGO.transform.forward * attackMoveDistance;

        this.turnText = this.currentAttacker.getName() + "'s Turn";

        ((RefereeController)this.refereeInstance).updateScore();

        this.currRigidBodyOfAttacker.MovePosition(targetPosition);

        yield return new WaitForSeconds(1.5f);

        //try to hit target here
        if(Dice.roll(20) >= this.currentTarget.getAC())
        {
            this.currentTarget.takeDamage(this.currentAttacker.getDamage());
            this.turnText = "Hit!";
        }
        else
        {
            this.turnText = "Miss!";
        }

        ((RefereeController)this.refereeInstance).updateScore();

        this.currRigidBodyOfAttacker.MovePosition(originalPosition);
        
        yield return new WaitForSeconds(0.5f);

        if(this.currentTarget.isDead())
        {
            //what happens when our fight is over?
            //1. Make the dead guy fall over (rotate)
            //2. Make the winner jump up and down (apply a force to a rigidbody)
            //3. Play Victory Music

            MasterControlProgram.victory = true;


            this.currentTargetGO.transform.position = this.currentTargetGO.transform.position + this.currentTargetGO.transform.forward * attackMoveDistance;
            this.currentTargetGO.transform.position = this.currentTargetGO.transform.position + this.currentTargetGO.transform.up * 0.5f;

            if(this.currentTarget == this.combatant1)
            {
                this.currentTargetGO.transform.eulerAngles = new Vector3(-90,-90,0);
            }
            if(this.currentTarget == this.combatant2)
            {
                this.currentTargetGO.transform.eulerAngles = new Vector3(-90,90,0);
            }

            for(int i = 0; i < 3; i++)
            {
                this.currRigidBodyOfAttacker.AddForce(Vector3.up * 400.0f);
                yield return new WaitForSeconds(0.3f);
                this.currRigidBodyOfAttacker.AddForce(Vector3.down * 600.0f);
                yield return new WaitForSeconds(0.3f);
                this.currRigidBodyOfAttacker.MovePosition(originalPosition);
                this.currRigidBodyOfAttacker.velocity = Vector3.zero;
                this.currRigidBodyOfAttacker.Sleep();
            }
        }
        else
        {
            //call the fight method again after this guy is done moving
            this.fight();
        }
    }

    public void fight()
    {   
        //System.Random r = new System.Random();
        
        //while(true)
        //{
            if(this.currentAttackerGO == this.combatant1GO)
            {
                this.currentAttackerGO = this.combatant2GO;
                this.currentAttacker = this.combatant2;
                this.currentTarget = this.combatant1;
                this.currentTargetGO = this.combatant1GO;
            }
            else
            {
                this.currentAttackerGO = this.combatant1GO;
                this.currentAttacker = this.combatant1;
                this.currentTarget = this.combatant2;
                this.currentTargetGO = this.combatant2GO;
            }

            this.attackerOriginalPosition = this.currentAttackerGO.transform.position;
            this.currRigidBodyOfAttacker = this.currentAttackerGO.GetComponent<Rigidbody>();

            //non-blocking line of code
            this.refereeInstance.StartCoroutine(MoveObjectRoutine());

            /*if(this.combatant1.hp > 0 && this.combatant2.hp > 0)
            {
                this.turnText = this.combatant1.getName() + "'s Turn";
                this.roll = r.Next(1, 21);
                if(this.roll >= this.com2ac)
                {
                    this.turnText = "Hit!";
                    this.combatant2.hp = this.combatant2.hp - this.com1damage;
                }
                else if(this.roll < this.com2ac)
                {
                    this.turnText = "Miss!";
                }

                if(this.combatant1.hp > 0 && this.combatant2.hp > 0)
                {
                    this.turnText = this.combatant2.getName() + "'s Turn";
                    this.roll = r.Next(1, 21);
                    if(this.roll >= this.com1ac)
                    {
                        this.turnText = "Hit!";
                        this.combatant1.hp = this.combatant1.hp - this.com2damage;
                    }
                    else if(this.roll < this.com1ac)
                    {
                        this.turnText = "Miss!";
                    }
                }
            }
            if(this.combatant1.hp <= 0)
            {
                this.turnText = this.combatant2.getName() + " has won!";
                //break;
            }
            if(this.combatant2.hp <= 0)
            {
                this.turnText = this.combatant1.getName() + " has won!";
                //break;
            }*/
        //}
    }

    public string getTurnText()
    {
        return this.turnText;
    }
}
