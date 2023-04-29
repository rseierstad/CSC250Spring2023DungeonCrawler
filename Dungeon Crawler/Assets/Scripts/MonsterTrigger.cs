using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterTrigger : MonoBehaviour
{
    public bool enableFights = true;
    public double chanceToGetIntoFight = 30;

    // Start is called before the first frame update
    void Start()
    {
        if(!MasterControlProgram.whereDidIComeFrom.Equals("?"))
        {
            this.enableFights = false;
        }
        if(!MasterControlProgram.victoryContinue.Equals("?"))
        {
            this.enableFights = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(MasterControlProgram.whereDidIComeFrom.Equals("?"))
        {
            this.enableFights = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(this.enableFights)
        {
            int chanceToFight = Random.Range(1,100);

            if(chanceToFight <= this.chanceToGetIntoFight)
            {
                Destroy(MasterControlProgram.musicLooper);
                MasterControlProgram.musicLooper = null;

                SceneManager.LoadScene("Fight Scene");
            }
            else
            {
                print("No monsters found!");
            }
        }
    }
}
