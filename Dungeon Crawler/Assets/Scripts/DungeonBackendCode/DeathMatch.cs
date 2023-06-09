using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    private IEnumerator JumpCoroutine()
    {
        float duration = 60f;   //1 minute
        float speed = 5f;
        float startTime = Time.time;
        Vector3 startPosition = this.currentAttackerGO.transform.position;

        while(Time.time - startTime < duration)
        {
            float newY = startPosition.y + Mathf.Sin((Time.time - startTime) * speed) * 0.5f;
            this.currentAttackerGO.transform.position = new Vector3(this.currentAttackerGO.transform.position.x, newY, this.currentAttackerGO.transform.position.z);

            yield return null;
        }
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

        if(this.currentAttacker == this.combatant1)
        {
            MasterControlProgram.attack = true;
        }

        yield return new WaitForSeconds(1.0f);

        //try to hit target here;
        if(Dice.roll(20) >= this.currentTarget.getAC())
        {
            this.currentTarget.takeDamage(this.currentAttacker.getDamage());
            this.turnText = "Hit!";
            if(this.currentTarget == this.combatant1)
            {
                MasterControlProgram.receiveDamage = true;
            }
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
            this.currentTargetGO.transform.position = this.currentTargetGO.transform.position + this.currentTargetGO.transform.forward * attackMoveDistance;
            this.currentTargetGO.transform.position = this.currentTargetGO.transform.position + this.currentTargetGO.transform.up * 0.5f;

            if(this.currentTarget == this.combatant1)
            {
                MasterControlProgram.death = true;
            }
            if(this.currentTarget == this.combatant2)
            {
                this.currentTargetGO.transform.eulerAngles = new Vector3(-90,90,0);
            }
            
            this.refereeInstance.StartCoroutine(JumpCoroutine());

            if(this.currentAttackerGO == this.combatant1GO)
            {
                ((RefereeController)this.refereeInstance).PlayVictoryMusic();
            }
            else
            {
                //play sad music;
                ((RefereeController)this.refereeInstance).PlayDefeatMusic();
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
    }

    public string getTurnText()
    {
        return this.turnText;
    }
}
