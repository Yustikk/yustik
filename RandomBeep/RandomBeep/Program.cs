// See https://aka.ms/new-console-template for more information

Random random = new Random();


ConsoleKeyInfo abc=Console.ReadKey();
while(abc.Key !=ConsoleKey.Enter)
{
    int n = random.Next(3, 15);
    for (int i = 0; i < n; i++)
    {
        int a = random.Next(100, 8000), b = random.Next(50, 300);
        Console.WriteLine(a + " " + b);
        Console.Beep(a, b);
        
    }
    abc = Console.ReadKey();
    Console.WriteLine("\n\n\n\n");
}

/*
 * 2042 134
1932 185
729 203
2953 112
6881 269
1949 154
 * 
 */