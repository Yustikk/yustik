///if i use console.ReadKey(true) nu va aparea litera in consola ca atunci cand apesi left arrow

string file = File.ReadAllText("Words.txt");
string[] words = file.Split(' ');
Random random = new Random();
file= "";
string Answer = "ARTIE";


Answer = words[random.Next(words.Length)];
Answer=Answer.ToUpper();

Console.WriteLine(Answer);
string Try="";
string letter;

bool Castigat=false;

for (int i = 0; i < 5 && !Castigat; i++)
{
    
    Console.WriteLine("_____");
    

    for(int j = 0; j < 5; j++)                          //reading every individual letter and adding them to the guess (Try) (this is done so it shows in capital letters as you write and you can only write 5 letters)
    {
        Console.SetCursorPosition(j, i);
        ConsoleKeyInfo key = Console.ReadKey(true);
            letter = Convert.ToString(key.KeyChar);
            Console.WriteLine(letter.ToUpper());
            Try = Try + letter;
 
    }

    Console.SetCursorPosition(0, i);
    Try=Try.ToUpper();
    if(Try.Equals(Answer))
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Castigat =true;
        Console.WriteLine("You Guessed the word : " + Answer+" ! ! !");
    }
    else
    for(int j = 0;j < 5;j++)
    {
            if (Answer[j] == Try[j])
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(Try[j]);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        else
        {
            bool gasit=false;
            for(int k = 0; k < 5; k++)
            {
                if (Answer[k] == Try[j]) {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(Try[j]);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    gasit = true;
                }
            }
            if(!gasit) { Console.Write(Try[j]); }

        }
        
    }
    Console.Write("\n");
    Try = "";
        


}
