namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // reading
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


            // writing
            // Example usage
            string[][] Header = new string[37][]; // Example header data
            Header[0] = new string[] { "Mode1", "Value1", "Value2" };
            Header[2] = new string[] { "Mode1", "Value1", "Value2" };
            Header[3] = new string[] { "Mode1", "Value1", "Value2" };
            Header[4] = new string[] { "Mode1", "Value1", "Value2" };
            Header[5] = new string[] { "Mode1", "Value1", "Value2" };
            Header[6] = new string[] { "Mode1", "Value1", "Value2" };
            Header[7] = new string[] { "Mode1", "Value1", "Value2" };
            Header[8] = new string[] { "Mode1", "Value1", "Value2" };
            Header[9] = new string[] { "Mode1", "Value1", "Value2" };
            Header[10]= new string[] { "Mode1", "Value1", "Value2" };
            Header[11]= new string[] { "Mode1", "Value1", "Value2" };
            Header[12]= new string[] { "Mode1", "Value1", "Value2" };
            Header[13]= new string[] { "Mode1", "Value1", "Value2" };
            Header[14]= new string[] { "Mode1", "Value1", "Value2" };
            Header[15]= new string[] { "Mode1", "Value1", "Value2" };
            Header[16]= new string[] { "Mode1", "Value1", "Value2" };
            Header[17]= new string[] { "Mode1", "Value1", "Value2" };
            Header[18]= new string[] { "Mode1", "Value1", "Value2" };
            Header[19]= new string[] { "Mode1", "Value1", "Value2" };
            Header[20]= new string[] { "Mode1", "Value1", "Value2" };
            Header[21]= new string[] { "Mode1", "Value1", "Value2" };
            Header[22]= new string[] { "Mode1", "Value1", "Value2" };
            Header[23]= new string[] { "Mode1", "Value1", "Value2" };
            Header[24]= new string[] { "Mode1", "Value1", "Value2" };
            Header[25]= new string[] { "Mode1", "Value1", "Value2" };
            Header[27]= new string[] { "Mode1", "Value1", "Value2" };
            Header[28]= new string[] { "Mode1", "Value1", "Value2" };
            Header[29]= new string[] { "Mode1", "Value1", "Value2" };
            Header[30]= new string[] { "Mode1", "Value1", "Value2" };
            Header[31]= new string[] { "Mode1", "Value1", "Value2" };
            Header[32]= new string[] { "Mode1", "Value1", "Value2" };
            Header[33]= new string[] { "Mode1", "Value1", "Value2" };
            Header[33]= new string[] { "Mode1", "Value1", "Value2" };
            Header[34] = new string[] { "Mode1", "Value1", "Value2", "Value3", "Value4" };
            Header[34]= new string[] { "Mode1", "Value1", "Value2" };
            Header[34]= new string[] { "Mode1", "Value1", "Value2" };
            Header[34]= new string[] { "Mode1", "Value1", "Value2" };
            Header[34]= new string[] { "Mode1", "Value1", "Value2" };
            Header[34]= new string[] { "Mode1", "Value1", "Value2" };
            Header[34]= new string[] { "Mode1", "Value1", "Value2" };
            Header[34]= new string[] { "Mode1", "Value1", "Value2" };
            Header[34]= new string[] { "Mode1", "Value1", "Value2" };
            Header[35]= new string[] { "Mode1", "Value1", "Value2" };
            Header[36]= new string[] { "Mode1", "Value1", "Value2" };
            Header[36]= new string[] { "Mode1", "Value1", "Value2" };
            Header[36] = new string[] { "Mode1", "Value1", "Value2" };
















            byte[][][] Images = new byte[1][][]; // Example image data
            byte[][][] Masks = new byte[1][][]; // Example mask data
            string path = @"C:\Users\axiong\Desktop\testwriteCMG";
            string filename = "example";

            CMGWriter cmgWriter = new CMGWriter();
            cmgWriter.WriteCMG(Header, Images, Masks, path, filename);
        }
    }
}

