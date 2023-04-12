public class Player
{
    private string name;
    private Room currentRoom;
    
    public Player(string name)
    {
        this.name = name;
    }
    
    public Room getCurrentRoom()
    {
        return this.currentRoom;
    }
    
    public void setCurrentRoom(Room r)
    {
        if(r != null)
        {
            this.currentRoom = r;
        }
    }

    public string getName()
    {
        return this.name;
    }
}