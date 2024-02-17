using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CMGWriter
{
    public void WriteCMG(string[][] Header, CMGCell[] cells, string path, string filename)
    {
        string cmgPath = Path.Combine(path, filename + " .cmg");

        using (BinaryWriter cmgFile = new BinaryWriter(File.Open(cmgPath, FileMode.Create)))
        {
            foreach (var cell in cells)
            {
                WriteCellData(cmgFile, cell, Header);
            }
        }
    }

    private void WriteCellData(BinaryWriter writer, CMGCell cell, string[][] Header)
    {
        int H = (int)cell.Height;
        int W = (int)cell.Width;
        int numImage = cell.Images.Length;
        int numMask = cell.Masks.Length;

        // Write header data
        writer.Write('c');
        writer.Write(cell.Mode);
        writer.Write((byte)1); // assuming there is always one color map
        writer.Write(cell.Class);
        writer.Write(cell.Screenx);
        writer.Write(cell.Screeny);
        writer.Write(cell.Stagex);
        writer.Write(cell.Stagey);
        writer.Write(cell.Stagez);
        writer.Write(cell.Resolution);
        writer.Write(cell.LowThreshold);
        writer.Write(cell.MidThreshold);
        writer.Write(cell.Group);
        writer.Write(W);
        writer.Write(H);
        writer.Write(cell.Accession);
        writer.Write(cell.Iod);
        writer.Write(cell.Fluor);
        writer.Write(cell.Diagnosis);
        writer.Write(cell.RedFaction);
        writer.Write(cell.GreenFaction);   
        writer.Write(cell.BlueFaction);
        writer.Write(cell.Index);
        writer.Write(cell.Objective);
        writer.Write(cell.Calibrated);
        writer.Write(cell.StackXInt);
        writer.Write(cell.StackYInt);
        writer.Write((byte)1); // assuming there is always one bitmap
        writer.Write(cell.CassettePosition);
        writer.Write(cell.Vorx);
        writer.Write(cell.Vory);
        writer.Write(cell.BestFocusFrame);
        writer.Write(cell.BackgroundFloat);
        writer.Write(cell.PrimaryColourChannel);
        writer.Write(cell.Layer);
        writer.Write(cell.Points);
        writer.Write(cell.NumFeature);
        writer.Write(cell.RGBOrder);
        writer.Write('$');

        // write image data
        foreach (var image in cell.Images)
        {
            foreach (var pixel in image)
            {
                writer.Write(pixel);
            }
        }

        // write mask data
        foreach (var mask in cell.Masks)
        {
            foreach (var pixel in mask)
            {
                writer.Write(pixel);
            }
        }
    }
}
