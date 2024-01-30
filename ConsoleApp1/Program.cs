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
            //CMGWriter.WriteToFile(outputFilePath);
            byte[][][] Header = new byte[10][][];
            Header[0] = new byte[2][];
            Header[1] = new byte[2][];
            Header[2] = new byte[3][];


            byte[][][] Images = new byte[10][][];
            Images[0] = new byte[2][];
            Images[0][0] = new byte[] { 10, 20, 30 };
            Images[0][1] = new byte[] { 40, 50, 60 };


            byte[][][] Masks = new byte[10][][];
            Masks[0] = new byte[2][];
            Masks[0][0] = new byte[] { 100, 110, 120 };
            Masks[0][1] = new byte[] { 130, 140, 150 };



            string path = "C:\\Users\\axiong\\Desktop\\testwriteCMG";
            string filename = "testwriteCMG";

            CMGWriter.WriteToFile(Header, Images, Masks, path, filename);



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

