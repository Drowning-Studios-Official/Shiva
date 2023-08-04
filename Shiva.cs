using System;
using System.Diagnostics;
using System.IO;
using static System.Console;


//Console.Title = "Shiva: S - Secure, H - Highly, I - Impenetrable, V - Virtual, A - Virtual";

class SecureFileShredder
{
    // Number of times to overwrite the file with random data
    private const int NumOverwrites = 3;

    // Method to securely delete a file
    public static void SecureDelete(string filePath)
    {
        filePath = filePath.Trim(); // Trim leading and trailing white spaces

        if (File.Exists(filePath))
        {
            // Get the file size
            long fileSize = new FileInfo(filePath).Length;

            // Generate random data to overwrite the file content
            byte[] randomData = new byte[fileSize];
            new Random().NextBytes(randomData);

            try
            {
                // Overwrite the file content multiple times with random data
                using (FileStream stream = new FileStream(filePath, FileMode.Open))
                {
                    for (int i = 0; i < NumOverwrites; i++)
                    {
                        stream.Position = 0;
                        stream.Write(randomData, 0, randomData.Length);
                    }
                }

                // Truncate the file to its original size (fill with zeroes)
                using (FileStream stream = new FileStream(filePath, FileMode.Open))
                {
                    stream.SetLength(0);
                }

                // Delete the file
                File.Delete(filePath);

                WriteLine("Securely deleted: " + filePath);
            }
            catch (Exception ex)
            {
                WriteLine("Error occurred during secure deletion: " + ex.Message);
            }
        }
        else
        {
            WriteLine("File not found: " + filePath);
        }
    }
}


class Shiva
{

    static void Main()
    {
        while (true)
        {
            ShowWelcomePage();

            WriteLine("Choose an option:");
            WriteLine("1 - Select File");
            WriteLine("2 - Credits");
            WriteLine("3 - Exit");

            Write("Enter your choice: ");
            string choice = ReadLine();

            switch (choice)
            {
                case "1":
                    ShowSelectFilePage();
                    break;
                case "2":
                    ShowCreditsPage();
                    break;
                case "3":
                    WriteLine("Exiting the program...");
                    return;
                default:
                    WriteLine("Invalid choice. Please enter a valid option (1, 2, or 3).");
                    break;
            }

            if (choice != "3")
            {
                WriteLine("Press Enter to continue...");
                ReadLine();
                Clear();
            }
        }
    }

    static void ShowWelcomePage()
    {
        Clear();
        WriteLine(@"   d888888o.   8 8888        8  8 8888 `8.`888b           ,8' .8.          
 .`8888:' `88. 8 8888        8  8 8888  `8.`888b         ,8' .888.         
 8.`8888.   Y8 8 8888        8  8 8888   `8.`888b       ,8' :88888.        
 `8.`8888.     8 8888        8  8 8888    `8.`888b     ,8' . `88888.       
  `8.`8888.    8 8888        8  8 8888     `8.`888b   ,8' .8. `88888.      
   `8.`8888.   8 8888        8  8 8888      `8.`888b ,8' .8`8. `88888.     
    `8.`8888.  8 8888888888888  8 8888       `8.`888b8' .8' `8. `88888.    
8b   `8.`8888. 8 8888        8  8 8888        `8.`888b .8'   `8. `88888.   
`8b.  ;8.`8888 8 8888        8  8 8888         `8.`8' .888888888. `88888.  
 `Y8888P ,88P' 8 8888        8  8 8888          `8.` .8'       `8. `88888. 
");
        WriteLine("Version: 01.0.00");
        WriteLine("------------------------------");
        WriteLine("Named after the Hindu god of destruction, Shiva is a powerful terminal application that securely and permanently destroys sensitive files. Its advanced algorithms overwrite file content with random data multiple times, ensuring data recovery is virtually impossible. Embrace Shiva's protective nature to confidently delete confidential files and safeguard your privacy. With Shiva, you have a robust and secure solution for file disposal in the terminal environment.");
        WriteLine("------------------------------");
    }

    static void ShowSelectFilePage()
    {
        Clear();
        WriteLine("\r\nPlease note that when using this application, make sure to enter the full file path of the item you want to delete. For example, if you want to delete a file named \"file.exe\" located on the desktop of the user \"user,\" the correct input should look like this: \"C:\\user\\desktop\\file.exe\". Providing the accurate and complete file path ensures that Shiva targets the correct file for secure deletion, preventing accidental deletion of other files. Always exercise caution and verify the path before confirming the deletion to avoid any data loss.");
        WriteLine("");
        WriteLine("Please enter the path of the file you want to securely delete:");
        string filePath = ReadLine();
        SecureFileShredder.SecureDelete(filePath);
    }

    static void ShowCreditsPage()
    {
        Clear();
        WriteLine(@"    ,o888888o.    8 888888888o.   8 8888888888   8 888888888o.       8 8888 8888888 8888888888 d888888o.   
   8888     `88.  8 8888    `88.  8 8888         8 8888    `^888.    8 8888       8 8888     .`8888:' `88. 
,8 8888       `8. 8 8888     `88  8 8888         8 8888        `88.  8 8888       8 8888     8.`8888.   Y8 
88 8888           8 8888     ,88  8 8888         8 8888         `88  8 8888       8 8888     `8.`8888.     
88 8888           8 8888.   ,88'  8 888888888888 8 8888          88  8 8888       8 8888      `8.`8888.    
88 8888           8 888888888P'   8 8888         8 8888          88  8 8888       8 8888       `8.`8888.   
88 8888           8 8888`8b       8 8888         8 8888         ,88  8 8888       8 8888        `8.`8888.  
`8 8888       .8' 8 8888 `8b.     8 8888         8 8888        ,88'  8 8888       8 8888    8b   `8.`8888. 
   8888     ,88'  8 8888   `8b.   8 8888         8 8888    ,o88P'    8 8888       8 8888    `8b.  ;8.`8888 
    `8888888P'    8 8888     `88. 8 888888888888 8 888888888P'       8 8888       8 8888     `Y8888P ,88P'                                                
");
        WriteLine("------------------------------");
        WriteLine("Shiva: S - Secure, H - Highly, I - Impenetrable, V - Virtual, A - Virtual");
        WriteLine("------------------------------");
        WriteLine("Version: 01.0.00");
        WriteLine("Developed by Drowning Studios");
        WriteLine("Website: https://www.drowningstudios.xyz");
        WriteLine(@"GitHub: https://github.com/Drowning-Studios-Official/shiva.git");
        WriteLine("------------------------------");
        WriteLine("Copyright (c) 2023 Drowning Studios Official");
    }
}