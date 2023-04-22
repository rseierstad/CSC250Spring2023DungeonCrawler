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

    // Start is called before the first frame update
    void Start()
    {
        this.theMonster = new Monster("wizard");
        this.monsterSB.text = this.theMonster.getData();
        this.playerSB.text = MasterControlProgram.p.getData();
        this.theMatch = new DeathMatch(MasterControlProgram.p, this.theMonster, playerGO, monsterGO);
        print("Ready to fight!");
        this.activeFight = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) && this.activeFight == false)
        {
            print("Fighting");
            this.theMatch.fight();
            this.activeFight = true;
        }
    }
}
