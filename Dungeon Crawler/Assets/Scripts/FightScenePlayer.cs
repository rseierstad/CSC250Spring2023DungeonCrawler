using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FightScenePlayer : MonoBehaviour
{
    private int monster1HP, monster2HP, monster3HP;
    private int monster1AC, monster2AC, monster3AC;
    private int monster1Damage, monster2Damage, monster3Damage;
    public TextMeshProUGUI monster1Text, monster2Text, monster3Text;
    public TextMeshProUGUI monster1HPACText, monster2HPACText, monster3HPACText;
    public TextMeshProUGUI monster1DamageText, monster2DamageText, monster3DamageText;
    public TextMeshProUGUI playerText, playerHPACText, playerDamageText;

    // Start is called before the first frame update
    void Start()
    {
        this.monster1HP = Random.Range(10,21);
        this.monster1AC = Random.Range(10,18);
        this.monster1Damage = Random.Range(1,6);

        this.monster2HP = Random.Range(10,21);
        this.monster2AC = Random.Range(10,18);
        this.monster2Damage = Random.Range(1,6);

        this.monster3HP = Random.Range(10,21);
        this.monster3AC = Random.Range(10,18);
        this.monster3Damage = Random.Range(1,6);

        this.playerText.text = "Player";
        this.playerDamageText.text = "Damage: " + MasterControlProgram.playerDamage;
        this.monster1Text.text = "Monster 1";
        this.monster1DamageText.text = "Damage: " + this.monster1Damage;
        this.monster2Text.text = "Monster 2";
        this.monster2DamageText.text = "Damage: " + this.monster2Damage;
        this.monster3Text.text = "Monster 3";
        this.monster3DamageText.text = "Damage: " + this.monster3Damage;
    }

    // Update is called once per frame
    void Update()
    {
        this.playerHPACText.text = "HP: " + MasterControlProgram.playerHP + "  AC: " + MasterControlProgram.playerAC;
        
        this.monster1HPACText.text = "HP: " + this.monster1HP + "  AC: " + this.monster1AC;
        this.monster2HPACText.text = "HP: " + this.monster2HP + "  AC: " + this.monster2AC;
        this.monster3HPACText.text = "HP: " + this.monster3HP + "  AC: " + this.monster3AC;
    }
}
