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
    public GameObject fightJukebox;
    public GameObject victoryJukebox;

    // Start is called before the first frame update
    void Start()
    {
        this.theMonster = new Monster("Wizard");
        this.turnText.text = "Fight!";
        this.theMatch = new DeathMatch(MasterControlProgram.p, this.theMonster, this.playerGO, this.monsterGO, this);
        this.updateScore();
        StartCoroutine(DelayBeforeFight());
    }

    public void playVictoryMusic()
    {
        this.fightJukebox.SetActive(false);
        this.victoryJukebox.SetActive(true);
    }

    public void updateScore()
    {
        this.monsterSB.text = this.theMonster.getData();
        this.playerSB.text = MasterControlProgram.p.getData();
        this.turnText.text = this.theMatch.getTurnText();
    }

    IEnumerator DelayBeforeFight()
    {
        yield return new WaitForSeconds(1.0f);
        this.theMatch.fight();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
