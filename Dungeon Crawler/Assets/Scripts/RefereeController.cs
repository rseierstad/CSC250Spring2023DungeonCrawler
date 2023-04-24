using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RefereeController : MonoBehaviour
{
    public GameObject monsterGO;
    public GameObject playerGO;
    public TextMeshPro monsterSB;
    public TextMeshPro playerSB;
    private Monster theMonster;
    private DeathMatch theMatch;
    public TextMeshPro turnText;
    private Rigidbody currRigidBodyOfAttacker;

    // Start is called before the first frame update
    void Start()
    {
        this.theMonster = new Monster("Wizard");
        this.monsterSB.text = this.theMonster.getData();
        this.playerSB.text = MasterControlProgram.p.getData();
        this.turnText.text = "Fight!";
        this.theMatch = new DeathMatch(MasterControlProgram.p, this.theMonster, this.playerGO, this.monsterGO, this);
        MasterControlProgram.playerShouldAttack = true;
        StartCoroutine(DelayBeforeFight());
    }

    IEnumerator DelayBeforeFight()
    {
        yield return new WaitForSeconds(0.5f);
        this.theMatch.fight();
    }

    // Update is called once per frame
    void Update()
    {
        this.monsterSB.text = this.theMonster.getData();
        this.playerSB.text = MasterControlProgram.p.getData();
        this.turnText.text = this.theMatch.turnText;

        if(MasterControlProgram.playerShouldAttack)
        {
            MasterControlProgram.playerShouldAttack = false;
            this.currRigidBodyOfAttacker = this.playerGO.GetComponent<Rigidbody>();
            this.attackerMoveDistance *= -1;
            this.attackerOriginalPosition = this.playerGO.tranform.position;

            //this tells our thread to start
            StartCoroutine(this.theMatch.MoveObjectRoutine());
        }

        if(MasterControlProgram.monsterShouldAttack)
        {
            MasterControlProgram.monsterShouldAttack = false;
            this.currRigidBodyOfAttacker = this.monsterGO.GetComponent<Rigidbody>();
            this.attackerOriginalPosition = this.monsterGO.tranform.position;

            //this tells our thread to start
            StartCoroutine(this.theMatch.MoveObjectRoutine());
        }
    }
}
