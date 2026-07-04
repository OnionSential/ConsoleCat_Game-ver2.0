using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CatConsoleGameRELOAD
{
    class FileManager
    {
        static string currentDirectory = @"C:\ConsoleCatGame\Save_Game";

        public void Files()
        {
            while (true)
            {
                Console.Clear();
                DisplayCurrentDirectory();
                DisplayMenu();
                ProcessUserInput();

                ConsoleKeyInfo keyInfoFileRu = Console.ReadKey(true);
                if (keyInfoFileRu.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    break;
                }
            }
        }

        static void DisplayCurrentDirectory()
        {
            string folderPath = @"C:\ConsoleCatGame\Save_Game";
            string FileName = "save.json";
            string filePath = Path.Combine(folderPath, FileName);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                byte[] info = new System.Text.UTF8Encoding(true).GetBytes("");
                fs.Write(info, 0, info.Length);
            }

            Console.WriteLine($"Текущий каталог: {currentDirectory}");
            Console.WriteLine("--------------------------------------------------");

            try
            {
                var directories = Directory.GetDirectories(currentDirectory);
                foreach (var dir in directories)
                {
                    Console.WriteLine($"[DIR] {Path.GetFileName(dir)}");
                }

                var files = Directory.GetFiles(currentDirectory);
                foreach (var file in files)
                {
                    FileInfo info = new FileInfo(file);
                    Console.WriteLine($"[FILE] {info.Name} ({info.Length} bytes)");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            Console.WriteLine("--------------------------------------------------");
        }

        static void DisplayMenu()
        {
            Console.WriteLine("Команды:");
            Console.WriteLine("  cd <имя_папки>          - перейти в подпапку");
            Console.WriteLine("  open <имя_сохранения>   - загрузить сохранение");
            Console.WriteLine("  cd ..                   - перейти в предыдущий каталог");
            Console.WriteLine("  escape                  - нажмите escape для выхода");

            Console.Write("Введите команду: ");
        }

        static void ProcessUserInput()
        {
            string path = @"C:\ConsoleCatGame\Save_Game";
            Directory.CreateDirectory(path);

            string folderPath = @"C:\ConsoleCatGame\Save_Game";
            string FileName = "save.json";
            string filePath = Path.Combine(folderPath, FileName);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                byte[] info = new System.Text.UTF8Encoding(true).GetBytes("");
                fs.Write(info, 0, info.Length);
            }

            string input = Console.ReadLine();
            string[] parts = input.ToLower().Split(' ');
            string command = parts[0].ToLower();
            string[] originalParts = input.Split(' ');

            if (command == "cd" && parts.Length > 1)
            {
                string target = parts[1];
                if (target == "..")
                {
                    DirectoryInfo parentDir = Directory.GetParent(currentDirectory);
                    if (parentDir != null)
                    {
                        currentDirectory = parentDir.FullName;
                    }
                }
                else
                {
                    string newPath = Path.Combine(currentDirectory, target);
                    if (Directory.Exists(newPath))
                    {
                        currentDirectory = newPath;
                    }
                    else
                    {
                        Console.WriteLine("Папка не найдена.");
                        Console.ReadKey();
                    }
                }
            }
            else if (command == "open" && parts.Length > 1)
            {
                string fileName = originalParts[1];
                string fullPath = Path.Combine(currentDirectory, fileName);

                if (File.Exists(fullPath))
                {
                    try
                    {
                        Process.Start(new ProcessStartInfo(fullPath) { UseShellExecute = true });
                        Console.WriteLine($"Файл {fileName} открыт. Нажмите любую клавишу, чтобы вернуться в менеджер.");
                        Console.ReadKey();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Не удалось открыть файл: {ex.Message}");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Файл не найден.");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Неизвестная команда или неверный формат.");
                Console.ReadKey();
            }
        }

        public void FilesEnglish()
        {
            while (true)
            {
                Console.Clear();
                DisplayCurrentDirectoryEnglish();
                DisplayMenuEnglish();
                ProcessUserInputEnglish();
            }
        }

        static void DisplayCurrentDirectoryEnglish()
        {
            string folderPath = @"C:\ConsoleCatGame\Save_Game";
            string fileName = "save.json";
            string filePath = Path.Combine(folderPath, fileName);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                byte[] info = new System.Text.UTF8Encoding(true).GetBytes("");
                fs.Write(info, 0, info.Length);
            }

            Console.WriteLine($"Current catalog: {currentDirectory}");
            Console.WriteLine("--------------------------------------------------");

            try
            {
                var directories = Directory.GetDirectories(currentDirectory);
                foreach (var dir in directories)
                {
                    Console.WriteLine($"[DIR] {Path.GetFileName(dir)}");
                }

                var files = Directory.GetFiles(currentDirectory);
                foreach (var file in files)
                {
                    FileInfo info = new FileInfo(file);
                    Console.WriteLine($"[FILE] {info.Name} ({info.Length} bytes)");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.WriteLine("--------------------------------------------------");
        }

        static void DisplayMenuEnglish()
        {
            Console.WriteLine("Comands:");
            Console.WriteLine("  cd <folder_name>   - go to subfolder");
            Console.WriteLine("  open <save_name>   - load save");
            Console.WriteLine("  cd ..              - go to previous directory");
            Console.WriteLine("  escape             - press escape to exit ");

            Console.Write("Enter command: ");
        }

        static void ProcessUserInputEnglish()
        {
            string path = @"C:\ConsoleCatGame\Save_Game";
            Directory.CreateDirectory(path);

            string folderPath = @"C:\ConsoleCatGame\Save_Game";
            string FileName = "save.json";
            string filePath = Path.Combine(folderPath, FileName);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                byte[] info = new System.Text.UTF8Encoding(true).GetBytes("");
                fs.Write(info, 0, info.Length);
            }

            string input = Console.ReadLine();
            string[] parts = input.ToLower().Split(' ');
            string command = parts[0].ToLower();
            string[] originalParts = input.Split(' ');

            if (command == "cd" && parts.Length > 1)
            {
                string target = parts[1];
                if (target == "..")
                {
                    DirectoryInfo parentDir = Directory.GetParent(currentDirectory);
                    if (parentDir != null)
                    {
                        currentDirectory = parentDir.FullName;
                    }
                }
                else
                {
                    string newPath = Path.Combine(currentDirectory, target);
                    if (Directory.Exists(newPath))
                    {
                        currentDirectory = newPath;
                    }
                    else
                    {
                        Console.WriteLine("Folder not found.");
                        Console.ReadKey();
                    }
                }
            }

            else if (command == "open" && parts.Length > 1)
            {
                string fileName = originalParts[1];
                string fullPath = Path.Combine(currentDirectory, fileName);

                if (File.Exists(fullPath))
                {
                    try
                    {
                        Process.Start(new ProcessStartInfo(fullPath) { UseShellExecute = true });
                        Console.WriteLine($"File {fileName} open. Press any button to return to the manager.");
                        Console.ReadKey();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed to open file: {ex.Message}");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("File not found.");
                    Console.ReadKey();
                }
            }

            else
            {
                Console.WriteLine("Unknown command or invalid format.");
                Console.ReadKey();
            }
        }

        class RainDrop
        {
            public int X { get; set; }
            public int Y { get; set; }
            public bool HasReachedTarget { get; set; } = false;
        }

        static void RainAnimation(int delayMilliseconds)
        {
            Random rand = new Random();
            List<RainDrop> drops = new List<RainDrop>();

            int max_x = Console.WindowWidth;
            int max_y = Console.WindowHeight;

            string targetText = "ConsoleCat";
            int startX = (max_x - targetText.Length) / 2;
            int startY = max_y / 2;

            while (!Console.KeyAvailable)
            {
                if (rand.Next(0, 100) > 10)
                {
                    drops.Add(new RainDrop { X = rand.Next(0, max_x), Y = 0 });
                }

                foreach (var drop in drops)
                {
                    if (!drop.HasReachedTarget)
                    {
                        if (drop.Y >= 0 && drop.Y < max_y && drop.X >= 0 && drop.X < max_x)
                        {
                            Console.SetCursorPosition(drop.X, drop.Y);
                            Console.Write(" ");
                        }
                    }
                    if (!drop.HasReachedTarget && drop.Y > 0)
                    {
                        if (drop.Y - 1 >= 0 && drop.Y - 1 < max_y && drop.X >= 0 && drop.X < max_x)
                        {
                            Console.SetCursorPosition(drop.X, drop.Y - 1);
                            Console.Write(" ");
                        }
                    }
                }

                for (int i = 0; i < drops.Count; i++)
                {
                    RainDrop drop = drops[i];

                    bool isOnTargetRow = drop.Y == startY;
                    bool isOnTargetCol = drop.X >= startX && drop.X < startX + targetText.Length;

                    if (isOnTargetRow && isOnTargetCol)
                    {
                        drop.HasReachedTarget = true;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(drop.X, drop.Y);
                        Console.Write(targetText[drop.X - startX]);
                    }
                    else
                    {
                        if (!drop.HasReachedTarget)
                        {
                            drop.Y++;

                            if (drop.Y >= 0 && drop.Y < max_y && drop.X >= 0 && drop.X < max_x)
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.SetCursorPosition(drop.X, drop.Y);
                                Console.Write("|");
                            }
                        }
                    }
                }

                drops.RemoveAll(drop => !drop.HasReachedTarget && drop.Y >= max_y);

                Thread.Sleep(delayMilliseconds);
            }
        }

        static void PlayIntroCutscene()
        {
            Console.Clear();
            Console.CursorVisible = false;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            string title = "Chapter №1";
            string subtitle = "Start";

            int centerRow = Console.WindowHeight / 2;
            int titleStartColumn = (Console.WindowWidth - title.Length) / 2;
            int subtitleStartColumn = (Console.WindowWidth - subtitle.Length) / 2;

            Console.SetCursorPosition(titleStartColumn, centerRow - 1);
            TypewriterEffect(title, 70);
            Thread.Sleep(1000);

            Console.SetCursorPosition(subtitleStartColumn, centerRow + 1);
            TypewriterEffect(subtitle, 40);
            Thread.Sleep(2500);
        }

        static void TypewriterEffect(string message, int delay = 50)
        {
            foreach (char character in message)
            {
                Console.Write(character);
                Thread.Sleep(delay);
            }
        }

        internal class Program
        {
            static void Main(string[] args)
            {

                Console.Title = "ConsoleCat";
                string MAINText = "Only English language";

                int MAINlength = MAINText.Length;
                int MAINcursor = 0;
                while (MAINlength > Console.WindowWidth)
                {
                    string MAINnewLine = MAINText.Substring(MAINcursor, Console.WindowWidth - 4);
                    int MAINlineLength = MAINnewLine.LastIndexOf(' ');
                    MAINcursor += MAINlineLength;
                    MAINText = MAINText.Insert(MAINcursor, "\n");
                    MAINlength -= MAINlineLength;
                }
                string[] MAINlines = Regex.Split(MAINText, "\r\n|\r|\n");
                int MAINleft = 0;
                int MAINtop = (Console.WindowHeight / 2) - (MAINlines.Length / 2) - 1;
                int MAINcenter = Console.WindowWidth / 2;
                for (int i = 0; i < MAINlines.Length; i++)
                {
                    MAINleft = MAINcenter - (MAINlines[i].Length / 2);
                    Console.SetCursorPosition(MAINleft, MAINtop);
                    Console.WriteLine(MAINlines[i]);
                    MAINtop = Console.CursorTop;
                }

                while (true)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        Console.WriteLine("___________________________");
                        Console.WriteLine("|                         |");
                        Console.WriteLine("|Select language:         |");
                        Console.WriteLine("|Русский - R              |");
                        Console.WriteLine("|English - E              |");
                        Console.WriteLine("|_________________________|");

                        ConsoleKeyInfo keyInfoR = Console.ReadKey(true);
                        if (keyInfoR.Key == ConsoleKey.R)
                        {
                            Console.Clear();
                            string textRL = "Выбран русский язык. Нажмите Escape для продолжения.";

                            int lengthRL = textRL.Length;
                            int cursorRL = 0;
                            while (lengthRL > Console.WindowWidth)
                            {
                                string newLineRL = textRL.Substring(cursorRL, Console.WindowWidth - 4);
                                int lineLengthRL = newLineRL.LastIndexOf(' ');
                                cursorRL += lineLengthRL;
                                textRL = textRL.Insert(cursorRL, "\n");
                                lengthRL -= lineLengthRL;
                            }
                            string[] linesRL = Regex.Split(textRL, "\r\n|\r|\n");
                            int leftRL = 0;
                            int topRL = (Console.WindowHeight / 2) - (linesRL.Length / 2) - 1;
                            int centerRL = Console.WindowWidth / 2;
                            for (int i = 0; i < linesRL.Length; i++)
                            {
                                leftRL = centerRL - (linesRL[i].Length / 2);
                                Console.SetCursorPosition(leftRL, topRL);
                                Console.WriteLine(linesRL[i]);
                                topRL = Console.CursorTop;
                            }
                            ConsoleKeyInfo keyInfo1 = Console.ReadKey(false);
                            if (keyInfo1.Key == ConsoleKey.Escape)
                            {
                                Console.Clear();
                                Console.WriteLine("        <<ГЛАВНОЕ МЕНЮ>>");
                                Console.WriteLine("___________________________________");
                                Console.WriteLine("|Нажмите N чтобы начать новую игру|");
                                Console.WriteLine("|Нажмите L чтобы загрузить игру   |");
                                Console.WriteLine("|Нажмите esc чтобы закрыть игру   |");
                                Console.WriteLine("|_________________________________|");

                                ConsoleKeyInfo keyInfo4 = Console.ReadKey(true);
                                if (keyInfo4.Key == ConsoleKey.L)
                                {
                                    Console.Clear();
                                    while (true)
                                    {
                                        Console.Clear();
                                        DisplayCurrentDirectory();
                                        DisplayMenu();
                                        ProcessUserInput();

                                        ConsoleKeyInfo keyInfoEscape1 = Console.ReadKey(false);
                                        if (keyInfoEscape1.Key == ConsoleKey.Escape)
                                        {
                                            Console.Clear();
                                            break;
                                        }
                                    }
                                    break;
                                }

                                ConsoleKeyInfo keyInfo5 = Console.ReadKey(false);
                                if (keyInfo5.Key == ConsoleKey.N)
                                {
                                    Console.Clear();
                                    break;
                                }

                                ConsoleKeyInfo keyInfo6 = Console.ReadKey(true);
                                if (keyInfo6.Key == ConsoleKey.Escape)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Вы успешно вышли из игры. Нажмите любую кнопку для закрытия консоли.");
                                    Environment.Exit(0);
                                }
                            }
                        }

                        ConsoleKeyInfo keyInfoE = Console.ReadKey(false);
                        if (keyInfoE.Key == ConsoleKey.E)
                        {
                            Console.Clear();
                            string textEL = "English language selected. Press Escape to continue.";

                            int lengthEL = textEL.Length;
                            int cursorEL = 0;
                            while (lengthEL > Console.WindowWidth)
                            {
                                string newLineEL = textEL.Substring(cursorEL, Console.WindowWidth - 4);
                                int lineLengthEL = newLineEL.LastIndexOf(' ');
                                cursorEL += lineLengthEL;
                                textEL = textEL.Insert(cursorEL, "\n");
                                lengthEL -= lineLengthEL;
                            }
                            string[] linesEL = Regex.Split(textEL, "\r\n|\r|\n");
                            int leftEL = 0;
                            int topEL = (Console.WindowHeight / 2) - (linesEL.Length / 2) - 1;
                            int centerEL = Console.WindowWidth / 2;
                            for (int i = 0; i < linesEL.Length; i++)
                            {
                                leftEL = centerEL - (linesEL[i].Length / 2);
                                Console.SetCursorPosition(leftEL, topEL);
                                Console.WriteLine(linesEL[i]);
                                topEL = Console.CursorTop;
                            }
                            ConsoleKeyInfo keyInfoMain = Console.ReadKey(true);
                            if (keyInfoMain.Key == ConsoleKey.Escape)
                            {
                                Console.Clear();
                                Console.WriteLine("        <<MAIN MENU>>");
                                Console.WriteLine("_____________________________");
                                Console.WriteLine("|Press N to start a new game|");
                                Console.WriteLine("|Press L to load game       |");
                                Console.WriteLine("|Press esc to exit game     |");
                                Console.WriteLine("|___________________________|");

                                ConsoleKeyInfo keyInfo4 = Console.ReadKey(true);
                                if (keyInfo4.Key == ConsoleKey.N)
                                {
                                    Console.Clear();
                                    break;
                                }

                                ConsoleKeyInfo keyInfo5 = Console.ReadKey(true);
                                if (keyInfo5.Key == ConsoleKey.L)
                                {
                                    Console.Clear();
                                    while (true)
                                    {
                                        Console.Clear();
                                        DisplayCurrentDirectoryEnglish();
                                        DisplayMenuEnglish();
                                        ProcessUserInputEnglish();

                                        ConsoleKeyInfo keyInfoEscapeE = Console.ReadKey(false);
                                        if (keyInfoEscapeE.Key == ConsoleKey.Escape)
                                        {
                                            Console.Clear();
                                            break;
                                        }
                                    }
                                    break;
                                }

                                ConsoleKeyInfo keyInfo6 = Console.ReadKey(false);
                                if (keyInfo6.Key == ConsoleKey.Escape)
                                {
                                    Console.Clear();
                                    Console.WriteLine("You have successfully logged out of the game. Press any botton to close console.");
                                    Environment.Exit(0);
                                }
                            }
                        }
                    }
                }



                string PlayerName = "Enter a name for your cat: ";

                foreach (char c in PlayerName)
                {
                    Console.Write(c);
                    Thread.Sleep(50);
                }
                PlayerName = Console.ReadLine(); Console.Clear();

                string PlayerAge = "Enter your cat's age: ";
                foreach (char c in PlayerAge)
                {
                    Console.Write(c);
                    Thread.Sleep(50);
                }
                int PlayerAge32 = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                string CatStat = $" Your cat's name - {PlayerName}, your cat's age - {PlayerAge32}, save changes?";
                foreach (char c in CatStat)
                {
                    Console.Write(c);
                    Thread.Sleep(50);
                }

                string CatStatYorN = "\n Send y - if you want to change something, send n - if you want to continue. \n Choice: ";
                foreach (char c in CatStatYorN)
                {
                    Console.Write(c);
                    Thread.Sleep(50);
                }
                string userInput = Console.ReadLine().ToLower();

                if (userInput == "y")
                {
                    Console.Clear();
                    string UserPutY = "You chose 'y', which means you need to re-select the cat's name and age.";
                    foreach (char c in UserPutY)
                    {
                        Console.Write(c);
                        Thread.Sleep(50);
                    }
                    UserPutY = Console.ReadLine(); Console.Clear();

                    string ReturnName = "Enter a name for your cat: ";
                    foreach (char a in ReturnName)
                    {
                        Console.Write(a);
                        Thread.Sleep(50);
                    }
                    ReturnName = Console.ReadLine(); Console.Clear();

                    string ReturnAge = "Enter your cat's age: ";
                    foreach (char b in ReturnAge)
                    {
                        Console.Write(b);
                        Thread.Sleep(50);
                    }
                    int ReturnPlayerAge32 = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();

                    string CatStatY = $" Your cat's name - {ReturnName}, your cat's age - {ReturnPlayerAge32}.";
                    foreach (char d in CatStatY)
                    {
                        Console.Write(d);
                        Thread.Sleep(50);
                    }

                    string UserPutC = "\n Send c - if you want to continue. \n Choice:";
                    foreach (char c in UserPutC)
                    {
                        Console.Write(c);
                        Thread.Sleep(50);
                    }
                    string additionalInput = Console.ReadLine().ToLower();
                    if (additionalInput == "c")
                    {
                        Console.Clear();
                        string load = ("Let's dive into this fascinating world...");
                        foreach (char c in load)
                        {
                            Console.Write(c);
                            Thread.Sleep(50);
                        }
                    }
                }
                else if (userInput == "n")
                {
                    Console.Clear();
                    string load = ("Let's dive into this fascinating world...");
                    foreach (char c in load)
                    {
                        Console.Write(c);
                        Thread.Sleep(50);
                    }
                }
                Console.ReadKey();
                Console.Clear();


                int playerX = 0;
                int playerY = 28;
                //LEFT WALL
                int WallX = 113;
                int WallY = 24;
                int WallX1 = 113;
                int WallY1 = 23;
                int WallX2 = 113;
                int WallY2 = 22;
                int WallX3 = 113;
                int WallY3 = 21;
                int WallX4 = 113;
                int WallY4 = 20;
                int WallX5 = 113;
                int WallY5 = 19;
                int WallX6 = 113;
                int WallY6 = 18;
                int WallX7 = 113;
                int WallY7 = 17;
                int WallX8 = 113;
                int WallY8 = 16;
                int WallX9 = 113;
                int WallY9 = 15;
                int WallX10 = 113;
                int WallY10 = 14;
                int WallX11 = 113;
                int WallY11 = 13;
                int WallX12 = 113;
                int WallY12 = 12;
                int WallX13 = 113;
                int WallY13 = 11;
                int WallX14 = 113;
                int WallY14 = 10;
                int WallX15 = 113;
                int WallY15 = 9;
                int WallX16 = 76;
                int WallY16 = 7;

                int WallX17 = 76;
                int WallY17 = 8;
                int WallX18 = 76;
                int WallY18 = 9;
                int WallX19 = 76;
                int WallY19 = 10;
                int WallX20 = 76;
                int WallY20 = 11;
                int WallX21 = 76;
                int WallY21 = 12;
                int WallX22 = 76;
                int WallY22 = 13;
                int WallX23 = 76;
                int WallY23 = 14;
                int WallX24 = 76;
                int WallY24 = 15;

                //RIGHT WALL
                int WallXR = 119;
                int WallYR = 24;
                int WallX1R = 119;
                int WallY1R = 23;
                int WallX2R = 119;
                int WallY2R = 22;
                int WallX3R = 119;
                int WallY3R = 21;
                int WallX4R = 119;
                int WallY4R = 20;
                int WallX5R = 119;
                int WallY5R = 19;
                int WallX6R = 119;
                int WallY6R = 18;
                int WallX7R = 119;
                int WallY7R = 17;
                int WallX8R = 119;
                int WallY8R = 16;
                int WallX9R = 119;
                int WallY9R = 15;
                int WallX10R = 119;
                int WallY10R = 14;
                int WallX11R = 119;
                int WallY11R = 13;
                int WallX12R = 119;
                int WallY12R = 12;
                int WallX13R = 119;
                int WallY13R = 11;
                int WallX14R = 119;
                int WallY14R = 10;
                int WallX15R = 119;
                int WallY15R = 9;
                int WallX16R = 119;
                int WallY16R = 8;
                int WallX17R = 119;
                int WallY17R = 7;
                int WallX18R = 119;
                int WallY18R = 6;

                int WallX20R = 82;
                int WallY20R = 9;
                int WallX21R = 82;
                int WallY21R = 10;
                int WallX22R = 82;
                int WallY22R = 11;
                int WallX23R = 82;
                int WallY23R = 12;
                int WallX24R = 82;
                int WallY24R = 13;
                int WallX25R = 82;
                int WallY25R = 14;
                int WallX26R = 82;
                int WallY26R = 15;
                int WallX27R = 82;
                int WallY27R = 16;
                int WallX28R = 82;
                int WallY28R = 17;
                int WallX29R = 82;
                int WallY29R = 18;
                int WallX30R = 82;
                int WallY30R = 19;
                int WallX31R = 82;
                int WallY31R = 20;

                //FLOOR WALL
                int FWallX0 = 81;
                int FWallY0 = 5;
                int FWallX = 83;
                int FWallY = 8;

                //FLOWER
                int DFlowerX0 = 30;
                int DFlowerY0 = 12;
                int UFlowerX0 = 30;
                int UFlowerY0 = 11;

                //FLOWER1
                int UFlowerX = 33;
                int UFlowerY = 11;
                int UFlowerX1 = 33;
                int UFlowerY1 = 10;

                //FLOWER2
                int UFlowerX2 = 35;
                int UFlowerY2 = 13;
                int UFlowerX3 = 35;
                int UFlowerY3 = 12;

                //FLOWER2
                int UFlowerX4 = 37;
                int UFlowerY4 = 11;
                int UFlowerX5 = 37;
                int UFlowerY5 = 10;

                //FLOWER3
                int UFlowerX6 = 39;
                int UFlowerY6 = 14;
                int UFlowerX7 = 39;
                int UFlowerY7 = 13;

                //FLOWER4
                int UFlowerX8 = 27;
                int UFlowerY8 = 13;
                int UFlowerX9 = 27;
                int UFlowerY9 = 12;

                //CLOUD
                int CloudX0 = 21;
                int CloudY0 = 3;
                int CloudX = 21;
                int CloudY = 4;
                int CloudX1 = 21;
                int CloudY1 = 5;

                //CLOUD1
                int CloudX2 = 34;
                int CloudY2 = 1;
                int CloudX3 = 34;
                int CloudY3 = 2;
                int CloudX4 = 34;
                int CloudY4 = 3;

                //CLOUD2
                int CloudX5 = 50;
                int CloudY5 = 4;
                int CloudX6 = 50;
                int CloudY6 = 5;
                int CloudX7 = 50;
                int CloudY7 = 6;

                //SCAMEIKA
                int ScamX0 = 43;
                int ScamY0 = 14;
                int ScamX = 44;
                int ScamY = 14;
                int ScamX1 = 45;
                int ScamY1 = 14;
                int ScamX2 = 45;
                int ScamY2 = 14;

                int DScamX0 = 43;
                int DScamY0 = 15;
                int DScamX = 47;
                int DScamY = 15;

                //BIG_TREE
                int DTreeX0 = 52;
                int DTreeY0 = 16;
                int DTreeX = 52;
                int DTreeY = 15;
                int DTreeX1 = 52;
                int DTreeY1 = 14;
                int DTreeX2 = 53;
                int DTreeY2 = 13;

                int UTreeX0 = 47;
                int UTreeY0 = 13;
                int UTreeX = 48;
                int UTreeY = 12;
                int UTreeX1 = 49;
                int UTreeY1 = 11;
                int UTreeX2 = 50;
                int UTreeY2 = 10;
                int UTreeX3 = 51;
                int UTreeY3 = 9;
                int UTreeX4 = 53;
                int UTreeY4 = 8;

                //MOUNTH
                int MouX0 = 2;
                int MouY0 = 4;
                int MouX = 2;
                int MouY = 5;
                int MouX1 = 2;
                int MouY1 = 6;

                //ZABOR
                int ZabX0 = 81;
                int ZabY0 = 2;
                int ZabX = 81;
                int ZabY = 3;
                int ZabX1 = 81;
                int ZabY1 = 4;

                int ZabX2 = 63;
                int ZabY2 = 13;
                int ZabX3 = 63;
                int ZabY3 = 14;
                int ZabX4 = 63;
                int ZabY4 = 15;



                //treeLeft1
                int TreeX = 99;
                int TreeY = 4;
                int TreeX1 = 99;
                int TreeY1 = 5;
                int TreeX2 = 99;
                int TreeY2 = 6;
                int TreeX3 = 98;
                int TreeY3 = 3;
                int TreeX4 = 97;
                int TreeY4 = 3;
                int TreeX5 = 99;
                int TreeY5 = 2;

                //treeRight1
                int TreeXR = 101;
                int TreeYR = 4;
                int TreeX1R = 101;
                int TreeY1R = 5;
                int TreeX2R = 101;
                int TreeY2R = 6;
                int TreeX3R = 102;
                int TreeY3R = 3;
                int TreeX4R = 103;
                int TreeY4R = 3;
                int TreeX5R = 101;
                int TreeY5R = 2;

                //treeDownUp1
                int TreeXD = 100;
                int TreeYD = 6;

                int TreeXU1 = 98;
                int TreeYU1 = 3;
                int TreeXU2 = 102;
                int TreeYU2 = 3;
                int TreeXU3 = 98;
                int TreeYU3 = 2;
                int TreeXU4 = 102;
                int TreeYU4 = 2;
                int TreeXU5 = 100;
                int TreeYU5 = 1;



                //grobLeft
                int GrobXL = 75;
                int GrobYL = 6;
                int GrobXL1 = 74;
                int GrobYL1 = 5;
                int GrobXL2 = 74;
                int GrobYL2 = 4;

                int GrobXL3 = 77;
                int GrobYL3 = 4;
                int GrobXL4 = 77;
                int GrobYL4 = 3;


                //grobRight
                int GrobXR = 79;
                int GrobYR = 6;
                int GrobXR1 = 80;
                int GrobYR1 = 5;
                int GrobXR2 = 80;
                int GrobYR2 = 4;

                //grobUpDown
                int GrobXU = 75;
                int GrobYU = 3;
                int GrobXU1 = 76;
                int GrobYU1 = 2;
                int GrobXU2 = 77;
                int GrobYU2 = 2;
                int GrobXU3 = 78;
                int GrobYU3 = 2;
                int GrobXU4 = 79;
                int GrobYU4 = 3;

                int GrobXD = 76;
                int GrobYD = 6;
                int GrobXD1 = 77;
                int GrobYD1 = 6;
                int GrobXD2 = 78;
                int GrobYD2 = 6;

                //angelRight
                int AngelRX0 = 2;
                int AngelRY0 = 24;
                int AngelRX = 2;
                int AngelRY = 23;
                int AngelRX1 = 2;
                int AngelRY1 = 22;
                int AngelRX2 = 2;
                int AngelRY2 = 21;

                //angelLeft
                int AngelLX0 = 0;
                int AngelLY0 = 24;
                int AngelLX = 1;
                int AngelLY = 23;
                int AngelLX1 = 0;
                int AngelLY1 = 22;
                int AngelLX2 = 1;
                int AngelLY2 = 21;

                //angelUpDown
                int AngelXD = 1;
                int AngelYD = 25;

                //angelRight1
                int AngelRX3 = 2;
                int AngelRY3 = 19;
                int AngelRX4 = 2;
                int AngelRY4 = 18;
                int AngelRX5 = 2;
                int AngelRY5 = 17;
                int AngelRX6 = 2;
                int AngelRY6 = 16;

                //angelLeft1
                int AngelLX3 = 0;
                int AngelLY3 = 19;
                int AngelLX4 = 1;
                int AngelLY4 = 18;
                int AngelLX5 = 0;
                int AngelLY5 = 17;
                int AngelLX6 = 1;
                int AngelLY6 = 16;

                //angelUpDown1
                int AngelXD1 = 1;
                int AngelYD1 = 20;

                //angelLeft2
                int AngelLX7 = 13;
                int AngelLY7 = 15;
                int AngelLX8 = 14;
                int AngelLY8 = 14;
                int AngelLX9 = 13;
                int AngelLY9 = 13;
                int AngelLX10 = 14;
                int AngelLY10 = 12;

                //angelUpDown2
                int AngelXD2 = 14;
                int AngelYD2 = 16;

                //angelLeft3
                int AngelLX11 = 17;
                int AngelLY11 = 12;
                int AngelLX12 = 18;
                int AngelLY12 = 11;
                int AngelLX13 = 17;
                int AngelLY13 = 10;
                int AngelLX14 = 18;
                int AngelLY14 = 9;

                //angelUpDown3
                int AngelXD3 = 18;
                int AngelYD3 = 13;

                //angelLeft4
                int AngelLX15 = 22;
                int AngelLY15 = 11;
                int AngelLX16 = 23;
                int AngelLY16 = 10;
                int AngelLX17 = 22;
                int AngelLY17 = 9;
                int AngelLX18 = 23;
                int AngelLY18 = 8;

                //angelUpDown4
                int AngelXD4 = 23;
                int AngelYD4 = 12;

                //Cherkov
                int CherX = 6;
                int CherY = 18;
                int CherX1 = 6;
                int CherY1 = 17;
                int CherX2 = 6;
                int CherY2 = 16;
                int CherX3 = 6;
                int CherY3 = 15;
                int CherX4 = 6;
                int CherY4 = 14;
                int CherX5 = 6;
                int CherY5 = 13;
                int CherX6 = 6;
                int CherY6 = 12;
                int CherX7 = 6;
                int CherY7 = 11;
                int CherX8 = 6;
                int CherY8 = 10;
                int CherX9 = 6;
                int CherY9 = 9;
                int CherX10 = 6;
                int CherY10 = 8;
                int CherX11 = 6;
                int CherY11 = 7;
                int CherX12 = 6;
                int CherY12 = 6;
                Console.CursorVisible = false;
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Controls: w/ц move up, s/ы move down, a/ф move left, d/в move right, q/й exit. Go to the church");
                    //LEFT WALL
                    Console.SetCursorPosition(WallX, WallY);
                    Console.Write("|");
                    Console.SetCursorPosition(WallX1, WallY1);
                    Console.Write("|");
                    Console.SetCursorPosition(WallX2, WallY2);
                    Console.Write("|");
                    Console.SetCursorPosition(WallX3, WallY3);
                    Console.Write("|");
                    Console.SetCursorPosition(WallX4, WallY4);
                    Console.Write("|");
                    Console.SetCursorPosition(WallX5, WallY5);
                    Console.Write("|");
                    Console.SetCursorPosition(WallX6, WallY6);
                    Console.Write("|");
                    Console.SetCursorPosition(WallX7, WallY7);
                    Console.Write("|");
                    Console.SetCursorPosition(WallX8, WallY8);
                    Console.Write("|");
                    Console.SetCursorPosition(WallX9, WallY9);
                    Console.Write("|");
                    Console.SetCursorPosition(WallX10, WallY10);
                    Console.Write("|");
                    Console.SetCursorPosition(WallX11, WallY11);
                    Console.Write("|");
                    Console.SetCursorPosition(WallX12, WallY12);
                    Console.Write("|");
                    Console.SetCursorPosition(WallX13, WallY13);
                    Console.Write("|");
                    Console.SetCursorPosition(WallX14, WallY14);
                    Console.Write("|");
                    Console.SetCursorPosition(WallX15, WallY15);
                    Console.Write("|");
                    Console.SetCursorPosition(WallX16, WallY16);
                    Console.Write("|");

                    Console.SetCursorPosition(WallX17, WallY17);
                    Console.Write("|");
                    Console.SetCursorPosition(WallX18, WallY18);
                    Console.Write("|");
                    Console.SetCursorPosition(WallX19, WallY19);
                    Console.Write("|");
                    Console.SetCursorPosition(WallX20, WallY20);
                    Console.Write("|");
                    Console.SetCursorPosition(WallX21, WallY21);
                    Console.Write("|");
                    Console.SetCursorPosition(WallX22, WallY22);
                    Console.Write("|");
                    Console.SetCursorPosition(WallX23, WallY23);
                    Console.Write("|");
                    Console.SetCursorPosition(WallX24, WallY24);
                    Console.Write("|");

                    //RIGHT WALL
                    Console.SetCursorPosition(WallXR, WallYR);
                    Console.Write("|");
                    Console.SetCursorPosition(WallX1R, WallY1R);
                    Console.Write("|");
                    Console.SetCursorPosition(WallX2R, WallY2R);
                    Console.Write("|");
                    Console.SetCursorPosition(WallX3R, WallY3R);
                    Console.Write("|");
                    Console.SetCursorPosition(WallX4R, WallY4R);
                    Console.Write("|");
                    Console.SetCursorPosition(WallX5R, WallY5R);
                    Console.Write("|");
                    Console.SetCursorPosition(WallX6R, WallY6R);
                    Console.Write("|");
                    Console.SetCursorPosition(WallX7R, WallY7R);
                    Console.Write("|");
                    Console.SetCursorPosition(WallX8R, WallY8R);
                    Console.Write("|");
                    Console.SetCursorPosition(WallX9R, WallY9R);
                    Console.Write("|");
                    Console.SetCursorPosition(WallX10R, WallY10R);
                    Console.Write("|");
                    Console.SetCursorPosition(WallX11R, WallY11R);
                    Console.Write("|");
                    Console.SetCursorPosition(WallX12R, WallY12R);
                    Console.Write("|");
                    Console.SetCursorPosition(WallX13R, WallY13R);
                    Console.Write("|");
                    Console.SetCursorPosition(WallX14R, WallY14R);
                    Console.Write("|");
                    Console.SetCursorPosition(WallX15R, WallY15R);
                    Console.Write("|");
                    Console.SetCursorPosition(WallX16R, WallY16R);
                    Console.Write("|");
                    Console.SetCursorPosition(WallX17R, WallY17R);
                    Console.Write("|");
                    Console.SetCursorPosition(WallX18R, WallY18R);
                    Console.Write("|");

                    Console.SetCursorPosition(WallX20R, WallY20R);
                    Console.Write("|");
                    Console.SetCursorPosition(WallX21R, WallY21R);
                    Console.Write("|");
                    Console.SetCursorPosition(WallX22R, WallY22R);
                    Console.Write("|");
                    Console.SetCursorPosition(WallX23R, WallY23R);
                    Console.Write("|");
                    Console.SetCursorPosition(WallX24R, WallY24R);
                    Console.Write("|");
                    Console.SetCursorPosition(WallX25R, WallY25R);
                    Console.Write("|");
                    Console.SetCursorPosition(WallX26R, WallY26R);
                    Console.Write("|");
                    Console.SetCursorPosition(WallX27R, WallY27R);
                    Console.Write("|");
                    Console.SetCursorPosition(WallX28R, WallY28R);
                    Console.Write("|");
                    Console.SetCursorPosition(WallX29R, WallY29R);
                    Console.Write("|");
                    Console.SetCursorPosition(WallX30R, WallY30R);
                    Console.Write("|");
                    Console.SetCursorPosition(WallX31R, WallY31R);
                    Console.Write("|");

                    //FLOOR WALL
                    Console.SetCursorPosition(FWallX0, FWallY0);
                    Console.Write("_______________________________________");
                    Console.SetCursorPosition(FWallX, FWallY);
                    Console.Write("______________________________");

                    //FLOWER
                    Console.SetCursorPosition(DFlowerX0, DFlowerY0);
                    Console.Write("|");
                    Console.SetCursorPosition(UFlowerX0, UFlowerY0);
                    Console.Write("@");

                    //FLOWER1
                    Console.SetCursorPosition(UFlowerX, UFlowerY);
                    Console.Write("|");
                    Console.SetCursorPosition(UFlowerX1, UFlowerY1);
                    Console.Write("@");

                    //FLOWER2
                    Console.SetCursorPosition(UFlowerX2, UFlowerY2);
                    Console.Write("|");
                    Console.SetCursorPosition(UFlowerX3, UFlowerY3);
                    Console.Write("@");

                    //FLOWER3
                    Console.SetCursorPosition(UFlowerX4, UFlowerY4);
                    Console.Write("|");
                    Console.SetCursorPosition(UFlowerX5, UFlowerY5);
                    Console.Write("@");

                    //FLOWER4
                    Console.SetCursorPosition(UFlowerX6, UFlowerY6);
                    Console.Write("|");
                    Console.SetCursorPosition(UFlowerX7, UFlowerY7);
                    Console.Write("#");

                    //FLOWER5
                    Console.SetCursorPosition(UFlowerX8, UFlowerY8);
                    Console.Write("|");
                    Console.SetCursorPosition(UFlowerX9, UFlowerY9);
                    Console.Write("@");

                    //CLOUD
                    Console.SetCursorPosition(CloudX0, CloudY0);
                    Console.Write("   _");
                    Console.SetCursorPosition(CloudX, CloudY);
                    Console.Write(" (   )");
                    Console.SetCursorPosition(CloudX1, CloudY1);
                    Console.Write("(_____)");

                    //CLOUD1
                    Console.SetCursorPosition(CloudX2, CloudY2);
                    Console.Write("   _");
                    Console.SetCursorPosition(CloudX3, CloudY3);
                    Console.Write(" (   )");
                    Console.SetCursorPosition(CloudX4, CloudY4);
                    Console.Write("(_____)");

                    //CLOUD2
                    Console.SetCursorPosition(CloudX5, CloudY5);
                    Console.Write("   _");
                    Console.SetCursorPosition(CloudX6, CloudY6);
                    Console.Write(" (   )");
                    Console.SetCursorPosition(CloudX7, CloudY7);
                    Console.Write("(_____)");

                    //SCAMEIKA
                    Console.SetCursorPosition(ScamX0, ScamY0);
                    Console.Write("*__");
                    Console.SetCursorPosition(ScamX, ScamY);
                    Console.Write("__");
                    Console.SetCursorPosition(ScamX1, ScamY1);
                    Console.Write("__");
                    Console.SetCursorPosition(ScamX2, ScamY2);
                    Console.Write("__*");

                    Console.SetCursorPosition(DScamX0, DScamY0);
                    Console.Write("|");
                    Console.SetCursorPosition(DScamX, DScamY);
                    Console.Write("|");

                    //BIG_TREE
                    Console.SetCursorPosition(DTreeX0, DTreeY0);
                    Console.Write("|__|");
                    Console.SetCursorPosition(DTreeX, DTreeY);
                    Console.Write("|* |");
                    Console.SetCursorPosition(DTreeX1, DTreeY1);
                    Console.Write("| /|");
                    Console.SetCursorPosition(DTreeX2, DTreeY2);
                    Console.Write("||");

                    Console.SetCursorPosition(UTreeX0, UTreeY0);
                    Console.Write("###############");
                    Console.SetCursorPosition(UTreeX, UTreeY);
                    Console.Write("#############");
                    Console.SetCursorPosition(UTreeX1, UTreeY1);
                    Console.Write("###########");
                    Console.SetCursorPosition(UTreeX2, UTreeY2);
                    Console.Write("#########");
                    Console.SetCursorPosition(UTreeX3, UTreeY3);
                    Console.Write("#######");
                    Console.SetCursorPosition(UTreeX4, UTreeY4);
                    Console.Write("###");

                    //MOU
                    Console.SetCursorPosition(MouX0, MouY0);
                    Console.Write(" ,-.");
                    Console.SetCursorPosition(MouX, MouY);
                    Console.Write("( (`)");
                    Console.SetCursorPosition(MouX1, MouY1);
                    Console.Write(" `~'");

                    //ZABOR
                    Console.SetCursorPosition(ZabX0, ZabY0);
                    Console.Write("  /X\\/X\\/X\\/X\\/X\\/X\\/X\\/X\\/X\\/X\\/X\\/X\\");
                    Console.SetCursorPosition(ZabX, ZabY);
                    Console.Write("  | | | | | | | | | | | | | | | | | | |");
                    Console.SetCursorPosition(ZabX1, ZabY1);
                    Console.Write("  \\X/\\X/\\X/\\X/\\X/\\X/\\X/\\X/\\X/\\X/\\X/\\X/");

                    Console.SetCursorPosition(ZabX2, ZabY2);
                    Console.Write("  /X\\/X\\/X\\/X");
                    Console.SetCursorPosition(ZabX3, ZabY3);
                    Console.Write("  | | | | | |");
                    Console.SetCursorPosition(ZabX4, ZabY4);
                    Console.Write("  \\X/\\X/\\X/\\X");

                    //grobLeft
                    Console.SetCursorPosition(GrobXL, GrobYL);
                    Console.Write("\\");
                    Console.SetCursorPosition(GrobXL1, GrobYL1);
                    Console.Write("\\");
                    Console.SetCursorPosition(GrobXL2, GrobYL2);
                    Console.Write("/");

                    Console.SetCursorPosition(GrobXL3, GrobYL3);
                    Console.Write("|");
                    Console.SetCursorPosition(GrobXL4, GrobYL4);
                    Console.Write("+");

                    //grobRight
                    Console.SetCursorPosition(GrobXR, GrobYR);
                    Console.Write("/");
                    Console.SetCursorPosition(GrobXR1, GrobYR1);
                    Console.Write("/");
                    Console.SetCursorPosition(GrobXR2, GrobYR2);
                    Console.Write("\\");

                    //grobUpDown
                    Console.SetCursorPosition(GrobXU, GrobYU);
                    Console.Write("/");
                    Console.SetCursorPosition(GrobXU1, GrobYU1);
                    Console.Write("_");
                    Console.SetCursorPosition(GrobXU2, GrobYU2);
                    Console.Write("_");
                    Console.SetCursorPosition(GrobXU3, GrobYU3);
                    Console.Write("_");
                    Console.SetCursorPosition(GrobXU4, GrobYU4);
                    Console.Write("\\");

                    Console.SetCursorPosition(GrobXD, GrobYD);
                    Console.Write("_");
                    Console.SetCursorPosition(GrobXD1, GrobYD1);
                    Console.Write("_");
                    Console.SetCursorPosition(GrobXD2, GrobYD2);
                    Console.Write("_");


                    //AngelLeft
                    Console.SetCursorPosition(AngelLX0, AngelLY0);
                    Console.Write("/_");
                    Console.SetCursorPosition(AngelLX, AngelLY);
                    Console.Write("/");
                    Console.SetCursorPosition(AngelLX1, AngelLY1);
                    Console.Write("/_");
                    Console.SetCursorPosition(AngelLX2, AngelLY2);
                    Console.Write("/");

                    //AngelRight
                    Console.SetCursorPosition(AngelRX0, AngelRY0);
                    Console.Write("_\\ /__\\ /__\\ /__\\ /__\\ /__\\ /__\\ /__\\ /__\\ /__\\ /__\\ /__\\ /__\\ /__\\ /__\\ /__\\ /__\\ /__\\ /__\\ /__\\ /__\\ /__\\ /__\\");
                    Console.SetCursorPosition(AngelRX, AngelRY);
                    Console.Write("\\   /\\   /\\   /\\   /\\   /\\   /\\   /\\   /\\   /\\   /\\   /\\   /\\   /\\   /\\   /\\   /\\   /\\   /\\   /\\   /\\   /\\   /\\");
                    Console.SetCursorPosition(AngelRX1, AngelRY1);
                    Console.Write("_\\ /__\\ /__\\ /__\\ /__\\ /__\\ /__\\ /__\\ /__\\ /__\\ /__\\ /__\\ /__\\ /__\\ /__\\ /__\\ /__\\ /__\\ /__\\ /__\\ /__\\ /__\\ /__\\");
                    Console.SetCursorPosition(AngelRX2, AngelRY2);
                    Console.Write("\\   /\\   /\\   /\\   /\\   /\\   /\\   /\\   /\\   /\\   /\\   /\\   /\\   /\\   /\\   /\\   /\\   /\\   /\\   /\\   /\\   /\\   /\\");

                    //AngelUpDown
                    Console.SetCursorPosition(AngelXD, AngelYD);
                    Console.Write("||   ||   ||   ||   ||   ||   ||   ||   ||   ||   ||   ||   ||   ||   ||   ||   ||   ||   ||   ||   ||   ||   ||");

                    //AngelLeft1
                    Console.SetCursorPosition(AngelLX3, AngelLY3);
                    Console.Write("/_");
                    Console.SetCursorPosition(AngelLX4, AngelLY4);
                    Console.Write("/");
                    Console.SetCursorPosition(AngelLX5, AngelLY5);
                    Console.Write("/_");
                    Console.SetCursorPosition(AngelLX6, AngelLY6);
                    Console.Write("/");

                    //AngelRight1
                    Console.SetCursorPosition(AngelRX3, AngelRY3);
                    Console.Write("_\\");
                    Console.SetCursorPosition(AngelRX4, AngelRY4);
                    Console.Write("\\");
                    Console.SetCursorPosition(AngelRX5, AngelRY5);
                    Console.Write("_\\");
                    Console.SetCursorPosition(AngelRX6, AngelRY6);
                    Console.Write("\\");
                    //AngelUpDown1
                    Console.SetCursorPosition(AngelXD1, AngelYD1);
                    Console.Write("||");

                    //AngelRight2
                    Console.SetCursorPosition(AngelLX7, AngelLY7);
                    Console.Write("/__\\");
                    Console.SetCursorPosition(AngelLX8, AngelLY8);
                    Console.Write("/\\");
                    Console.SetCursorPosition(AngelLX9, AngelLY9);
                    Console.Write("/__\\");
                    Console.SetCursorPosition(AngelLX10, AngelLY10);
                    Console.Write("/\\");
                    //AngelUpDown2
                    Console.SetCursorPosition(AngelXD2, AngelYD2);
                    Console.Write("||");

                    //AngelRight3
                    Console.SetCursorPosition(AngelLX11, AngelLY11);
                    Console.Write("/__\\");
                    Console.SetCursorPosition(AngelLX12, AngelLY12);
                    Console.Write("/\\");
                    Console.SetCursorPosition(AngelLX13, AngelLY13);
                    Console.Write("/__\\");
                    Console.SetCursorPosition(AngelLX14, AngelLY14);
                    Console.Write("/\\");
                    //AngelUpDown3
                    Console.SetCursorPosition(AngelXD3, AngelYD3);
                    Console.Write("||");

                    //AngelRight4
                    Console.SetCursorPosition(AngelLX15, AngelLY15);
                    Console.Write("/__\\");
                    Console.SetCursorPosition(AngelLX16, AngelLY16);
                    Console.Write("/\\");
                    Console.SetCursorPosition(AngelLX17, AngelLY17);
                    Console.Write("/__\\");
                    Console.SetCursorPosition(AngelLX18, AngelLY18);
                    Console.Write("/\\");
                    //AngelUpDown4
                    Console.SetCursorPosition(AngelXD4, AngelYD4);
                    Console.Write("||");

                    //Cerkov
                    Console.SetCursorPosition(CherX, CherY);
                    Console.Write("|_||_|");
                    Console.SetCursorPosition(CherX1, CherY1);
                    Console.Write("| || |");
                    Console.SetCursorPosition(CherX2, CherY2);
                    Console.Write("| || |");
                    Console.SetCursorPosition(CherX3, CherY3);
                    Console.Write("| __ |");
                    Console.SetCursorPosition(CherX4, CherY4);
                    Console.Write("/ __ \\");
                    Console.SetCursorPosition(CherX5, CherY5);
                    Console.Write("| [] |");
                    Console.SetCursorPosition(CherX6, CherY6);
                    Console.Write("|    |");
                    Console.SetCursorPosition(CherX7, CherY7);
                    Console.Write("/____\\");
                    Console.SetCursorPosition(CherX8, CherY8);
                    Console.Write(" /  \\");
                    Console.SetCursorPosition(CherX9, CherY9);
                    Console.Write("  |_");
                    Console.SetCursorPosition(CherX10, CherY10);
                    Console.Write("  +");
                    Console.SetCursorPosition(CherX11, CherY11);
                    Console.Write(" +++");
                    Console.SetCursorPosition(CherX12, CherY12);
                    Console.Write("  +");


                    Console.SetCursorPosition(playerX, playerY);
                    Console.Write("^o_o^");
                    ConsoleKeyInfo keyWhy = Console.ReadKey(true);
                    char key = keyWhy.KeyChar;
                    switch (key)
                    {
                        case 'w':
                        case 'ц':
                            playerY--;
                            break;
                        case 's':
                        case 'ы':
                            playerY++;
                            break;
                        case 'a':
                        case 'ф':
                            playerX--;
                            break;
                        case 'd':
                        case 'в':
                            playerX++;
                            break;
                        case 'q':
                        case 'й':
                            Console.CursorVisible = true;
                            break;
                    }
                    int triggerX1 = 9;
                    int triggerY1 = 18;
                    if (triggerX1 == playerX && triggerY1 == playerY)
                    {
                        Console.Clear();
                        break;
                    }

                    int TEXTtriggerX = 53;
                    int TEXTtriggerY = 16;

                    int TEXTX = 83;
                    int TEXTY = 9;
                    int TEXTX1 = 83;
                    int TEXTY1 = 10;
                    string text0 = "This is a regular bench nearby";
                    string text2 = "there is a big tree next to her";
                    int enterX = 83;
                    int enterY = 20;
                    string enter = "Press enter to control.";

                    if (TEXTtriggerX == playerX && TEXTtriggerY == playerY)
                    {
                        Console.SetCursorPosition(TEXTX, TEXTY);
                        Console.Write(text0);
                        Console.SetCursorPosition(TEXTX1, TEXTY1);
                        Console.Write(text2);
                        Console.SetCursorPosition(enterX, enterY);
                        Console.Write(enter);
                        Console.ReadLine().ToLower();
                        Console.Clear();
                    }
                    int TEXTtriggerX1 = 31;
                    int TEXTtriggerY1 = 14;

                    int TEXTX2 = 83;
                    int TEXTY2 = 9;
                    int TEXTX3 = 83;
                    int TEXTY3 = 10;
                    string text3 = "There are many flowers here, but";
                    string text4 = "only one is different from all";
                    if (TEXTtriggerX1 == playerX && TEXTtriggerY1 == playerY)
                    {
                        Console.SetCursorPosition(TEXTX2, TEXTY2);
                        Console.Write(text3);
                        Console.SetCursorPosition(TEXTX3, TEXTY3);
                        Console.Write(text4);
                        Console.SetCursorPosition(enterX, enterY);
                        Console.Write(enter);
                        Console.ReadLine().ToLower();
                        Console.Clear();
                    }

                    int TEXTtriggerX2 = 114;
                    int TEXTtriggerY2 = 25;

                    int TEXTX4 = 83;
                    int TEXTY4 = 9;
                    int TEXTX5 = 83;
                    int TEXTY5 = 10;
                    int TEXTX6_2 = 83;
                    int TEXTY6_2 = 11;
                    int TEXTX6 = 83;
                    int TEXTY6 = 12;
                    int TEXTX7_2 = 83;
                    int TEXTY7_2 = 13;
                    int TEXTX7 = 83;
                    int TEXTY7 = 14;
                    int TEXTX8 = 83;
                    int TEXTY8 = 15;
                    int TEXTX9 = 83;
                    int TEXTY9 = 16;
                    int TEXTX10 = 83;
                    int TEXTY10 = 17;
                    int TEXTX11 = 83;
                    int TEXTY11 = 18;
                    int TEXTX12 = 83;
                    int TEXTY12 = 19;
                    string text5 = "Moon shines, sun is gone,";
                    string text6 = "Mist swallows your light.";
                    string text6_2 = "Dark, cold, and alone,";
                    string text7 = "Who seek you this night?";
                    string text7_2 = "Peace in the deep gloom,";
                    string text8 = "Wrapped in gray ash.";
                    string text9 = "No fire, no words,";
                    string text10 = "Just cold in the hush.";
                    if (TEXTtriggerX2 == playerX && TEXTtriggerY2 == playerY)
                    {
                        Console.SetCursorPosition(TEXTX4, TEXTY4);
                        Console.Write(text5);
                        Console.SetCursorPosition(TEXTX5, TEXTY5);
                        Console.Write(text6);
                        Console.SetCursorPosition(TEXTX6_2, TEXTY6_2);
                        Console.Write(text6_2);
                        Console.SetCursorPosition(TEXTX6, TEXTY6);
                        Console.Write(text7);
                        Console.SetCursorPosition(TEXTX7_2, TEXTY7_2);
                        Console.Write(text7_2);
                        Console.SetCursorPosition(TEXTX7, TEXTY7);
                        Console.Write(text8);
                        Console.SetCursorPosition(TEXTX8, TEXTY8);
                        Console.Write(text9);
                        Console.SetCursorPosition(TEXTX9, TEXTY9);
                        Console.Write(text10);
                        Console.SetCursorPosition(TEXTX12, TEXTY12);
                        Console.SetCursorPosition(enterX, enterY);
                        Console.Write(enter);
                        Console.ReadLine().ToLower();
                        Console.Clear();
                    }

                    int TEXTtriggerX3 = 78;
                    int TEXTtriggerY3 = 7;

                    int TEXTX14 = 83;
                    int TEXTY14 = 9;
                    int TEXTX15 = 83;
                    int TEXTY15 = 10;
                    string text14 = "A strange grave, all in earth";
                    string text15 = "Maybe someone dug it up?";
                    if (TEXTtriggerX3 == playerX && TEXTtriggerY3 == playerY)
                    {
                        Console.SetCursorPosition(TEXTX14, TEXTY14);
                        Console.Write(text14);
                        Console.SetCursorPosition(TEXTX15, TEXTY15);
                        Console.Write(text15);
                        Console.SetCursorPosition(enterX, enterY);
                        Console.Write(enter);
                        Console.ReadLine().ToLower();
                        Console.Clear();
                    }
                }

                string text = $"The cat eagerly enters an old, abandoned house, surrounded by emptiness and darkness. Suddenly, there's a knock, and he sees an old man. You immediately assume he's some scumbag with nowhere to live, but soon the mystery is revealed, and you learn his identity. Press Enter to continue.";
                int length = text.Length;
                int cursor = 0;
                while (length > Console.WindowWidth)
                {
                    string newLine = text.Substring(cursor, Console.WindowWidth - 4);
                    int lineLength = newLine.LastIndexOf(' ');
                    cursor += lineLength;
                    text = text.Insert(cursor, "\n");
                    length -= lineLength;
                }
                string[] lines = Regex.Split(text, "\r\n|\r|\n");
                int left = 0;
                int top = (Console.WindowHeight / 2) - (lines.Length / 2) - 1;
                int center = Console.WindowWidth / 2;

                for (int i = 0; i < lines.Length; i++)
                {
                    left = center - (lines[i].Length / 2);
                    Console.SetCursorPosition(left, top);
                    Console.WriteLine(lines[i]);
                    top = Console.CursorTop;
                }
                Console.ReadLine().ToLower();
                Console.Clear();


                int triggerX = 29;
                int triggerY = 16;

                //FIRE
                int FireX = 3;
                int FireY = 27;
                int FireX0 = 3;
                int FireY0 = 26;
                int FireX1 = 3;
                int FireY1 = 25;
                int FireX2 = 3;
                int FireY2 = 24;

                int FireX3 = 3;
                int FireY3 = 24;
                int FireX4 = 3;
                int FireY4 = 24;
                int FireX5 = 3;
                int FireY5 = 24;
                int FireX6 = 3;
                int FireY6 = 24;
                int FireX7 = 3;
                int FireY7 = 23;
                int FireX8 = 3;
                int FireY8 = 22;
                int FireX9 = 3;
                int FireY9 = 21;
                int FireX10 = 3;
                int FireY10 = 20;
                int FireX11 = 3;
                int FireY11 = 19;
                int FireX12 = 3;
                int FireY12 = 18;
                int FireX13 = 3;
                int FireY13 = 17;
                int FireX14 = 3;
                int FireY14 = 16;
                int FireX15 = 3;
                int FireY15 = 15;
                int FireX16 = 3;
                int FireY16 = 14;
                int FireX17 = 3;
                int FireY17 = 13;
                int FireX18 = 3;
                int FireY18 = 12;
                int FireX19 = 3;
                int FireY19 = 11;
                int FireX20 = 3;
                int FireY20 = 10;
                int FireX21 = 3;
                int FireY21 = 9;

                //Trig CAt
                int PtriggerX = 45;
                int PtriggerY = 19;

                //TrigChel
                int HtriggerX = 29;
                int HtriggerY = 15;


                //X i Y cota
                int playerXC = 56;
                int playerYC = 28;


                Console.CursorVisible = false;
                while (true)
                {
                    //INCHER
                    Console.SetCursorPosition(FireX, FireY);
                    Console.Write(" |                        || .                  . ||                        ||   . ||                        ||");
                    Console.SetCursorPosition(FireX0, FireY0);
                    Console.Write(" |_________________________|/|.                 . | ________________________ |   . | ________________________ |");
                    Console.SetCursorPosition(FireX1, FireY1);
                    Console.Write(" |                         | | .                . |                          |   . |                          |");
                    Console.SetCursorPosition(FireX2, FireY2);
                    Console.Write(" |                         |/|  .               . |                          |   . |                          |");
                    Console.SetCursorPosition(FireX3, FireY3);
                    Console.Write(" (=========================)  || .              . (==========================)   . (==========================)");
                    Console.SetCursorPosition(FireX4, FireY4);
                    Console.Write("     |_________________________|/|.             . ||------------------------||   . ||------------------------||");
                    Console.SetCursorPosition(FireX5, FireY5);
                    Console.Write("     |                         | | .            . |                          |   . |                          |");
                    Console.SetCursorPosition(FireX6, FireY6);
                    Console.Write("     |                         |/|  .           . |                          |   . |                          |");
                    Console.SetCursorPosition(FireX7, FireY7);
                    Console.Write("     (=========================)  || .          . (==========================|   . (==========================|");
                    Console.SetCursorPosition(FireX8, FireY8);
                    Console.Write("  .      |_________________________|/|.         . ||------------------------||   . ||------------------------||");
                    Console.SetCursorPosition(FireX9, FireY9);
                    Console.Write("   .     |                         | | .        . |                          |   . |                          |");
                    Console.SetCursorPosition(FireX10, FireY10);
                    Console.Write("    .    |                         |/|  .       . |                          |   . |                          |");
                    Console.SetCursorPosition(FireX11, FireY11);
                    Console.Write("     .   (=========================)     .      . (==========================)   . (==========================)");
                    Console.SetCursorPosition(FireX12, FireY12);
                    Console.Write("      .         /|\\     |______________________________________|/     /|\\  ____________________________________");
                    Console.SetCursorPosition(FireX13, FireY13);
                    Console.Write("       .         |      /_______________________________________//     |");
                    Console.SetCursorPosition(FireX14, FireY14);
                    Console.Write(" .      .       _U_      /                 |___|                 //   _U_");
                    Console.SetCursorPosition(FireX15, FireY15);
                    Console.Write("  .      |_______^________/                | + |                  /____^_____");
                    Console.SetCursorPosition(FireX16, FireY16);
                    Console.Write("   .     |                 ________________|   |_______________________________________________________________");
                    Console.SetCursorPosition(FireX17, FireY17);
                    Console.Write("    .    |                      ||          ___          ||");
                    Console.SetCursorPosition(FireX18, FireY18);
                    Console.Write("     .   |       |____|         ||                       ||         |____|                |____|");
                    Console.SetCursorPosition(FireX19, FireY19);
                    Console.Write("      .  |       |o x.|        =**=                     =**=        | o $|                | * x|");
                    Console.SetCursorPosition(FireX20, FireY20);
                    Console.Write("       . |       / +  \\         ||                       ||         /+ . \\                /+ . \\");
                    Console.SetCursorPosition(FireX21, FireY21);
                    Console.Write("        ..        ____                                               ____                  ____");

                    Console.SetCursorPosition(triggerX, triggerY);
                    Console.Write("(\\*~*)");
                    Console.SetCursorPosition(HtriggerX, HtriggerY);
                    Console.Write("  /\\");

                    for (int a = 29; a < 56; a++)
                    {
                        Console.SetCursorPosition(triggerX, triggerY);
                        Console.Write(" ");
                        Console.SetCursorPosition(HtriggerX, HtriggerY);
                        Console.Write(" ");

                        triggerX++;

                        HtriggerX++;

                        Console.SetCursorPosition(triggerX, triggerY);
                        Console.Write("(\\*~*)");
                        Console.SetCursorPosition(HtriggerX, HtriggerY);
                        Console.Write("  /\\");

                        Thread.Sleep(100);
                    }


                    int AnimX = 56;
                    int AnimY = 16;

                    if (AnimX == triggerX & AnimY == triggerY)
                    {
                        break;
                    }
                }

                Console.CursorVisible = false;
                while (true)
                {
                    Console.Clear();

                    //INCHER
                    Console.SetCursorPosition(FireX, FireY);
                    Console.Write(" |                        || .                  . ||                        ||   . ||                        ||");
                    Console.SetCursorPosition(FireX0, FireY0);
                    Console.Write(" |_________________________|/|.                 . | ________________________ |   . | ________________________ |");
                    Console.SetCursorPosition(FireX1, FireY1);
                    Console.Write(" |                         | | .                . |                          |   . |                          |");
                    Console.SetCursorPosition(FireX2, FireY2);
                    Console.Write(" |                         |/|  .               . |                          |   . |                          |");
                    Console.SetCursorPosition(FireX3, FireY3);
                    Console.Write(" (=========================)  || .              . (==========================)   . (==========================)");
                    Console.SetCursorPosition(FireX4, FireY4);
                    Console.Write("     |_________________________|/|.             . ||------------------------||   . ||------------------------||");
                    Console.SetCursorPosition(FireX5, FireY5);
                    Console.Write("     |                         | | .            . |                          |   . |                          |");
                    Console.SetCursorPosition(FireX6, FireY6);
                    Console.Write("     |                         |/|  .           . |                          |   . |                          |");
                    Console.SetCursorPosition(FireX7, FireY7);
                    Console.Write("     (=========================)  || .          . (==========================|   . (==========================|");
                    Console.SetCursorPosition(FireX8, FireY8);
                    Console.Write("  .      |_________________________|/|.         . ||------------------------||   . ||------------------------||");
                    Console.SetCursorPosition(FireX9, FireY9);
                    Console.Write("   .     |                         | | .        . |                          |   . |                          |");
                    Console.SetCursorPosition(FireX10, FireY10);
                    Console.Write("    .    |                         |/|  .       . |                          |   . |                          |");
                    Console.SetCursorPosition(FireX11, FireY11);
                    Console.Write("     .   (=========================)     .      . (==========================)   . (==========================)");
                    Console.SetCursorPosition(FireX12, FireY12);
                    Console.Write("      .         /|\\     |______________________________________|/     /|\\  ____________________________________");
                    Console.SetCursorPosition(FireX13, FireY13);
                    Console.Write("       .         |      /_______________________________________//     |");
                    Console.SetCursorPosition(FireX14, FireY14);
                    Console.Write(" .      .       _U_      /                 |___|                 //   _U_");
                    Console.SetCursorPosition(FireX15, FireY15);
                    Console.Write("  .      |_______^________/                | + |                  /____^_____");
                    Console.SetCursorPosition(FireX16, FireY16);
                    Console.Write("   .     |                 ________________|   |_______________________________________________________________");
                    Console.SetCursorPosition(FireX17, FireY17);
                    Console.Write("    .    |                      ||          ___          ||");
                    Console.SetCursorPosition(FireX18, FireY18);
                    Console.Write("     .   |       |____|         ||                       ||         |____|                |____|");
                    Console.SetCursorPosition(FireX19, FireY19);
                    Console.Write("      .  |       |o x.|        =**=                     =**=        | o $|                | * x|");
                    Console.SetCursorPosition(FireX20, FireY20);
                    Console.Write("       . |       / +  \\         ||                       ||         /+ . \\                /+ . \\");
                    Console.SetCursorPosition(FireX21, FireY21);
                    Console.Write("        ..        ____                                               ____                  ____");

                    Console.SetCursorPosition(triggerX, triggerY);
                    Console.Write("(\\*~*)");
                    Console.SetCursorPosition(HtriggerX, HtriggerY);
                    Console.Write("  /\\");

                    Console.SetCursorPosition(playerXC, playerYC);
                    Console.Write("^o_o^");
                    ConsoleKeyInfo keyC = Console.ReadKey(true);
                    char key = keyC.KeyChar;
                    switch (key)
                    {
                        case 'w':
                        case 'ц':
                            playerYC--;
                            break;
                        case 's':
                        case 'ы':
                            playerYC++;
                            break;
                        case 'a':
                        case 'ф':
                            playerXC--;
                            break;
                        case 'd':
                        case 'в':
                            playerXC++;
                            break;
                        case 'q':
                        case 'й':
                            Console.CursorVisible = true;
                            break;
                    }

                    if (PtriggerX == playerXC && PtriggerY == playerYC)
                    {
                        Console.Clear();
                        string textH = "Welcome, dear guest. How kind of you to visit. I am... so bored. I am so glad that someone finally came to see me. You probably want to know who you are talking to, but I do not share my secrets. Only if you play with me :) I love one game in particular, would you like to play it with me? Press Enter to choose.";
                        int lengthH = textH.Length;
                        int cursorH = 0;
                        while (lengthH > Console.WindowWidth)
                        {
                            string newLineH = textH.Substring(cursorH, Console.WindowWidth - 4);
                            int lineLengthH = newLineH.LastIndexOf(' ');
                            cursorH += lineLengthH;
                            textH = textH.Insert(cursorH, "\n");
                            lengthH -= lineLengthH;
                        }
                        string[] lines1 = Regex.Split(textH, "\r\n|\r|\n");
                        int left1 = 0;
                        int top1 = (Console.WindowHeight / 2) - (lines1.Length / 2) - 1;
                        int center1 = Console.WindowWidth / 2;
                        for (int i = 0; i < lines1.Length; i++)
                        {
                            left1 = center1 - (lines1[i].Length / 2);
                            Console.SetCursorPosition(left1, top1);
                            Console.WriteLine(lines1[i]);
                            top1 = Console.CursorTop;
                        }

                        Console.ReadLine().ToLower();
                        Console.Clear();
                        break;
                    }
                }

                Console.WriteLine("Enter y to participate or n to opt out.");
                string userPut = Console.ReadLine().ToLower();
                if (userPut == "y")
                {
                    Console.Clear();
                    string textViborY = ("Look, it's all very simple: you just need to dodge my attacks. You already learned how to move on your way here, and nothing has changed in that regard, except now you have lives. If you lose them, it means you're dead. Although, don't you worry — you still have 9 left, just like all cats :) Press C to continue.");
                    int lengthY = textViborY.Length;
                    int cursorY = 0;
                    while (lengthY > Console.WindowWidth)
                    {
                        string newLineY = textViborY.Substring(cursorY, Console.WindowWidth - 4);
                        int lineLengthY = newLineY.LastIndexOf(' ');
                        cursorY += lineLengthY;
                        textViborY = textViborY.Insert(cursorY, "\n");
                        lengthY -= lineLengthY;
                    }
                    string[] linesY = Regex.Split(textViborY, "\r\n|\r|\n");
                    int leftY = 0;
                    int topY = (Console.WindowHeight / 2) - (linesY.Length / 2) - 1;
                    int centerViborY = Console.WindowWidth / 2;

                    for (int i = 0; i < linesY.Length; i++)
                    {
                        leftY = centerViborY - (linesY[i].Length / 2);
                        Console.SetCursorPosition(leftY, topY);
                        Console.WriteLine(linesY[i]);
                        topY = Console.CursorTop;
                    }

                    string additionalInput = Console.ReadLine().ToLower();

                    if (additionalInput == "c")
                    {
                        Console.Clear();
                        string textViborC = ("FIGHT begins! PRESS Enter to continue...");
                        int lengthC = textViborC.Length;
                        int cursorC = 0;
                        while (lengthC > Console.WindowWidth)
                        {
                            string newLineC = textViborC.Substring(cursorC, Console.WindowWidth - 4);
                            int lineLengthC = newLineC.LastIndexOf(' ');
                            cursorC += lineLengthC;
                            textViborC = textViborC.Insert(cursorC, "\n");
                            lengthC -= lineLengthC;
                        }
                        string[] linesC = Regex.Split(textViborC, "\r\n|\r|\n");
                        int leftC = 0;
                        int topC = (Console.WindowHeight / 2) - (linesC.Length / 2) - 1;
                        int centerC = Console.WindowWidth / 2;

                        for (int i = 0; i < linesC.Length; i++)
                        {
                            leftC = centerC - (linesC[i].Length / 2);
                            Console.SetCursorPosition(leftC, topC);
                            Console.WriteLine(linesC[i]);
                            topC = Console.CursorTop;
                        }
                        Console.ReadLine();
                    }
                }

                else if (userPut == "n")
                {
                    Console.Clear();
                    string textViborN = ("As I see it, you're not interested in anything... But you have nowhere else to go anyway. So fight me, or I shall call you a pathetic coward. PRESS C to continue.");
                    int lengthN = textViborN.Length;
                    int cursorN = 0;
                    while (lengthN > Console.WindowWidth)
                    {
                        string newLineN = textViborN.Substring(cursorN, Console.WindowWidth - 4);
                        int lineLengthN = newLineN.LastIndexOf(' ');
                        cursorN += lineLengthN;
                        textViborN = textViborN.Insert(cursorN, "\n");
                        lengthN -= lineLengthN;
                    }
                    string[] linesN = Regex.Split(textViborN, "\r\n|\r|\n");
                    int leftN = 0;
                    int topN = (Console.WindowHeight / 2) - (linesN.Length / 2) - 1;
                    int centerN = Console.WindowWidth / 2;

                    for (int i = 0; i < linesN.Length; i++)
                    {
                        leftN = centerN - (linesN[i].Length / 2);
                        Console.SetCursorPosition(leftN, topN);
                        Console.WriteLine(linesN[i]);
                        topN = Console.CursorTop;
                    }

                    string additionalInput = Console.ReadLine().ToLower();

                    if (additionalInput == "c")
                    {
                        Console.Clear();
                        string textViborC = ("Look, it's very simple: you just need to dodge my attacks. You already learned how to move on your way here, and nothing has changed in that regard, except now you have lives. If you lose them, it means you're dead. Although, you don't need to worry — you still have 9 left, just like all cats. So fight! PRESS Enter to continue.");
                        int lengthC = textViborC.Length;
                        int cursorC = 0;
                        while (lengthC > Console.WindowWidth)
                        {
                            string newLineC = textViborC.Substring(cursorC, Console.WindowWidth - 4);
                            int lineLengthC = newLineC.LastIndexOf(' ');
                            cursorC += lineLengthC;
                            textViborC = textViborC.Insert(cursorC, "\n");
                            lengthC -= lineLengthC;
                        }
                        string[] linesC = Regex.Split(textViborC, "\r\n|\r|\n");
                        int leftC = 0;
                        int topC = (Console.WindowHeight / 2) - (linesC.Length / 2) - 1;
                        int centerC = Console.WindowWidth / 2;

                        for (int i = 0; i < linesC.Length; i++)
                        {
                            leftC = centerC - (linesC[i].Length / 2);
                            Console.SetCursorPosition(leftC, topC);
                            Console.WriteLine(linesC[i]);
                            topC = Console.CursorTop;
                        }
                        Console.ReadLine();
                    }
                }
                Console.Clear();

                Console.CursorVisible = false;
                int SavePlayerX = 0;
                int SavePlayerY = 14;

                //lowL
                int TeacherXL = 85;
                int TeacherYL = 29;
                int TeacherXL0 = 86;
                int TeacherYL0 = 28;
                int TeacherXL1 = 87;
                int TeacherYL1 = 27;

                //lowR
                int TeacherXR = 119;
                int TeacherYR = 29;
                int TeacherXR0 = 118;
                int TeacherYR0 = 28;
                int TeacherXR1 = 117;
                int TeacherYR1 = 27;

                //teac
                int TeacherX = 88;
                int TeacherY = 26;

                //teachHead
                int teachHeadX = 98;
                int teachHeadY = 26;
                int teachHeadX0 = 105;
                int teachHeadY0 = 26;
                int teachHeadX1 = 97;
                int teachHeadY1 = 25;
                int teachHeadX2 = 106;
                int teachHeadY2 = 25;
                int teachHeadX3 = 96;
                int teachHeadY3 = 24;
                int teachHeadX4 = 107;
                int teachHeadY4 = 24;

                //l
                int teachHeadX5 = 95;
                int teachHeadY5 = 23;
                int teachHeadX6 = 95;
                int teachHeadY6 = 22;
                int teachHeadX7 = 95;
                int teachHeadY7 = 21;
                int teachHeadX8 = 95;
                int teachHeadY8 = 20;

                //r
                int teachHeadX9 = 108;
                int teachHeadY9 = 23;
                int teachHeadX10 = 108;
                int teachHeadY10 = 22;
                int teachHeadX11 = 108;
                int teachHeadY11 = 21;
                int teachHeadX12 = 108;
                int teachHeadY12 = 20;

                //U
                int Teacher1XL = 95;
                int Teacher1YL = 19;
                int TeacherX1L0 = 96;
                int TeacherY1L0 = 18;
                int TeacherX1L1 = 97;
                int TeacherY1L1 = 17;

                int Teacher1XR = 108;
                int Teacher1YR = 19;
                int TeacherX1R0 = 107;
                int TeacherY1R0 = 18;
                int TeacherX1R1 = 106;
                int TeacherY1R1 = 17;

                int TeacherUX = 98;
                int TeacherUY = 16;

                //glasses
                int glassX0 = 98;
                int glassY0 = 19;
                int glassX = 96;
                int glassY = 20;
                int glassX1 = 100;
                int glassY1 = 20;
                int glassX2 = 97;
                int glassY2 = 21;

                int glassX3 = 101;
                int glassY3 = 20;

                int glassX4 = 103;
                int glassY4 = 20;
                int glassX5 = 104;
                int glassY5 = 19;
                int glassX6 = 106;
                int glassY6 = 20;
                int glassX7 = 103;
                int glassY7 = 21;

                //hair
                int hairX = 98;
                int hairY = 17;

                //rot
                int mouthX = 100;
                int mouthY = 24;

                //beard
                int beardX = 100;
                int beardY = 23;

                //cloud
                int cloudX0 = 55;
                int cloudY0 = 14;
                int cloudX = 55;
                int cloudY = 13;
                int cloudX1 = 56;
                int cloudY1 = 12;
                int cloudX2 = 57;
                int cloudY2 = 11;
                int cloudX3 = 57;
                int cloudY3 = 10;

                //textInCloud
                int textCX = 59;
                int textCY = 11;
                int textCX0 = 58;
                int textCY0 = 12;
                int textCX1 = 57;
                int textCY1 = 13;

                //textStar
                int textSX = 73;
                int textSY = 5;
                int textSX1 = 73;
                int textSY1 = 6;

                string starToBlink = "*";
                int StarDelay = 250;
                int blinkCount = 5;
                int StarPosX = 73;
                int StarPosY = 4;


                for (int i = 0; i < blinkCount; i++)
                {
                    Console.SetCursorPosition(StarPosX, StarPosY);
                    Console.Write(starToBlink);
                    Thread.Sleep(StarDelay);
                    Console.Write(new string(' ', starToBlink.Length));
                    Console.SetCursorPosition(StarPosX, StarPosY);
                    Console.Write(starToBlink);
                    Thread.Sleep(StarDelay);

                    Console.SetCursorPosition(StarPosX, StarPosY);
                    Console.Write(new string(' ', starToBlink.Length));
                    Thread.Sleep(StarDelay);
                }
                Console.Clear();


                Console.CursorLeft = 0;
                while (true)
                {
                    Console.Clear();
                    Console.SetCursorPosition(SavePlayerX, SavePlayerY);
                    Console.Write("^o_o^");

                    //l
                    Console.SetCursorPosition(TeacherXL, TeacherYL);
                    Console.Write("/");
                    Console.SetCursorPosition(TeacherXL0, TeacherYL0);
                    Console.Write("/");
                    Console.SetCursorPosition(TeacherXL1, TeacherYL1);
                    Console.Write("/");
                    //r
                    Console.SetCursorPosition(TeacherXR, TeacherYR);
                    Console.Write("\\");
                    Console.SetCursorPosition(TeacherXR0, TeacherYR0);
                    Console.Write("\\");
                    Console.SetCursorPosition(TeacherXR1, TeacherYR1);
                    Console.Write("\\");
                    //teac
                    Console.SetCursorPosition(TeacherX, TeacherY);
                    Console.Write("_____________________________");
                    //teacHead
                    Console.SetCursorPosition(teachHeadX, teachHeadY);
                    Console.Write("\\");
                    Console.SetCursorPosition(teachHeadX0, teachHeadY0);
                    Console.Write("/");
                    Console.SetCursorPosition(teachHeadX1, teachHeadY1);
                    Console.Write("\\");
                    Console.SetCursorPosition(teachHeadX2, teachHeadY2);
                    Console.Write("/");
                    Console.SetCursorPosition(teachHeadX3, teachHeadY3);
                    Console.Write("\\");
                    Console.SetCursorPosition(teachHeadX4, teachHeadY4);
                    Console.Write("/");

                    Console.SetCursorPosition(teachHeadX5, teachHeadY5);
                    Console.Write("|");
                    Console.SetCursorPosition(teachHeadX6, teachHeadY6);
                    Console.Write("|");
                    Console.SetCursorPosition(teachHeadX7, teachHeadY7);
                    Console.Write("|");
                    Console.SetCursorPosition(teachHeadX8, teachHeadY8);
                    Console.Write("|");

                    Console.SetCursorPosition(teachHeadX9, teachHeadY9);
                    Console.Write("|");
                    Console.SetCursorPosition(teachHeadX10, teachHeadY10);
                    Console.Write("|");
                    Console.SetCursorPosition(teachHeadX11, teachHeadY11);
                    Console.Write("|");
                    Console.SetCursorPosition(teachHeadX12, teachHeadY12);
                    Console.Write("|");

                    Console.SetCursorPosition(Teacher1XL, Teacher1YL);
                    Console.Write("/");
                    Console.SetCursorPosition(TeacherX1L0, TeacherY1L0);
                    Console.Write("/");
                    Console.SetCursorPosition(TeacherX1L1, TeacherY1L1);
                    Console.Write("/");

                    Console.SetCursorPosition(Teacher1XR, Teacher1YR);
                    Console.Write("\\");
                    Console.SetCursorPosition(TeacherX1R0, TeacherY1R0);
                    Console.Write("\\");
                    Console.SetCursorPosition(TeacherX1R1, TeacherY1R1);
                    Console.Write("\\");

                    Console.SetCursorPosition(TeacherUX, TeacherUY);
                    Console.Write("________");

                    //glases
                    Console.SetCursorPosition(glassX0, glassY0);
                    Console.Write("__");
                    Console.SetCursorPosition(glassX, glassY);
                    Console.Write("\\/@");
                    Console.SetCursorPosition(glassX1, glassY1);
                    Console.Write("\\");
                    Console.SetCursorPosition(glassX2, glassY2);
                    Console.Write("\\__/");
                    Console.SetCursorPosition(glassX3, glassY3);
                    Console.Write("__");
                    Console.SetCursorPosition(glassX4, glassY4);
                    Console.Write("/@");
                    Console.SetCursorPosition(glassX5, glassY5);
                    Console.Write("__");
                    Console.SetCursorPosition(glassX6, glassY6);
                    Console.Write("\\/");
                    Console.SetCursorPosition(glassX7, glassY7);
                    Console.Write("\\__/");

                    //hair
                    Console.SetCursorPosition(hairX, hairY);
                    Console.Write("\\|/|\\|/|");

                    //mouth
                    Console.SetCursorPosition(mouthX, mouthY);
                    Console.Write("-~-");

                    //beard
                    Console.SetCursorPosition(beardX, beardY);
                    Console.Write("/||\\");

                    //cloud
                    Console.SetCursorPosition(cloudX0, cloudY0);
                    Console.Write(" (________________________________________)");
                    Console.SetCursorPosition(cloudX, cloudY);
                    Console.Write(" (                                          )");
                    Console.SetCursorPosition(cloudX1, cloudY1);
                    Console.Write(" (                                              )");
                    Console.SetCursorPosition(cloudX2, cloudY2);
                    Console.Write(" (                                           )");
                    Console.SetCursorPosition(cloudX3, cloudY3);
                    Console.Write("  ____________________________________________");

                    //textInCloud
                    Console.SetCursorPosition(textCX, textCY);
                    Console.Write("But first, you need to learn how to save,");
                    Console.SetCursorPosition(textCX0, textCY0);
                    Console.Write("There is a little helper star just over there.");
                    Console.SetCursorPosition(textCX1, textCY1);
                    Console.Write("You must touch it to save your progress.");

                    //textStar
                    Console.SetCursorPosition(textSX, textSY);
                    Console.Write("^");
                    Console.SetCursorPosition(textSX1, textSY1);
                    Console.Write("|");
                    Console.SetCursorPosition(StarPosX, StarPosY);
                    Console.Write(starToBlink);

                    ConsoleKeyInfo keySaveProb = Console.ReadKey(true);
                    char key = keySaveProb.KeyChar;
                    switch (key)
                    {
                        case 'w':
                        case 'ц':
                            SavePlayerY--;
                            break;
                        case 's':
                        case 'ы':
                            SavePlayerY++;
                            break;
                        case 'a':
                        case 'ф':
                            SavePlayerX--;
                            break;
                        case 'd':
                        case 'в':
                            SavePlayerX++;
                            break;
                        case 'q':
                        case 'й':
                            Console.CursorVisible = true;
                            break;
                    }
                    int triggerSX = 69;
                    int triggerSY = 4;
                    if (SavePlayerX == triggerSX && SavePlayerY == triggerSY)
                    {
                        Console.Clear();
                        break;
                    }
                }

                Console.CursorVisible = false;
                string EndFIghttext = $"Here I am again, my dear friend, your faithful teacher and guide. I want to tell you that you’ve learned how to fight. Now, get ready — adventures await you! On your path, there will be turn-based battles against monsters and all sorts of demons, as well as boss fights. The boss battles will be identical to the one you just had. There will be various hints along the way, and you will immerse yourself in this strange but exciting world of ConsoleCat. Until we meet again, I must depart.";
                int EndFIghtlength = EndFIghttext.Length;
                int EndFIghtcursor = 0;
                while (EndFIghtlength > Console.WindowWidth)
                {
                    string EndFIghtnewLine = EndFIghttext.Substring(EndFIghtcursor, Console.WindowWidth - 4);
                    int EndFIghtlineLength = EndFIghtnewLine.LastIndexOf(' ');
                    EndFIghtcursor += EndFIghtlineLength;
                    EndFIghttext = EndFIghttext.Insert(EndFIghtcursor, "\n");
                    EndFIghtlength -= EndFIghtlineLength;
                }
                string[] EndFIghtlines = Regex.Split(EndFIghttext, "\r\n|\r|\n");
                int EndFIghtleft = 0;
                int EndFIghttop = (Console.WindowHeight / 2) - (EndFIghtlines.Length / 2) - 1;
                int EndFIghtcenter = Console.WindowWidth / 2;

                for (int i = 0; i < EndFIghtlines.Length; i++)
                {
                    EndFIghtleft = EndFIghtcenter - (EndFIghtlines[i].Length / 2);
                    Console.SetCursorPosition(EndFIghtleft, EndFIghttop);
                    Console.WriteLine(EndFIghtlines[i]);
                    EndFIghttop = Console.CursorTop;
                }

                //l
                Console.SetCursorPosition(TeacherXL, TeacherYL);
                Console.Write("/");
                Console.SetCursorPosition(TeacherXL0, TeacherYL0);
                Console.Write("/");
                Console.SetCursorPosition(TeacherXL1, TeacherYL1);
                Console.Write("/");
                //r
                Console.SetCursorPosition(TeacherXR, TeacherYR);
                Console.Write("\\");
                Console.SetCursorPosition(TeacherXR0, TeacherYR0);
                Console.Write("\\");
                Console.SetCursorPosition(TeacherXR1, TeacherYR1);
                Console.Write("\\");
                //teac
                Console.SetCursorPosition(TeacherX, TeacherY);
                Console.Write("_____________________________");
                //teacHead
                Console.SetCursorPosition(teachHeadX, teachHeadY);
                Console.Write("\\");
                Console.SetCursorPosition(teachHeadX0, teachHeadY0);
                Console.Write("/");
                Console.SetCursorPosition(teachHeadX1, teachHeadY1);
                Console.Write("\\");
                Console.SetCursorPosition(teachHeadX2, teachHeadY2);
                Console.Write("/");
                Console.SetCursorPosition(teachHeadX3, teachHeadY3);
                Console.Write("\\");
                Console.SetCursorPosition(teachHeadX4, teachHeadY4);
                Console.Write("/");

                Console.SetCursorPosition(teachHeadX5, teachHeadY5);
                Console.Write("|");
                Console.SetCursorPosition(teachHeadX6, teachHeadY6);
                Console.Write("|");
                Console.SetCursorPosition(teachHeadX7, teachHeadY7);
                Console.Write("|");
                Console.SetCursorPosition(teachHeadX8, teachHeadY8);
                Console.Write("|");

                Console.SetCursorPosition(teachHeadX9, teachHeadY9);
                Console.Write("|");
                Console.SetCursorPosition(teachHeadX10, teachHeadY10);
                Console.Write("|");
                Console.SetCursorPosition(teachHeadX11, teachHeadY11);
                Console.Write("|");
                Console.SetCursorPosition(teachHeadX12, teachHeadY12);
                Console.Write("|");

                Console.SetCursorPosition(Teacher1XL, Teacher1YL);
                Console.Write("/");
                Console.SetCursorPosition(TeacherX1L0, TeacherY1L0);
                Console.Write("/");
                Console.SetCursorPosition(TeacherX1L1, TeacherY1L1);
                Console.Write("/");

                Console.SetCursorPosition(Teacher1XR, Teacher1YR);
                Console.Write("\\");
                Console.SetCursorPosition(TeacherX1R0, TeacherY1R0);
                Console.Write("\\");
                Console.SetCursorPosition(TeacherX1R1, TeacherY1R1);
                Console.Write("\\");

                Console.SetCursorPosition(TeacherUX, TeacherUY);
                Console.Write("________");

                //glases
                Console.SetCursorPosition(glassX0, glassY0);
                Console.Write("__");
                Console.SetCursorPosition(glassX, glassY);
                Console.Write("\\/@");
                Console.SetCursorPosition(glassX1, glassY1);
                Console.Write("\\");
                Console.SetCursorPosition(glassX2, glassY2);
                Console.Write("\\__/");
                Console.SetCursorPosition(glassX3, glassY3);
                Console.Write("__");
                Console.SetCursorPosition(glassX4, glassY4);
                Console.Write("/@");
                Console.SetCursorPosition(glassX5, glassY5);
                Console.Write("__");
                Console.SetCursorPosition(glassX6, glassY6);
                Console.Write("\\/");
                Console.SetCursorPosition(glassX7, glassY7);
                Console.Write("\\__/");

                //hair
                Console.SetCursorPosition(hairX, hairY);
                Console.Write("\\|/|\\|/|");

                //mouth
                Console.SetCursorPosition(mouthX, mouthY);
                Console.Write("-~-");

                //beard
                Console.SetCursorPosition(beardX, beardY);
                Console.Write("/||\\");
                Console.ReadLine().ToLower();
                Console.Clear();

                //EndFight
                Console.CursorVisible = false;
                //INCHERX
                Console.SetCursorPosition(FireX, FireY);
                Console.Write(" |                        || .                  . ||                        ||   . ||                        ||");
                Console.SetCursorPosition(FireX0, FireY0);
                Console.Write(" |_________________________|/|.                 . | ________________________ |   . | ________________________ |");
                Console.SetCursorPosition(FireX1, FireY1);
                Console.Write(" |                         | | .                . |                          |   . |                          |");
                Console.SetCursorPosition(FireX2, FireY2);
                Console.Write(" |                         |/|  .               . |                          |   . |                          |");
                Console.SetCursorPosition(FireX3, FireY3);
                Console.Write(" (=========================)  || .              . (==========================)   . (==========================)");
                Console.SetCursorPosition(FireX4, FireY4);
                Console.Write("     |_________________________|/|.             . ||------------------------||   . ||------------------------||");
                Console.SetCursorPosition(FireX5, FireY5);
                Console.Write("     |                         | | .            . |                          |   . |                          |");
                Console.SetCursorPosition(FireX6, FireY6);
                Console.Write("     |                         |/|  .           . |                          |   . |                          |");
                Console.SetCursorPosition(FireX7, FireY7);
                Console.Write("     (=========================)  || .          . (==========================|   . (==========================|");
                Console.SetCursorPosition(FireX8, FireY8);
                Console.Write("  .      |_________________________|/|.         . ||------------------------||   . ||------------------------||");
                Console.SetCursorPosition(FireX9, FireY9);
                Console.Write("   .     |                         | | .        . |                          |   . |                          |");
                Console.SetCursorPosition(FireX10, FireY10);
                Console.Write("    .    |                         |/|  .       . |                          |   . |                          |");
                Console.SetCursorPosition(FireX11, FireY11);
                Console.Write("     .   (=========================)     .      . (==========================)   . (==========================)");
                Console.SetCursorPosition(FireX12, FireY12);
                Console.Write("      .         /|\\     |______________________________________|/     /|\\  ____________________________________");
                Console.SetCursorPosition(FireX13, FireY13);
                Console.Write("       .         |      /_______________________________________//     |");
                Console.SetCursorPosition(FireX14, FireY14);
                Console.Write(" .      .       _U_      /                 |___|                 //   _U_");
                Console.SetCursorPosition(FireX15, FireY15);
                Console.Write("  .      |_______^________/                | + |                  /____^_____");
                Console.SetCursorPosition(FireX16, FireY16);
                Console.Write("   .     |                 ________________|   |_______________________________________________________________");
                Console.SetCursorPosition(FireX17, FireY17);
                Console.Write("    .    |                      ||          ___          ||");
                Console.SetCursorPosition(FireX18, FireY18);
                Console.Write("     .   |       |____|         ||                       ||         |____|                |____|");
                Console.SetCursorPosition(FireX19, FireY19);
                Console.Write("      .  |       |o x.|        =**=                     =**=        | o $|                | * x|");
                Console.SetCursorPosition(FireX20, FireY20);
                Console.Write("       . |       / +  \\         ||                       ||         /+ . \\                /+ . \\");
                Console.SetCursorPosition(FireX21, FireY21);
                Console.Write("        ..        ____                                               ____                  ____");

                //TrigChel
                int EndHtriggerX = 56;
                int EndHtriggerY = 15;
                int EndtriggerX = 56;
                int EndtriggerY = 16;

                int AnimX_Left = 47;
                int AnimY_Left = 16;

                int EndPtriggerX = 45;
                int EndPtriggerY = 19;
                Console.SetCursorPosition(EndPtriggerX, EndPtriggerY);
                Console.Write($"^o_o^");
                for (; EndtriggerX >= AnimX_Left;)
                {
                    Console.SetCursorPosition(EndtriggerX, EndtriggerY);
                    Console.Write("      ");
                    Console.SetCursorPosition(EndHtriggerX, EndHtriggerY);
                    Console.Write("    ");

                    EndtriggerX--;
                    EndHtriggerX--;

                    Console.SetCursorPosition(EndtriggerX, EndtriggerY);
                    Console.Write("(*~*/)");
                    Console.SetCursorPosition(EndHtriggerX, EndHtriggerY);
                    Console.Write("  /\\");

                    Thread.Sleep(100);

                    if (AnimX_Left == EndtriggerX && AnimY_Left == EndtriggerY)
                    {
                        break;
                    }
                }

                //TrigChel
                int YEndHtriggerX = 47;
                int YEndHtriggerY = 15;
                int YEndtriggerX = 47;
                int YEndtriggerY = 16;

                int AnimX_Down = 47;
                int AnimY_Down = 18;
                Console.CursorVisible = false;
                while (true)
                {
                    //INCHERY
                    Console.SetCursorPosition(FireX, FireY);
                    Console.Write(" |                        || .                  . ||                        ||   . ||                        ||");
                    Console.SetCursorPosition(FireX0, FireY0);
                    Console.Write(" |_________________________|/|.                 . | ________________________ |   . | ________________________ |");
                    Console.SetCursorPosition(FireX1, FireY1);
                    Console.Write(" |                         | | .                . |                          |   . |                          |");
                    Console.SetCursorPosition(FireX2, FireY2);
                    Console.Write(" |                         |/|  .               . |                          |   . |                          |");
                    Console.SetCursorPosition(FireX3, FireY3);
                    Console.Write(" (=========================)  || .              . (==========================)   . (==========================)");
                    Console.SetCursorPosition(FireX4, FireY4);
                    Console.Write("     |_________________________|/|.             . ||------------------------||   . ||------------------------||");
                    Console.SetCursorPosition(FireX5, FireY5);
                    Console.Write("     |                         | | .            . |                          |   . |                          |");
                    Console.SetCursorPosition(FireX6, FireY6);
                    Console.Write("     |                         |/|  .           . |                          |   . |                          |");
                    Console.SetCursorPosition(FireX7, FireY7);
                    Console.Write("     (=========================)  || .          . (==========================|   . (==========================|");
                    Console.SetCursorPosition(FireX8, FireY8);
                    Console.Write("  .      |_________________________|/|.         . ||------------------------||   . ||------------------------||");
                    Console.SetCursorPosition(FireX9, FireY9);
                    Console.Write("   .     |                         | | .        . |                          |   . |                          |");
                    Console.SetCursorPosition(FireX10, FireY10);
                    Console.Write("    .    |                         |/|  .       . |                          |   . |                          |");
                    Console.SetCursorPosition(FireX11, FireY11);
                    Console.Write("     .   (=========================)     .      . (==========================)   . (==========================)");
                    Console.SetCursorPosition(FireX12, FireY12);
                    Console.Write("      .         /|\\     |______________________________________|/     /|\\  ____________________________________");
                    Console.SetCursorPosition(FireX13, FireY13);
                    Console.Write("       .         |      /_______________________________________//     |");
                    Console.SetCursorPosition(FireX14, FireY14);
                    Console.Write(" .      .       _U_      /                 |___|                 //   _U_");
                    Console.SetCursorPosition(FireX15, FireY15);
                    Console.Write("  .      |_______^________/                | + |                  /____^_____");
                    Console.SetCursorPosition(FireX16, FireY16);
                    Console.Write("   .     |                 ________________|   |_______________________________________________________________");
                    Console.SetCursorPosition(FireX17, FireY17);
                    Console.Write("    .    |                      ||          ___          ||");
                    Console.SetCursorPosition(FireX18, FireY18);
                    Console.Write("     .   |       |____|         ||                       ||         |____|                |____|");
                    Console.SetCursorPosition(FireX19, FireY19);
                    Console.Write("      .  |       |o x.|        =**=                     =**=        | o $|                | * x|");
                    Console.SetCursorPosition(FireX20, FireY20);
                    Console.Write("       . |       / +  \\         ||                       ||         /+ . \\                /+ . \\");
                    Console.SetCursorPosition(FireX21, FireY21);
                    Console.Write("        ..        ____                                               ____                  ____");
                    Console.SetCursorPosition(YEndtriggerX, YEndtriggerY);
                    Console.Write("         ");
                    Console.SetCursorPosition(YEndHtriggerX, YEndHtriggerY);
                    Console.Write("    ");

                    Console.SetCursorPosition(EndPtriggerX, EndPtriggerY);
                    Console.Write($"^o_o^");

                    YEndtriggerY++;
                    YEndHtriggerY++;

                    Console.SetCursorPosition(YEndtriggerX, YEndtriggerY);
                    Console.Write("(*~*/)");
                    Console.SetCursorPosition(YEndHtriggerX, YEndHtriggerY);
                    Console.Write("  /\\");

                    Thread.Sleep(250);

                    if (AnimX_Down == YEndtriggerX && AnimY_Down == YEndtriggerY)
                    {
                        break;
                    }
                }
                Console.Clear();
                string EndPrologtext = $"Wow, you defeated me. Well then, a promise is a promise. I shall tell you about myself. I am not obsessed with society; this old church is my home, where I feel quite cozy. My name is Barsik Ponchikov — a mage who has conquered fear... As a token of our acquaintance, I give you my 'Naughty Stick'; it will definitely come in handy. My special advice to you: look for notes along your path, they will tell you much about everything that happened in this world. Now, close your eyes, and something you won't regret is about to appear.";
                int EndProloglength = EndPrologtext.Length;
                int EndPrologcursor = 0;
                while (EndProloglength > Console.WindowWidth)
                {
                    string EndProlognewLine = EndPrologtext.Substring(EndPrologcursor, Console.WindowWidth - 4);
                    int EndProloglineLength = EndProlognewLine.LastIndexOf(' ');
                    EndPrologcursor += EndProloglineLength;
                    EndPrologtext = EndPrologtext.Insert(EndPrologcursor, "\n");
                    EndProloglength -= EndProloglineLength;
                }
                string[] EndProloglines = Regex.Split(EndPrologtext, "\r\n|\r|\n");
                int EndPrologleft = 0;
                int EndPrologtop = (Console.WindowHeight / 2) - (EndProloglines.Length / 2) - 1;
                int EndPrologcenter = Console.WindowWidth / 2;

                for (int i = 0; i < EndProloglines.Length; i++)
                {
                    EndPrologleft = EndPrologcenter - (EndProloglines[i].Length / 2);
                    Console.SetCursorPosition(EndPrologleft, EndPrologtop);
                    Console.WriteLine(EndProloglines[i]);
                    EndPrologtop = Console.CursorTop;
                }
                Console.ReadLine().ToLower();
                Console.Clear();

                int centerX = Console.WindowWidth / 2;
                int centerY = Console.WindowHeight / 2;
                for (int number = 1; number <= 3; number++)
                {
                    Console.SetCursorPosition(centerX - 1, centerY);

                    Console.Write(number);

                    Thread.Sleep(1000);

                    Console.Clear();
                }
                Console.CursorVisible = false;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Clear();

                RainAnimation(3);
                Console.ReadKey();
                Console.ResetColor();
                Console.Clear();
                Console.CursorVisible = true;

                Console.Title = "Introduction";

                PlayIntroCutscene();
                Console.ResetColor();
                Console.Clear();
                Console.CursorVisible = true;
                Console.ReadKey();

                Console.ResetColor();
            }
        }
    }
}