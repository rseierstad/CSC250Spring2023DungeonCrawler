public class Player : Inhabitant
{
    public Player()
    {
    }
    
    public void play()
    {
        string line;
        while(true)
        {
            this.getCurrentRoom().display();
            System.out.print("What do you want to do? ");
            line = input.nextLine();
            
            if(line.equalsIgnoreCase("quit"))
            {
                System.out.println("Goodbye!!");
                break;
            }
            else if(line.equalsIgnoreCase("look"))
            {
                this.getCurrentRoom().display();
            }
            else
            {
                //you must have given me a direction
                this.getCurrentRoom().takeExit(this, line);
            }
        }
    }
    
}