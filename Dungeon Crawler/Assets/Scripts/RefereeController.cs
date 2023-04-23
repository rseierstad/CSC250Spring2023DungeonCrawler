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
    private bool activeFight;
    public GameObject attackPosition1;
    public GameObject attackPosition2;
    public TextMeshPro turnText;

    // Start is called before the first frame update
    void Start()
    {
        this.theMonster = new Monster("Wizard");
        this.monsterSB.text = this.theMonster.getData();
        this.playerSB.text = MasterControlProgram.p.getData();
        this.turnText.text = "Fight!";
        this.theMatch = new DeathMatch(MasterControlProgram.p, this.theMonster, this.playerGO, this.monsterGO, this.attackPosition1, this.attackPosition2);
        this.activeFight = false;
    }

    // Update is called once per frame
    void Update()
    {
        this.monsterSB.text = this.theMonster.getData();
        this.playerSB.text = MasterControlProgram.p.getData();
        this.turnText.text = this.theMatch.turnText;

        if(Input.GetKeyDown(KeyCode.UpArrow) && this.activeFight == false)
        {
            this.theMatch.fight();
            this.activeFight = true;
        }
    }
}
