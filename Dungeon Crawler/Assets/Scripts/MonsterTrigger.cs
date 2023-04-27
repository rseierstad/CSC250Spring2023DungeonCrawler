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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
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
