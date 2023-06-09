using UnityEngine;

public class MasterControlProgram
{
    public static bool playerShouldAttack = false;
    public static bool monsterShouldAttack = false;
    public static int count = 0;
    public static string whereDidIComeFrom = "?";
    public static bool isExiting = true;
    private static bool isDungeonSetup = false;
    public static Dungeon cs = null;
    public static Player thePlayer = null;
    public static GameObject musicLooper = null;
    public static string victoryContinue = "?";
    public static bool victory = false;
    public static bool run = false;
    public static bool death = false;
    public static bool receiveDamage = false;
    public static bool attack = false;

    public static void setupDungeon()
    {
        if(MasterControlProgram.isDungeonSetup == false)
        {
            MasterControlProgram.cs = new Dungeon(100);
		    MasterControlProgram.cs.populateCSDepartment();
		    
		    MasterControlProgram.thePlayer = new Player("Rachel");
		    MasterControlProgram.cs.addPlayer(thePlayer);
    
            MasterControlProgram.isDungeonSetup = true;
        }
    }
}