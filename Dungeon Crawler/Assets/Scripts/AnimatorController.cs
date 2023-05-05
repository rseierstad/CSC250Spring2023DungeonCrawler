using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator anim;    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            anim.SetTrigger("Sprint");
        }
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            anim.SetTrigger("Sprint");
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            anim.SetTrigger("Sprint");
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            anim.SetTrigger("Sprint");
        }
        if(MasterControlProgram.run)
        {
            anim.SetTrigger("Sprint");
            MasterControlProgram.run = false;
        }
        if(MasterControlProgram.whereDidIComeFrom.Equals("?"))
        {
            anim.SetTrigger("Stop");
        }
        if(MasterControlProgram.attack)
        {
            anim.SetTrigger("Attack");
            MasterControlProgram.attack = false;
        }
        if(MasterControlProgram.receiveDamage)
        {
            anim.SetTrigger("Damage");
            MasterControlProgram.receiveDamage = false;
        }
        if(MasterControlProgram.death)
        {
            anim.SetTrigger("Die");
            MasterControlProgram.death = false;
        }
    }
}
