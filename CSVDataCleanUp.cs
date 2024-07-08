using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO;
using System.Reflection.Metadata;
using System.Data;

namespace DataFormCleanUp
{

    

    class CSVDataCleanUp
    {
        public string CSVReadFile { get; set; }
        public  List<string[]> allLines = new List<string[]>();
        
        public void ReaderCleanUP(string filename)
        {
            CSVReadFile = filename;

            BagelCleanup();
        }
        public string BagelCleanup() 
        {
            try
            {

                // Open the text file using a StreamReader
                using (StreamReader reader = new StreamReader(CSVReadFile))
                {
                    string line;
                    string[] unfilteredData;
                    int count = 0;
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Process each line (here we just print it out)

                        unfilteredData = line.Split(",");
                        if (count == 0)
                        {
                            string[] filteredData = unfilteredData.Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
                            allLines.Add(filteredData);
                            count++;
                        }
                        else
                        {
                            for (int i = 0; i < unfilteredData.Length; i++)
                            {
                                // Create a new array to store processed elements
                                string[] processedArray = new string[unfilteredData.Length];

                                for (int j = 0; j < unfilteredData.Length; j++)
                                {
                                    if (string.IsNullOrWhiteSpace(unfilteredData[j]))
                                    {
                                        processedArray[j] = "0";
                                    }
                                    else
                                    {
                                        processedArray[j] = unfilteredData[j];
                                    }
                                }

                                // Add processed array to the result list
                                allLines.Add(processedArray);
                            }
                        }
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }
            try
            {
                string[] DatesArray = allLines[0];
                string[] IDArray = allLines[1];
                
                string fileName = "CleanedDatafile.txt";
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string filePath = Path.Combine(desktopPath, fileName);
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.Write("Date" + ",");
                    for (int a = 1; a < IDArray.Length; a++)
                    {
                        writer.Write(IDArray[a] + ",");
                        
                    }
                    writer.Write("$$$$$");
                    for (int i = 0; i < DatesArray.Length; i++)
                    {
                        if (i == 0)
                        {
                            // Add a comma and a new line, except for the first line
                            writer.Write("\n");
                        }
                        //    writer.Write(DatesArray[i] + ",");
                    }

                    foreach (var items in allLines)
                    {

                        for (int j = 0; j < items.Length; j++)
                        {
                            writer.Write(items[j].ToString() + ",");
                        }
                        writer.Write("\n");

                        // Write the current element

                    }
                    //for (int x = 2; x < allLines.Count; x++)
                    //{
                    //    writer.Write(allLines[x].Count());
                    //    for (int q = 0; q < DatesArray.Length; q++)
                    //    {

                    //        writer.Write(allLines[x][q].ToString());
                    //        writer.Write("\n");
                    //    }
                    //}
                    //foreach (var items in allLines)
                    //{
                    //    for (int q = 0; q < DatesArray.Length; q++)
                    //    {
                    //        writer.Write(DatesArray[q] + ",");
                    //        writer.Write(items[2 * q + 4]);
                    //        writer.Write(items[2 * q + 5]);
                    //        writer.Write("\n");
                    //    }
                    //}
                }
                return filePath;
            }
            catch (Exception ex)
            {
                throw new Exception("Error generating and downloading file: " + ex.Message);
            }
        }
        
    }
}
