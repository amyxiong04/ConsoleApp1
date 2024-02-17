using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

public class CMGReader
{
    public static CMGCell[] ReadFromFile(string cmgPath)
    {
        try
        {
            byte[] cmgData = File.ReadAllBytes(cmgPath);

            int numCells = 0;
            int currentIndex = 0;

            // count the number of cells in the CMG file
            while (currentIndex < cmgData.Length)
            {
                byte cellColorMap = cmgData[currentIndex + 2];
                byte cellBitMap = cmgData[currentIndex + 96];
                int width = BitConverter.ToInt32(cmgData, currentIndex + 48);
                int height = BitConverter.ToInt32(cmgData, currentIndex + 52);
                int imageSize = width * height;

                int metapadding = 0;
                bool isMeta = true;
                while (isMeta)
                {
                    if (cmgData[currentIndex + 127 + metapadding] != 36)
                    {
                        metapadding++;
                    }
                    else
                    {
                        isMeta = false;
                    }
                }

                currentIndex += 128 + metapadding + imageSize * cellColorMap + imageSize * cellBitMap;
                numCells++;
            }

            // create an array to store CMGCell objects
            CMGCell[] cells = new CMGCell[numCells];
            currentIndex = 0;

            // populate CMGCell objects
            for (int i = 0; i < numCells; i++)
            {
                cells[i] = ReadCellData(cmgData, ref currentIndex);
            }
            return cells;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error reading CMG file");
            return null;
        }
    }


    private static CMGCell ReadCellData(byte[] cmgData, ref int currentIndex)
    {
        CMGCell cell = new CMGCell();

        // read header data
        cell.Mode = cmgData[currentIndex + 1];
        cell.NbColorMap = cmgData[currentIndex + 2];
        cell.Class = BitConverter.ToUInt32(cmgData, currentIndex + 3);
        cell.Screenx = BitConverter.ToUInt32(cmgData, currentIndex + 7);
        cell.Screeny = BitConverter.ToUInt32(cmgData, currentIndex + 11);
        cell.Stagex = BitConverter.ToUInt64(cmgData, currentIndex + 15);
        cell.Stagey = BitConverter.ToUInt64(cmgData, currentIndex + 23);
        cell.Stagez = BitConverter.ToUInt64(cmgData, currentIndex + 31);
        cell.Resolution = BitConverter.ToUInt32(cmgData, currentIndex + 39);
        cell.LowThreshold = BitConverter.ToUInt16(cmgData, currentIndex + 43);
        cell.MidThreshold = BitConverter.ToUInt16(cmgData, currentIndex + 45);
        cell.Group = cmgData[currentIndex + 47];
        cell.Width = BitConverter.ToUInt32(cmgData, currentIndex + 48);
        cell.Height = BitConverter.ToUInt32(cmgData, currentIndex + 52);
        cell.Accession = BitConverter.ToUInt32(cmgData, currentIndex + 56);
        cell.Iod = BitConverter.ToSingle(cmgData, currentIndex + 60);
        cell.Fluor = cmgData[currentIndex + 64];
        cell.Diagnosis = BitConverter.ToUInt16(cmgData, currentIndex + 65);
        cell.RedFaction = BitConverter.ToSingle(cmgData, currentIndex + 67);
        cell.GreenFaction = BitConverter.ToSingle(cmgData, currentIndex + 71);
        cell.BlueFaction = BitConverter.ToSingle(cmgData, currentIndex + 75);
        cell.Index = BitConverter.ToUInt32(cmgData, currentIndex + 79);
        cell.Objective = BitConverter.ToUInt32(cmgData, currentIndex + 83);
        cell.Calibrated = cmgData[currentIndex + 87];
        cell.StackXInt = BitConverter.ToUInt32(cmgData, currentIndex + 88);
        cell.StackYInt = BitConverter.ToUInt32(cmgData, currentIndex + 92);
        cell.NbBitMap = cmgData[currentIndex + 96];
        cell.CassettePosition = cmgData[currentIndex + 97];
        cell.Vorx = BitConverter.ToUInt32(cmgData, currentIndex + 98);
        cell.Vory = BitConverter.ToUInt32(cmgData, currentIndex + 102);
        cell.BestFocusFrame = cmgData[currentIndex + 106];
        cell.BackgroundFloat = BitConverter.ToSingle(cmgData, currentIndex + 107);
        cell.PrimaryColourChannel = cmgData[currentIndex + 111];

        // read layer data
        cell.Layer = new byte[2];
        cell.Layer[0] = cmgData[currentIndex + 112];
        cell.Layer[1] = cmgData[currentIndex + 113];

        // read points data
        cell.Points = new byte[9];
        for (int i = 0; i < 9; i++)
        {
            cell.Points[i] = cmgData[currentIndex + 114 + i];
        }

        // read RGB order data
        cell.RGBOrder = new byte[3];
        for (int i = 0; i < 3; i++)
        {
            cell.RGBOrder[i] = cmgData[currentIndex + 124 + i];
        }

        int imageSize = (int)(cell.Width * cell.Height);

        int metaPadding = 0;
        bool isMeta = true;
        while (isMeta)
        {
            if (cmgData[currentIndex + 127 + metaPadding] != 36)
            {
                metaPadding++;
            }
            else
            {
                isMeta = false;
            }
        }

        currentIndex += 128 + metaPadding;

        // Read image data
        cell.Images = new byte[cell.NbColorMap][];
        for (int i = 0; i < cell.NbColorMap; i++)
        {
            cell.Images[i] = new byte[imageSize];
            Array.Copy(cmgData, currentIndex + imageSize * i, cell.Images[i], 0, imageSize);
        }

        currentIndex += imageSize * cell.NbColorMap;

        // Read mask data
        cell.Masks = new byte[cell.NbBitMap][];
        for (int i = 0; i < cell.NbBitMap; i++)
        {
            cell.Masks[i] = new byte[imageSize];
            Array.Copy(cmgData, currentIndex + imageSize * i, cell.Masks[i], 0, imageSize);
        }

        currentIndex += imageSize * cell.NbBitMap;

        return cell;
    }
}
