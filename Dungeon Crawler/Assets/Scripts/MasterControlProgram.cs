public class MasterControlProgram
{
    public static int count = 0;
    public static string whereDidIComeFrom = "?";
    public static bool isExiting = true;
    private static bool isDungeonSetup = false;
    public static Dungeon cs = null;
    public static Player p = null;

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