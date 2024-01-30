namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var inputFilePath = args[0];
            var outputFilePath = args[1];
            //string inputFilePath = "input.txt";
            //string outputFilePath = "output.txt";
            //string inputData = "Hello, this is a test!";

            //    // Create instances of FileReader and FileWriter
            //CMGReader cmgReader = new CMGReader();
            //    CMGWriter cmgWriter = new CMGWriter();

            //    // Write data to a file using FileWriter
            //    cmgWriter.WriteToFile(inputFilePath, inputData);

            //    // Read data from the file using FileReader
            var readData = CMGReader.ReadFromFile(inputFilePath);

            //    // Write the read data to another file using FileWriter
            CMGWriter.WriteToFile(outputFilePath);

            //    // Display the content of the output file
            Console.WriteLine($"Content of {outputFilePath}:");
            Console.WriteLine(CMGReader.ReadFromFile(outputFilePath));
            //}



            // Testing write function:
            // 1. write the data read from test100CMG to empty cmg
            // 2. read that data to verify it is the same as the data just read (this means it has written properly)
        }
    }
}

