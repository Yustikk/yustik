using Snake;

Coord GridDimension= new Coord(50,20);
Coord SnakePos= new Coord(10,10);
Random rand = new Random();
Coord ApplePos= new Coord(rand.Next(1,GridDimension.X-1),rand.Next(1,GridDimension.Y-1));
int FrameDelay = 130;
Direction MovementDirection = Direction.up;
List<Coord> SnakeCoordHistory = new List<Coord>();
int tailLEnght = 0,Level=1,movementType;

string Highscore = File.ReadAllText("HighScore.txt");

Console.WriteLine("Choose Movement type: 0=4 arrows, 2=2arrows");
if("0"==Console.ReadLine())
{ movementType = 0; } else { movementType=1; }

bool IsAlive=true;
while(IsAlive)
{
    if(tailLEnght%5==0 && tailLEnght!=0)
    {
        tailLEnght++;
        FrameDelay -= 20;
        Level++;
    }
    
    Console.Clear();
    
    Console.WriteLine("Score: " + tailLEnght+"\nLevel: "+Level+"\nHigh Score: "+Highscore);
    SnakePos.ApplyMovement(MovementDirection);
    for (int y = 0; y < GridDimension.Y; y++)
    {
        for (int x = 0; x < GridDimension.X; x++)
        {
            Coord CurrentCoord = new Coord(x, y);
            if (x == 0 || y == 0 || x == GridDimension.X - 1 || y == GridDimension.Y - 1)
            {
                if (SnakePos.Equals(CurrentCoord))
                {
                    /*
                        if(x==0 || x==GridDimension.X -1) SnakePos.x=GridDimension.X-1-x;
                        if(y==0 || y==GridDimension.Y-1) SnakePos.y=GridDimension.Y-1-y;
                    */
                    IsAlive = false;
                }

                Console.Write("#");
            }
            else
            {
                if (ApplePos.Equals(CurrentCoord) && SnakePos.Equals(CurrentCoord))
                {
                    ApplePos = new Coord(rand.Next(1, GridDimension.X - 1), rand.Next(1, GridDimension.Y - 1));
                    //increase snake lenght
                    tailLEnght++;
                }
                else
                {
                    if (SnakePos.Equals(CurrentCoord) || SnakeCoordHistory.Contains(CurrentCoord))
                    {
                        if (SnakePos.Equals(CurrentCoord) && SnakeCoordHistory.Contains(CurrentCoord))
                        {
                            IsAlive = false;
                        }
                        Console.Write("■");
                    }
                    else
                    {
                        if (ApplePos.Equals(CurrentCoord))
                        {
                            Console.Write("a");
                        }
                        else { Console.Write(" "); };
                    }
                }
            
            }
        }
        Console.WriteLine();
    }
    SnakeCoordHistory.Add(new Coord(SnakePos.X, SnakePos.Y));
    DateTime Time = DateTime.Now;

    if(SnakeCoordHistory.Count > tailLEnght)    
    {
        SnakeCoordHistory.RemoveAt(0);
    }

    while ((DateTime.Now-Time).Milliseconds < FrameDelay)
    {
        if(Console.KeyAvailable)
        {
            ConsoleKey key = Console.ReadKey().Key;
            switch (key)
            {
                case (ConsoleKey.LeftArrow):
                    {
                        //MovementDirection = Direction.left;
                        if(movementType==1)
                        {
                                 if (MovementDirection.Equals(Direction.left)) { MovementDirection = Direction.down; } else //works
                                if (MovementDirection.Equals(Direction.right)) { MovementDirection = Direction.up; }else
                                if (MovementDirection == Direction.down) { MovementDirection = Direction.right; }else
                                if (MovementDirection == Direction.up) { MovementDirection = Direction.left; } 
                        }
                        else
                            MovementDirection=Direction.left;
                        
                        break;
                    }
                case (ConsoleKey.RightArrow):
                    {
                        if(movementType==0)
                        {
                            MovementDirection=Direction.right; break;
                        }
                        
                        if (MovementDirection == Direction.left) { MovementDirection = Direction.up; } else
                         if (MovementDirection == Direction.right) { MovementDirection = Direction.down; }else
                        if (MovementDirection == Direction.down) { MovementDirection = Direction.left; }else
                        if (MovementDirection == Direction.up) { MovementDirection = Direction.right; }
                        break;
                    }
                case ConsoleKey.UpArrow:
                    {
                        MovementDirection = Direction.up;
                        break;
                    }
                case (ConsoleKey.DownArrow):
                    {
                        MovementDirection = Direction.down; 
                        break;
                    }
            }
        }
        
    }
    
}
Console.WriteLine("You lost. Tail Lenght: "+tailLEnght);
if(int.Parse(Highscore)<tailLEnght)
File.WriteAllText("HighScore.txt",tailLEnght.ToString());
Console.ReadLine();