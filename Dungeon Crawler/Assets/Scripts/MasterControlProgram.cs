using UnityEngine;

public class MasterControlProgram
{
    public static int count = 0;
    public static string whereDidIComeFrom = "?";
    public static bool isExiting = true;
    private static bool isDungeonSetup = false;
    public static Dungeon cs = null;
    public static Player p = null;
    public static int playerHP = Random.Range(10,21);
    public static int playerAC = Random.Range(10,18);
    public static int playerDamage = Random.Range(1,6);

    public static void setupDungeon()
    {
        if(MasterControlProgram.isDungeonSetup == false)
        {
            MasterControlProgram.cs = new Dungeon(100);
		    MasterControlProgram.cs.populateCSDepartment();
		    
		    MasterControlProgram.p = new Player("Rachel");
		    MasterControlProgram.cs.addPlayer(p);
    
            MasterControlProgram.isDungeonSetup = true;
        }
    }
}