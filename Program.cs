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

        static char[,] virtualBoardArray =
                                    {{'.', '.', '.', '.', '.', '.', '.','.', '.', '.', '.', '.', '.', '.','.'},
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
        static Random random = new Random();
        static string bag1 = ""; 
        static string bag2 = "";
        static string[] dic = new string[33015];
        static int[,] let = new int[26, 2];
        static int score = 0;
        static int score2 = 0;
        static int round = 0;
        static int passCounter = 0;
        static int direct = 0;
        static int wordx; // entered the first letter of the coordinates
        static int wordy; // entered the first letter of the coordinates
        static bool harfGirdiMi = false;
        static string tempBag = "";
        static string[] feedback = new string[30];
        static byte queryCounter = 0; 
        #endregion

        static void CombineBoards()
        {
            for (int i = 0; i < 15; i++)
                for (int j = 0; j < 15; j++)
                    if (virtualBoardArray[i,j] != '.')
                        boardArray[i, j] = virtualBoardArray[i, j];
        }
        static void resetVBA()
        {
            for (int y = 0; y < 15; y++)
            {
                for (int x = 0; x < 15; x++)
                {
                    virtualBoardArray[y, x] = '.';
                }
            }
        }
        
        static void Reader()
        {
            StreamReader d = File.OpenText("C:/Users/aaa/Desktop/proje3/dic.txt");
            for (int i = 0; i < 33012; i++)
                dic[i] = d.ReadLine();
            d.Close();
            StreamReader l = File.OpenText("C:/Users/aaa/Desktop/proje3/let.txt");
            string[] split = new string[3];
            for (int i = 0; i < 25; i++)
            {
                split = l.ReadLine().Split(' ');
                let[i, 0] = Convert.ToInt32(split[1]);
                let[i, 1] = Convert.ToInt32(split[2]);
            }
            l.Close();
        }
        static void RandomBag(int x, int y) // y = User && x = number of letter in the bag
        {
            int rnd = 0;

            for (int i = 0; i < 7 - x; i++)
            {
                while (true)
                {
                    rnd = random.Next(0, 26);

                    if (y == 1 && let[rnd, 1] >= 0)
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
        static void RemoveBag(int bagUser,string bag)
        {
            for (int y = 0; y < 15; y++)
            {
                for (int x = 0; x < 15; x++)
                {
                    if (virtualBoardArray[y,x] != '.') 
                    {
                        if (bagUser == 1) 
                            bag1 = bag1.Remove(bag1.IndexOf(virtualBoardArray[y, x]), 1);
                        else if (bagUser == 2)
                            bag2 = bag2.Remove(bag2.IndexOf(virtualBoardArray[y, x]), 1);
                    }
                }
            }
        }
        static bool query()
        {
            for (int i = 0; i < 30; i++) //First of all, reset feedback array which keep for result of query
                feedback[i] = null;

            int rX = 44;
            Console.SetCursorPosition(rX, 16);
            ConsoleKeyInfo cki;
            string sorgu = ""; // Keep to query in the background
            while (true)
            {
                bool flag3 = false;// Any sorgu?

                Console.SetCursorPosition(rX, 16);
                cki = Console.ReadKey(true);

                #region Letter that can be entered
                if (ConsoleKey.A <= cki.Key && cki.Key <= ConsoleKey.Z) 
                {
                    Console.Write(Convert.ToChar(cki.Key));
                    sorgu += Convert.ToChar(cki.Key);
                    if (rX < 56)
                        rX += 2;
                }
                else if (ConsoleKey.OemPeriod == cki.Key)
                {
                    Console.Write(".");
                    sorgu += '.';
                    if (rX < 56)
                        rX += 2;
                }
                #endregion

                #region Press Delete
                else if (ConsoleKey.Delete == cki.Key)
                {
                    sorgu = "";
                    Console.SetCursorPosition(44, 16);
                    Console.Write("_ _ _ _ _ _ _ _ _ _ _ _ _ _ _");
                    rX = 44;
                }
                #endregion

                #region Press Tab
                else if (ConsoleKey.Tab == cki.Key)
                {
                    feedback[0] = "-1";
                    return false;
                }
                #endregion

                #region Press Enter
                else if (ConsoleKey.Enter == cki.Key && sorgu != "")
                {
                    queryCounter++; 
                    bool flag2 = false;
                    for (int i = 0; i < 33012; i++) // Search in the dictionary according to sorgu 
                    {
                        if (sorgu.Length == dic[i].Length) 
                        {
                            flag2 = false;// Control of limit of sorgu 
                            bool flag = true;// Is meaningful sorgu
                            for (int j = 0; j < sorgu.Length; j++)
                            {
                                if (sorgu[j] == '.')
                                {
                                    continue;
                                }
                                else if (sorgu[j] != dic[i][j])
                                {
                                    flag = false;
                                    break;
                                }
                                flag = true;
                            }
                            if (flag) //appending to array
                            {
                                for (int j = 0; j < 30; j++)
                                {
                                    if (feedback[j] == null)
                                    {
                                        flag3 = true;
                                        feedback[j] = dic[i];
                                        break;
                                    }
                                    else if(j == 29)
                                    {
                                        flag2 = true;
                                        break;
                                    }
                                    
                                }
                            }
                            if (flag2) return true;
                        }
                    }
                    if (!flag3) return false;
                    else return true;
                }
                #endregion  
            }
            
        }

        static void GetInput(int user)
        {
            int x = 16; int y = 11;

            ConsoleKeyInfo cki;

            int cx = -1; // Control of cross at x
            int cy = -1; // Control of cross at y
            resetVBA();
            tempBag = "";
            if (user == 1)
                tempBag = bag1; // Copy of bag1 
            else tempBag = bag2; // Copy of bag2

            while (true)
            {
                Console.SetCursorPosition(x, y);
                cki = Console.ReadKey(true);

                #region Press ESC          
                if (cki.Key == ConsoleKey.Escape) 
                {
                    passCounter++;
                    resetVBA();
                    break;
                }
                #endregion

                #region Press Arrows
                else if (cki.Key == ConsoleKey.LeftArrow && x > 2)
                    x -= 2;
                else if (cki.Key == ConsoleKey.RightArrow && x < 30)
                    x += 2;
                else if (cki.Key == ConsoleKey.UpArrow && y > 4)
                    y--;
                else if (cki.Key == ConsoleKey.DownArrow && y < 18)
                    y++;
                #endregion

                #region Press TAB
                else if (cki.Key == ConsoleKey.Tab) 
                {
                    
                    int rX = 46;
                    bool brek = false; // break for this scope
                    string removed = ""; // string variable for return
                    while (true)
                    {
                        Console.SetCursorPosition(rX, 14);
                        cki = Console.ReadKey(true);

                        #region Press Arrow
                        if (rX <= 56 && cki.Key == ConsoleKey.RightArrow)
                            rX += 2;
                        else if (rX >= 48 && cki.Key == ConsoleKey.LeftArrow)
                            rX -= 2;
                        #endregion

                        else if (tempBag.Contains(Convert.ToChar(cki.Key)))
                        {
                            Console.Write(cki.Key);
                            tempBag = tempBag.Remove(tempBag.IndexOf(Convert.ToChar(cki.Key)), 1);
                            removed += Convert.ToChar(cki.Key);
                        }

                        #region Press Delete
                        else if (ConsoleKey.Delete == cki.Key)
                        {
                            if (user == 1) tempBag = bag1;
                            else tempBag = bag2;
                            removed = "";
                            PrintBoard(boardArray, score, score2, round, bag1, bag2);
                            Colourful(user);
                        }
                        #endregion

                        #region Press Tab
                        else if (ConsoleKey.Tab == cki.Key)
                        {
                            bool quer = query();
                            if (queryCounter > 3)
                            {
                                Console.SetCursorPosition(40, 18);
                                Console.WriteLine("Your query limits over!");
                                
                                break;
                            }
                            else if (quer)
                            {
                                for (int i = 0; i < 30; i++)
                                {
                                    if (feedback[i] != null)
                                    {
                                        if (i < 10)
                                        {
                                            Console.SetCursorPosition(40, 18 + i);
                                            Console.Write(feedback[i]);
                                        }
                                        else if (i >= 10 && i < 20)
                                        {
                                            Console.SetCursorPosition(56, 8 + i );
                                            Console.Write(feedback[i]);
                                        }
                                        else
                                        {
                                            Console.SetCursorPosition(72,  + i - 2);
                                            Console.Write(feedback[i]);
                                        }
                                    }
                                    else break; 
                                }
                                break;
                            }
                            else if (feedback[0] == "-1")
                            {
                                break;
                            }
                            else
                            {
                                Console.SetCursorPosition(40, 18);
                                Console.WriteLine("Not found!");
                                break;
                            }
                            
                        }
                        #endregion

                        #region Press Enter
                        else if (ConsoleKey.Enter == cki.Key)
                        {
                            if (bag1 == tempBag || bag2 == tempBag)  // Exception Handling
                                break;
                            passCounter = 0;
                            for (int i = 0; i < removed.Length; i++)
                            {
                                let[Convert.ToChar(removed[i]) - 65, 1]++;
                            }

                            if (user == 1) 
                                bag1 = tempBag;
                            else
                                bag2 = tempBag;

                            RandomBag(tempBag.Length, user);
                            PrintBoard(boardArray, score, score2, round, bag1, bag2);
                            Colourful(user);
                            brek = true;
                            break;
                        }
                        #endregion
                    }
                    if (brek == true) // Player change
                    {
                        break;
                    }
                    
                }
                #endregion

                #region Press DELETE
                else if (ConsoleKey.Delete == cki.Key)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    cx = -1;
                    cy = -1;
                    resetVBA();
                    if (user == 1)
                        tempBag = bag1;
                    else tempBag = bag2;
                    harfGirdiMi = false;
                    PrintBoard(boardArray, score, score2, round, bag1, bag2);
                    Colourful(user);
                }
                #endregion

                #region Press Letter
                else if (ConsoleKey.A <= cki.Key && cki.Key <= ConsoleKey.Z && boardArray[y - 4, (x - 2) / 2] == '.')
                {
                    if (tempBag.Contains(Convert.ToChar(cki.Key))) //eğer girmek istediği bagteki bir harf ise bu ife girer. //yukarıdaki if ile birleştir
                    {
                        #region Aynı hiza durumu
                        //girilen harflerin aynı hizada olmalarının kontrolü
                        if ((cx != -1 && cy != -1) && (cx != x && cy != y))
                        {
                            continue;
                        }

                        cx = x; cy = y;
                        #endregion

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(cki.Key); // bastığı key. 
                        harfGirdiMi = true;
                        virtualBoardArray[y - 4, (x - 2) / 2] = Convert.ToChar(cki.Key);


                        for (int i = 0; i < tempBag.Length; i++)
                        {
                            if (Convert.ToChar(cki.Key) == tempBag[i])
                            {
                                tempBag = tempBag.Remove(i, 1);
                                break;
                            }
                        }
                    }
                }
                #endregion

                #region Press Enter
                else if (cki.Key == ConsoleKey.Enter)
                {
                    string findword = FindWord();
                    if (!harfGirdiMi) continue;

                    else if (Meaningful(findword)) // is meaningful ?
                    {
                        passCounter = 0;
                        if (direct == 0) // for only one letter
                        {
                            if (user == 1 && Meaningful(VerticalLetter(wordx, wordy)))
                                score += CalculateScore(VerticalLetter(wordx, wordy));
                            if (user == 1 && Meaningful(HorizontalLetter(wordx, wordy)))
                                score += CalculateScore(HorizontalLetter(wordx, wordy));
                            if (user == 2 && Meaningful(VerticalLetter(wordx, wordy)))
                                score2 += CalculateScore(VerticalLetter(wordx, wordy));
                            if (user == 2 && Meaningful(HorizontalLetter(wordx, wordy)))
                                score2 += CalculateScore(HorizontalLetter(wordx, wordy));
                            RemoveBag(user, tempBag);
                            RandomBag(tempBag.Length, user);
                            resetVBA();
                            break;//break while
                        }

                        if (direct == 1) // is word horizontal?
                        {
                            if (user == 1)
                                score += CalculateScore(findword);
                            else score2 += CalculateScore(findword);

                            for (int i = wordx - 1; i >= 0; i--)// Clear head of findworld
                            {
                                if (boardArray[wordy, i] != '.')
                                {
                                    findword = findword.Remove(0, 1);
                                }
                                else break;
                            }
                            for (int i = 0; i < findword.Length; i++)
                            {
                                if (wordx + i < 15 && virtualBoardArray[wordy, wordx + i] != '.' && Meaningful(VerticalLetter(wordx + i, wordy))) //all of meaningful word?
                                {
                                    if (user == 1)
                                        score += CalculateScore(VerticalLetter(wordx + i, wordy));
                                    else score2 += CalculateScore(VerticalLetter(wordx + i, wordy));
                                }
                            }
                            RemoveBag(user, tempBag);
                            RandomBag(tempBag.Length, user);
                            CombineBoards();
                            resetVBA();
                            break;//break while
                        }
                        if (direct == 2) // is word vertical?
                        {
                            if (user == 1)
                                score += CalculateScore(findword);
                            else score2 += CalculateScore(findword);

                            for (int i = wordy - 1; i >= 0; i--) //Clear head of findworld
                            {
                                if (boardArray[i, wordx] != '.')
                                {
                                    findword = findword.Remove(0, 1);
                                }

                                else break;
                            }
                            for (int i = 0; i < findword.Length; i++)
                            {
                                if (wordy + i < 15 && virtualBoardArray[wordy + i, wordx] != '.' && Meaningful(HorizontalLetter(wordx + i, wordy))) //all of meaningful word?
                                {
                                    if (user == 1)
                                        score += CalculateScore(HorizontalLetter(wordx + i, wordy));
                                    else score2 += CalculateScore(HorizontalLetter(wordx + i, wordy));
                                }
                            }
                            RemoveBag(user, tempBag);
                            RandomBag(tempBag.Length, user);
                            CombineBoards(); // Combining boardArray and VirtualBoardArray
                            resetVBA();
                            break;//break while
                        }

                    }
                    
                    else
                    {
                        cx = -1;
                        cy = -1;
                        resetVBA();
                        if (user == 1)
                            tempBag = bag1;
                        else tempBag = bag2;
                        PrintBoard(boardArray, score, score2, round, bag1, bag2);
                        Colourful(user);
                        Console.SetCursorPosition(0, 22);
                        Console.Write("Try Again");
                        continue;
                    }
                }
                #endregion
            }
        }

        static bool Meaningful(string fWord)
        {
            for (int i = 0; i < 33015; i++)
                if (fWord == dic[i]) // Is word meaningful?
                    return true;
            return false;
        }
        static int CalculateScore(string fWord)
        {
            int fScore = 0;
            for (int i = 0; i < fWord.Length; i++)
                fScore += let[Convert.ToInt32(fWord[i]) - 65, 0];
            return fScore;
        }
        static string FindWord()
        {
            string findword = "";
            wordx = 0;
            wordy = 0;
            int count = 0;       // how many letters in the virtualboardarray?
            int count2 = 0;      // how many letters in the findword that player entered at the moment?
            bool flag = false; // Control for one time
            direct = 0;

            for (int y = 0; y < 15; y++)
                for (int x = 0; x < 15; x++)
                {
                    if (!flag && virtualBoardArray[y, x] != '.') 
                    {
                        wordx = x;
                        wordy = y;
                        flag = true;
                    }
                    if (virtualBoardArray[y, x] != '.')
                    {
                        count++;
                    }
                }
            #region Is there any letter on adjacent
            if (wordx != 14 && virtualBoardArray[wordy, wordx + 1] != '.')       // one-right letter on the horizontal
            {
                for (int x = wordx; x < 15; x++)
                {
                    if (virtualBoardArray[wordy, x] != '.')
                    {
                        findword += virtualBoardArray[wordy, x].ToString(); 
                        count2++;
                    }
                        
                    else if (boardArray[wordy, x] != '.')
                        findword += boardArray[wordy, x].ToString();
                    else { direct = 1; break; }
                }
                for (int x = wordx- 1; x >= 0; x--)// check to left
                {
                    if (boardArray[wordy, x] != '.')
                        findword = findword.Insert(0, boardArray[wordy, x].ToString());
                    else break;
                }
                if (count != count2)
                {
                    return "-1";
                }

            }
            else if (wordy != 14 && virtualBoardArray[wordy + 1, wordx] != '.')               // check vertical 
            {
                for (int y = wordy; y < 15; y++)
                {
                    if (virtualBoardArray[y, wordx] != '.')
                    {
                        findword += virtualBoardArray[y, wordx].ToString();
                        count2++;
                    }
                        
                    else if (boardArray[y, wordx] != '.')
                        findword += boardArray[y, wordx].ToString();
                    else { direct = 2; break; }
                }
                for (int y = wordy - 1; y >= 0; y--) //look for up
                {
                    if (boardArray[y, wordx] != '.')
                        findword = findword.Insert(0, boardArray[y, wordx].ToString());
                    else break;
                }
                if (count != count2)
                {
                    return "-1";
                }
            }
            #endregion
            else if (count == 1) // for only one letter
            {
                if (Meaningful(VerticalLetter(wordx,wordy)))
                    return VerticalLetter(wordx, wordy);
                else if (Meaningful(HorizontalLetter(wordx, wordy)))
                    return HorizontalLetter(wordx, wordy);
                return "-1";
            }
            else if (count >= 2) 
            {
                if (wordy < 14 && boardArray[wordy + 1, wordx] == '.' && wordx < 14 && boardArray[wordy, wordx + 1] == '.')//sağında ve aşşağısında boşluk varsa çık, her türlü iki harf girmiştir ve ikinci harf anlamsız bir yerdedir.
                    return  "-1";
                
                else
                {//eğer buraya giriyorsa virtualde en az 2 harf atanmıştır ve aralarında en az 1 boşluk vardır
                    

                    if (virtualBoardArray[wordy, wordx] != '.' && boardArray[wordy, wordx + 1] != '.')
                    {
                        for (int j = wordx; j < 15; j++)
                        {
                            if (virtualBoardArray[wordy, j] != '.')
                            {
                                findword += virtualBoardArray[wordy, j];
                                count2++;
                            }

                            else if (boardArray[wordy, j] != '.')
                                findword += boardArray[wordy, j];
                            else
                            {
                                direct = 1;
                                break;
                            }
                        }
                    }
                    
                    // Dikey
                    
                    if (virtualBoardArray[wordy, wordx] != '.' && boardArray[wordy + 1, wordx] != '.')
                    {
                        for (int j = wordy; j < 15; j++)
                        {
                            if (virtualBoardArray[j, wordx] != '.')
                            {
                                findword += virtualBoardArray[j, wordx];
                                count2++;
                            }
                            else if (boardArray[j, wordx] != '.')
                                findword += boardArray[j, wordx];
                            else
                            {
                                direct = 2;
                                break;
                            }
                        }
                    }
                    


                }
                if (count != count2)
                {
                    return "-1";
                }
            }

            return findword;
        }
        static string VerticalLetter(int fx, int fy) // Returns the word with the letter formed in the vertical.
        {
            // ^^
            string fWord = virtualBoardArray[fy, fx].ToString();
            for (int y = fy - 1; y >= 0; y--)
            {
                if (boardArray[y, fx] != '.')
                    fWord = fWord.Insert(0, boardArray[y, fx].ToString());
                else break;
            }
            // vv

            for (int y = fy + 1; y < 15; y++)
            {
                if (boardArray[y, fx] != '.')
                    fWord += boardArray[y, fx];
                else break;
            }

            return fWord;
        }
        static string HorizontalLetter(int fx, int fy) // Returns generated word with the letter of the horizontal.
        {
            // ==>
            string fWord = virtualBoardArray[fy, fx].ToString();
            for (int x = fx + 1; x < 15; x++)
            {
                if (boardArray[fy, x] != '.')
                    fWord += boardArray[fy, x];
                else break;
            }

            // <==
            for (int x = fx - 1; x >= 0; x--)
            {
                if (boardArray[fy, x] != '.')
                    fWord = fWord.Insert(0, boardArray[fy, x].ToString());
                else break;
            }

            return fWord;
        }

        static void Colourful(int user)
        {
            if (user == 1)
            {
                Console.SetCursorPosition(36, 6);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Player 1: ");
                Console.SetCursorPosition(59, 6);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Player 2: ");

            }
            else
            {
                Console.SetCursorPosition(59, 6);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Player 2: ");
                Console.SetCursorPosition(36, 6);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Player 1: ");
            }
        }
        static void PrintBoard(char[,] boardArray, int score, int score2, int round, string bag1, string bag2)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear();
            Console.WriteLine("       A:1 B:3 C:3 D:2  E:1 F:4 G:2 H:4 I:1 J:8 K:5 L:1 M:3\n       N:1 O:1 P:3 Q:10 R:1 S:1 T:1 U:1 V:4 W:4 X:8 Y:4 Z:10");
            Console.WriteLine(@"
+ - - - - - - - - - - - - - - - +
|                               |    
|                               |
|                               |                
|                               |       
|                               |   
|                               |
|                               |   
|                               |   
|                               |   
|                               |       
|                               |   Returns : _ _ _ _ _ _ _
|                               |         
|                               |   Query : _ _ _ _ _ _ _ _ _ _ _ _ _ _ _
|                               |   
|                               |
+ - - - - - - - - - - - - - - - +
");
            for (int y = 0; y < 15; y++) 
            {
                for (int x = 0; x < 15; x++)
                {
                    Console.SetCursorPosition(2 * x + 2, y + 4);
                    Console.Write(boardArray[y, x]);
                }
            }
            for (int y = 0; y < 15; y++)
            {
                for (int x = 0; x < 15; x++)
                {
                    if (virtualBoardArray[y, x] == '.')
                    {
                        continue;
                    }
                    else
                    {
                        Console.SetCursorPosition(2 * x + 2, y + 4);
                        Console.Write(virtualBoardArray[y, x]);
                    }
                }
            }

            Console.SetCursorPosition(36, 4);
            Console.Write("Round : " + round);

            Console.SetCursorPosition(36, 8);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Bag  : "); Console.ForegroundColor = ConsoleColor.DarkMagenta;
            for (int i = 0; i < bag1.Length; i++)
                Console.Write(bag1[i] + " ");
            Console.SetCursorPosition(36, 10);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Score: "); Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.Write(score);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(58, 8);
            Console.Write("Bag  : "); Console.ForegroundColor = ConsoleColor.DarkMagenta;
            for (int i = 0; i < bag2.Length; i++)
                Console.Write(bag2[i] + " ");
            Console.SetCursorPosition(58, 10);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Score: "); Console.ForegroundColor = ConsoleColor.DarkMagenta; Console.Write(score2);
            Console.ResetColor();

        }
        static void Main(string[] args)
        {
            Console.Title = "SCRABBLE";
            
            Reader();//read file
            
            RandomBag(0, 1);
            RandomBag(0, 2);

            while (true)
            {
                PrintBoard(boardArray, score, score2, round, bag1, bag2);
                if (passCounter > 3) // pass 
                    break;
                Colourful(1);
                GetInput(1);
                round++;
                PrintBoard(boardArray, score, score2, round, bag1, bag2);
                Colourful(2);
                queryCounter = 0; 
                GetInput(2);
                round++;
                queryCounter = 0; 
                if (passCounter > 3)
                    break;
            }
            Console.SetCursorPosition(35, 22);
            Console.ForegroundColor = ConsoleColor.White;
            if (score > score2)
                Console.WriteLine("Player1 Wins!");
            else if (score < score2)
                Console.WriteLine("Player2 Wins!");
            else
                Console.WriteLine("Tie");
            Console.ReadLine();
        }
    }
}
