public class Room
{
    private string name;
    private Exit[] theExits;
    private int numberOfExits;
    private Player[] thePlayers;
    private int currentNumberOfPlayers;
    private Monster[] theMonsters;
    private int currentNumberOfMonsters;
    
    public Room(string name)
    {
        this.name = name;
        this.theExits = new Exit[4];
        this.numberOfExits = 0;
        this.thePlayers = new Player[25];
        this.currentNumberOfPlayers = 0;
        this.theMonsters = new Monster[25];
        this.currentNumberOfMonsters = 0;
    }
    
    public int getNumberOfPlayers()
    {
        return this.currentNumberOfPlayers;
    }
    
    public boolean hasExit(string direction)
    {
        for(int i = 0; i < this.numberOfExits; i++)
        {
            if(this.theExits[i].getDirection().equals(direction))
            {
                return true;
            }
        }
        return false;
    }
    
    public void takeExit(Monster who, string direction)
    {
        Exit theExitToTake = null;
        for(int i = 0; i < this.numberOfExits; i++)
        {
            if(this.theExits[i].getDirection().equalsIgnoreCase(direction))
            {
                theExitToTake = this.theExits[i];
                break;
            }
        }
        
        //did we find an exit?
        if(theExitToTake == null)
        {
            System.err.println("****** Exit not found! ******");
        }
        else
        {
            //remove player from this room
            this.removeMonsterFromRoom(who);
            theExitToTake.addMonster(who);
        }
    }
    
    public void takeExit(Player who, string direction)
    {
        Exit theExitToTake = null;
        for(int i = 0; i < this.numberOfExits; i++)
        {
            if(this.theExits[i].getDirection().equalsIgnoreCase(direction))
            {
                theExitToTake = this.theExits[i];
                break;
            }
        }
        
        //did we find an exit?
        if(theExitToTake == null)
        {
            System.err.println("****** Exit not found! ******");
        }
        else
        {
            //remove player from this room
            this.removePlayerFromRoom(who);
            theExitToTake.addPlayer(who);
        }
    }
    
    private void removePlayerFromRoom(Player p)
    {
        for(int i = 0; i < this.currentNumberOfPlayers; i++)
        {
            if(this.thePlayers[i] == p)
            {
                for(int j = i+1; j < this.currentNumberOfPlayers; j++)
                {
                    this.thePlayers[j-1] = this.thePlayers[j];
                }
                this.currentNumberOfPlayers--;
                return;
            }
        }
    }
    
    private void removeMonsterFromRoom(Monster m)
    {
        for(int i = 0; i < this.currentNumberOfMonsters; i++)
        {
            if(this.theMonsters[i] == m)
            {
                for(int j = i+1; j < this.currentNumberOfMonsters; j++)
                {
                    this.theMonsters[j-1] = this.theMonsters[j];
                }
                this.currentNumberOfMonsters--;
                return;
            }
        }
    }
    
    public void addMonster(Monster m)
    {
        this.theMonsters[this.currentNumberOfMonsters] = m;
        this.currentNumberOfMonsters++;
        m.setCurrentRoom(this);
    }
    
    public void addPlayer(Player p)
    {
        this.thePlayers[this.currentNumberOfPlayers] = p;
        this.currentNumberOfPlayers++;
        
        p.setCurrentRoom(this);
    }
    
    public void display()
    {
        System.out.println("Room: " + this.name);
        
        //build the exit string
        string exitstring = "";
        
        for(int i = 0; i < this.numberOfExits; i++)
        {
            exitstring = exitstring + this.theExits[i].getDirection() + " ";
        }
        System.out.println("Obvious Exits: " + exitstring);
        
        //build our player string
        string playerstring = "";
        for(int i = 0; i < this.currentNumberOfPlayers; i++)
        {
            playerstring = playerstring + this.thePlayers[i].getName() + " ";
        }
        System.out.println("Also here: " + playerstring);
        
        //build our monster string
        string monsterstring = "";
        for(int i = 0; i < this.currentNumberOfMonsters; i++)
        {
            monsterstring = monsterstring + this.theMonsters[i].getName() + " ";
        }
        System.out.println("Lurking Around: " + monsterstring);
    }
    
    public void addExit(Exit e)
    {
        if(this.numberOfExits < 4)
        {
            this.theExits[this.numberOfExits] = e;
            this.numberOfExits++;
        }
        else
        {
            System.err.println("Too Many Exits!!!!");
        }
    }
    
}