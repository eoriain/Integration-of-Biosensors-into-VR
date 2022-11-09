using System;
using System.IO;
using System.Linq;

namespace EmpaticaBLEClient
{
    // State object for receiving data from remote device.

    public class Program
    {
        static void Main(string[] args)
        {
            // Value which is passed from UE4. It is used to sync time between this and UE4
            ulong initialTime = 0;

            try
            {
                initialTime = ulong.Parse(args[0]);
            }
            catch (Exception e)
            {
                Console.WriteLine("No InitialTime supplied or invalid value.");
                initialTime = AttemptReadTimeFromFile();
            }

            string SaveFileLocation;
            if (AttemptReadSaveFileLocation(out SaveFileLocation))
            {
                Console.WriteLine(SaveFileLocation);
            }
            else
            {
                SaveFileLocation = "C:/Users/elor1/Desktop/";
            }

            Console.WriteLine("T: " + initialTime);
            
            AsynchronousClient.StartClient(initialTime, SaveFileLocation);

            Console.ReadKey();
        }

        /*
         *  Attempts to find file Timestamp.flb which should be in the same directory as this file
         *  If the file is found then this will attempt to read the timestamp from it
         *  @return - The found timestamp (in nanoseconds since epoch)
         */
        static ulong AttemptReadTimeFromFile()
        {
            ulong foundValue = 0;

            string path = Path.Combine(Environment.CurrentDirectory, "Timestamp.flb");

            try
            {
                StreamReader reader = File.OpenText(path);
                string line;

                line = reader.ReadLine();

                foundValue = Convert.ToUInt64(line);
            }
            catch(Exception e)
            {
                Console.WriteLine("EXCEPTION: " + e);
            }

            return foundValue;
        }

        static bool AttemptReadSaveFileLocation(out string SaveFileLocation)
        {
            string path = Path.Combine(Environment.CurrentDirectory, "ExperimentConfig.flb");

            bool SaveFileLocationFound = false;

            SaveFileLocation = "";

            try
            {
                StreamReader reader = File.OpenText(path);
                string line;

                while (!reader.EndOfStream)
                {
                    if (SaveFileLocationFound) break;
                    while (!SaveFileLocationFound)
                    {
                        line = reader.ReadLine();
                        if (line.Contains("SaveFileLocation"))
                        {
                            string[] words = line.Split(' ');
                            if (words.Length > 1)
                            {
                                SaveFileLocation = words[1];
                                SaveFileLocationFound = true;
                            }
                        }
                    }
                }
            }
            catch
            {
                return false;
            }

            return SaveFileLocationFound;
        }
    }
}
