using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarController : MonoBehaviour
{
    public GameObject tenPercent, twentyPercent, thirtyPercent, fourtyPercent, fiftyPercent;
    public GameObject sixtyPercent, seventyPercent, eightyPercent, ninetyPercent, hundredPercent;
    private float maxHP;
    private float hp;
    private float percent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.twentyPercent.SetActive(true);
        this.thirtyPercent.SetActive(true);
        this.fourtyPercent.SetActive(true);
        this.fiftyPercent.SetActive(true);
        this.sixtyPercent.SetActive(true);
        this.seventyPercent.SetActive(true);
        this.eightyPercent.SetActive(true);
        this.ninetyPercent.SetActive(true);
        this.hundredPercent.SetActive(true);

        this.maxHP = MasterControlProgram.thePlayer.getMaxHP();
        this.hp = MasterControlProgram.thePlayer.getHP();
        this.percent = this.hp/this.maxHP;
        if(this.percent <= 0.9)
        {
            this.hundredPercent.SetActive(false);
        }
        if(this.percent <= 0.8)
        {
            this.ninetyPercent.SetActive(false);
        }
        if(this.percent <= 0.7)
        {
            this.eightyPercent.SetActive(false);
        }
        if(this.percent <= 0.6)
        {
            this.seventyPercent.SetActive(false);
        }
        if(this.percent <= 0.5)
        {
            this.sixtyPercent.SetActive(false);
        }
        if(this.percent <= 0.4)
        {
            this.fiftyPercent.SetActive(false);
        }
        if(this.percent <= 0.3)
        {
            this.fourtyPercent.SetActive(false);
        }
        if(this.percent <= 0.2)
        {
            this.thirtyPercent.SetActive(false);
        }
        if(this.percent <= 0.1)
        {
            this.twentyPercent.SetActive(false);
        }
    }
}
