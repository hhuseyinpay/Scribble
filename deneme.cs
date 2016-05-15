using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace proje3
{
    class Program
    {
        #region Global Değişkenler
        static char[,] boardArray = {{'.', '.', '.', '.', '.', '.', '.','.', '.', '.', '.', '.', '.', '.','.'},
                                     {'.', '.', '.', '.', '.', '.', '.','.', '.', '.', '.', '.', '.', '.','.'},
                                     {'.', '.', '.', '.', '.', '.', '.','.', '.', '.', '.', '.', '.', '.','.'}, 
                                     {'.', '.', '.', '.', '.', '.', '.','.', '.', '.', '.', '.', '.', '.','.'},
                                     {'.', '.', '.', '.', '.', '.', '.','.', '.', '.', '.', '.', '.', '.','.'},    
                                     {'.', '.', '.', '.', '.', '.', '.','.', '.', '.', '.', '.', '.', '.','.'},
                                     {'.', '.', '.', '.', '.', '.', '.','.', '.', '.', '.', '.', '.', '.','.'},
                                     {'.', '.', '.', '.', '.', '.', '.','.', '.', '.', '.', '.', '.', '.','.'}, 
                                     {'.', '.', '.', '.', '.', '.', '.','.', '.', '.', '.', '.', '.', '.','.'},
                                     {'.', '.', '.', '.', '.', '.', '.','.', '.', '.', '.', '.', '.', '.','.'}, 
                                     {'.', '.', '.', '.', '.', '.', '.','.', '.', '.', '.', '.', '.', '.','.'},
                                     {'.', '.', '.', '.', '.', '.', '.','.', '.', '.', '.', '.', '.', '.','.'},
                                     {'.', '.', '.', '.', '.', '.', '.','.', '.', '.', '.', '.', '.', '.','.'}, 
                                     {'.', '.', '.', '.', '.', '.', '.','.', '.', '.', '.', '.', '.', '.','.'},
                                     {'.', '.', '.', '.', '.', '.', '.','.', '.', '.', '.', '.', '.', '.','.'}};
        static char[,] virtualBoardArray = new char[15, 15];
        static Random random = new Random();
        static string bag1 = "";
        static string bag2 = "";
        static string[] dic = new string[33015];
        static int[,] let = new int[26, 2];
        static int score = 0;
        static int score2 = 0;
        static int round = 0;
        #endregion

        static void IsMeaningful()
        {
            string word = "";
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    if (char.IsLetter(virtualBoardArray[i, j]))
                    {

                    }
                }   
            }
        }
        static void RandomBag(int x, int y)
        { 
            int rnd = 0;
            
            for (int i = 0; i < 7-x; i++)
            {
                while (true)
                {
                    rnd = random.Next(0, 26);
                    
                    if (y ==1 && let[rnd, 1] >= 0)
                    {
                        bag1 += Convert.ToChar(65 + rnd);
                        let[rnd, 1]--;
                        break;
                    }
                    if (y == 2 && let[rnd, 1] >= 0)
                    {
                        bag2 += Convert.ToChar(65 + rnd);
                        let[rnd, 1]--;
                        break;
                    }
                }
            }
        }
        static void PrintBoard(char[,] boardArray, int score,int score2, int round, string bag11, string bag22)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear();
            Console.WriteLine("       A:1 B:3 C:3 D:2  E:1 F:4 G:2 H:4 I:1 J:8 K:5 L:1 M:3\n       N:1 O:1 P:3 Q:10 R:1 S:1 T:1 U:1 V:4 W:4 X:8 Y:4 Z:10");
            Console.WriteLine(@"
+ - - - - - - - - - - - - - - - +
|                               |    
|                               |
|                               |   Player 1:             Player 2:
|                               |       
|                               |   
|                               |
|                               |   
|                               |   
|                               |   
|                               |       
|                               |   Returns : _ _ _ _ _ _ _
|                               |         
|                               |   Query : _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
|                               |   
|                               |
+ - - - - - - - - - - - - - - - +
");
            for (int y = 0; y < boardArray.GetLength(0); y++)
            {
                for (int x = 0; x < boardArray.GetLength(1); x++)
                {
                    Console.SetCursorPosition(2 * y + 2, x + 4);
                    Console.Write(boardArray[x, y]);
                }
            }

            Console.SetCursorPosition(36, 4);
            Console.Write("Round : " + round);

            Console.SetCursorPosition(36, 8);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Bag  : "); Console.ForegroundColor = ConsoleColor.DarkMagenta; 
            for (int i = 0; i < bag11.Length; i++)
			    Console.Write(bag11[i] + " ");
            Console.SetCursorPosition(36, 10);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Score: "); Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.Write(score);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(58, 8);
            Console.Write("Bag  : "); Console.ForegroundColor = ConsoleColor.DarkMagenta; 
            for (int i = 0; i < bag22.Length; i++)
			    Console.Write(bag22[i] + " ");
            Console.SetCursorPosition(58, 10);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Score: "); Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.Write(score2);
            Console.ResetColor();

        }
        static void Main(string[] args)
        {
            #region Read File 
            StreamReader d = File.OpenText("D://Belgeler/Desktop/Proje3/dic.txt");
            for (int i = 0; i < 33015; i++)
                dic[i] = d.ReadLine();
            d.Close();
            StreamReader l = File.OpenText("d:/Belgeler/Desktop/Proje3/let.txt");
            string[] split = new string[3];
            for (int i = 0; i < 25; i++)
            {
                split = l.ReadLine().Split(' ');
                let[i, 0] = Convert.ToInt32(split[1]);
                let[i, 1] = Convert.ToInt32(split[2]); 
            }
            l.Close();
            #endregion
            
            #region firstBags
            int rnd = 0;
            for (int i = 0; i < 7; i++)
            {
                while (true)
                {
                    rnd = random.Next(0,26);
                    if (let[rnd, 1] >= 0)
                    {
                        bag1 += Convert.ToChar(65 + rnd);
                        let[rnd, 1]--;
                        break;
                        
                    }
                }
                while (true)
	            {
                    rnd = random.Next(0,26);
                    if (let[rnd, 1] >= 0)
                    {
                        bag2 += Convert.ToChar(65 + rnd);
                        let[rnd, 1]--;
                        break;
                    }
	            }
            }
            #endregion

            PrintBoard(boardArray, score, score2, round, bag1, bag2);
            
            Console.ReadLine();
        }
    }
}
