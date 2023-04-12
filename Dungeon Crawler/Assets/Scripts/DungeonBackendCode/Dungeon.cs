public class Dungeon
{
    //fields
    private Room[] theRooms;
    private Room startingRoom;
    private int currentNumberOfRooms; 
    
    public Dungeon(int maxRooms)
    {
        this.theRooms = new Room[maxRooms];
        this.currentNumberOfRooms = 0;
        this.startingRoom = null;
    }
    
    public void addPlayer(Player p)
    {
        this.startingRoom.addPlayer(p);
    }
    
    private void setStartingRoom(Room r)
    {
        this.startingRoom = r;
    }
    
    private void addRoom(Room r)
    {
        this.theRooms[this.currentNumberOfRooms] = r;
        this.currentNumberOfRooms++;
    }
    
    public void populateCSDepartment()
    {   
        //build rooms
        Room entrance = new Room("Entrance");
        Room h1 = new Room("H1");
        Room h2 = new Room("H2");
        Room h3 = new Room("H3");
        Room h4 = new Room("H4");
        Room h5 = new Room("H5");
        Room s118b = new Room("S118b");
        
        //build and set exits
        Exit e1 = new Exit("north", h1);
        entrance.addExit(e1);
        
        Exit e2 = new Exit("south", entrance);
        Exit e3 = new Exit("north", h2);
        h1.addExit(e2);
        h1.addExit(e3);
        
        Exit e4 = new Exit("south", h1);
        Exit e5 = new Exit("west", h3);
        Exit e6 = new Exit("east", h4);
        h2.addExit(e4);
        h2.addExit(e5);
        h2.addExit(e6);
        
        Exit e7 = new Exit("east", h2);
        h3.addExit(e7);
        
        Exit e8 = new Exit("west", h2);
        Exit e9 = new Exit("east", h5);
        h4.addExit(e8);
        h4.addExit(e9);
        
        Exit e10 = new Exit("west", h4);
        Exit e11 = new Exit("north", s118b);
        h5.addExit(e10);
        h5.addExit(e11);
        
        Exit e12 = new Exit("south", h5);
        s118b.addExit(e12);
        
        //set starting room
        this.setStartingRoom(entrance);
        
        //add rooms to dungeon in case we need to access the entire collection of rooms
        this.addRoom(entrance);
        this.addRoom(h1);
        this.addRoom(h2);
        this.addRoom(h3);
        this.addRoom(h4);
        this.addRoom(h5);
        this.addRoom(s118b);
    }
}