namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // reading from file

            string path = @"C:\Users\axiong\Desktop\testwriteCMG\testCmg100.cmg";
            CMGCell[] cells = CMGReader.ReadFromFile(path);
            Console.WriteLine(cells.Length);

            if (cells != null && cells.Length > 0)
            {
                int cellNumber = 1;
                // Display information or perform operations with CMGCell objects
                foreach (CMGCell cell in cells)
                {
                    Console.WriteLine($"CMG Cell {cellNumber} Features:");
                    Console.WriteLine($"Mode: {cell.Mode}");
                    Console.WriteLine($"NB Color Map: {cell.NbColorMap}");
                    Console.WriteLine($"Class: {cell.Class}");
                    Console.WriteLine($"ScreenX: {cell.Screenx}");
                    Console.WriteLine($"ScreenY: {cell.Screeny}");
                    Console.WriteLine($"StageX: {cell.Stagex}");
                    Console.WriteLine($"StageY: {cell.Stagey}");
                    Console.WriteLine($"StageZ: {cell.Stagez}");
                    Console.WriteLine($"Resolution: {cell.Resolution}");
                    Console.WriteLine($"LowThreshold: {cell.LowThreshold}");
                    Console.WriteLine($"MidThreshold: {cell.MidThreshold}");
                    Console.WriteLine($"Group: {cell.Group}");
                    Console.WriteLine($"Width: {cell.Width}");
                    Console.WriteLine($"Height: {cell.Height}");
                    Console.WriteLine($"Accession: {cell.Accession}");
                    Console.WriteLine($"Iod: {cell.Iod}");
                    Console.WriteLine($"Fluor: {cell.Fluor}");
                    Console.WriteLine($"Diagnosis: {cell.Diagnosis}");
                    Console.WriteLine($"RedFaction: {cell.RedFaction}");
                    Console.WriteLine($"GreenFaction: {cell.GreenFaction}");
                    Console.WriteLine($"BlueFaction: {cell.BlueFaction}");
                    Console.WriteLine($"Index: {cell.Index}");
                    Console.WriteLine($"Objective: {cell.Objective}");
                    Console.WriteLine($"Calibrated: {cell.Calibrated}");
                    Console.WriteLine($"StackXInt: {cell.StackXInt}");
                    Console.WriteLine($"StackYInt: {cell.StackYInt}");
                    Console.WriteLine($"NbBitMap: {cell.NbBitMap}");
                    Console.WriteLine($"CassettePosition: {cell.CassettePosition}");
                    Console.WriteLine($"VorX: {cell.Vorx}");
                    Console.WriteLine($"VorY: {cell.Vory}");
                    Console.WriteLine($"BestFocusFrame: {cell.BestFocusFrame}");
                    Console.WriteLine($"BackgroundFloat: {cell.BackgroundFloat}");
                    Console.WriteLine($"PrimaryColourChannel: {cell.PrimaryColourChannel}");
                    Console.WriteLine($"Layer: {cell.Layer}");
                    Console.WriteLine($"Points: {cell.Points}");
                    Console.WriteLine($"NumFeature: {cell.NumFeature}");
                    Console.WriteLine($"RGBOrder: {cell.RGBOrder}");
                    Console.WriteLine();

                    cellNumber++;
                }
            }
            else
            {
                Console.WriteLine("Failed to read CMG file");
            }


            // writing to file

            string writePath = @"C:\Users\axiong\Desktop\testwriteCMG";
            CMGWriter cmgWriter = new CMGWriter();
            Console.WriteLine("Before writing to file");
            cmgWriter.WriteCMG(cells, writePath, "testwrite");
            Console.WriteLine("Written to file");

    }
}

