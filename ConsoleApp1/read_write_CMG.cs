using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

class Reader
{
    public static (byte[][][], byte[][][], object[]) ReadFromFile(string cmgpath)
    {
        using (FileStream cmgfile = new FileStream(cmgpath, FileMode.Open, FileAccess.Read))
        {
            byte[] cmgdata = new byte[cmgfile.Length];
            cmgfile.Read(cmgdata, 0, cmgdata.Length);

            int btotal = cmgdata.Length;
            int bcurrent = 0;
            int icount = 0;

            while (btotal > bcurrent)
            {
                byte NBColorMap = cmgdata[bcurrent + 2];
                byte NBBitMap = cmgdata[bcurrent + 96];
                int width = BitConverter.ToInt32(cmgdata, bcurrent + 48);
                int height = BitConverter.ToInt32(cmgdata, bcurrent + 52);
                int imagesize = width * height;

                int metapadding = 0;
                bool isMeta = true;
                while (isMeta)
                {
                    if (cmgdata[bcurrent + 127 + metapadding] != '$')//36)
                    {
                        //metapadding = metapadding + 1;
                        metapadding++;

                    }
                    else
                    {
                        isMeta = false;
                    }
                }
                // error handling instead of while loop here

                bcurrent = bcurrent + 128 + metapadding;
                bcurrent = bcurrent + imagesize * NBColorMap;
                bcurrent = bcurrent + imagesize * NBBitMap;
                icount = icount + 1;

            }

            int ctotal = icount;

            byte[][][] Images = new byte[ctotal][][];
            byte[][][] Masks = new byte[ctotal][][];

            byte[] Mode = new byte[ctotal];
            byte[] NbColorMap = new byte[ctotal];
            uint[] Class = new uint[ctotal];
            uint[] Screenx = new uint[ctotal];
            uint[] Screeny = new uint[ctotal];
            ulong[] Stagex = new ulong[ctotal];
            ulong[] Stagey = new ulong[ctotal];
            ulong[] Stagez = new ulong[ctotal];
            float[] Resolution = new float[ctotal];
            ushort[] LowThreshold = new ushort[ctotal];
            ushort[] MidThreshold = new ushort[ctotal];
            byte[] Group = new byte[ctotal];
            uint[] Width = new uint[ctotal];
            uint[] Height = new uint[ctotal];
            uint[] Accession = new uint[ctotal];
            float[] Iod = new float[ctotal];
            byte[] Fluor = new byte[ctotal];
            ushort[] Diagnosis = new ushort[ctotal];
            float[] RedFaction = new float[ctotal];
            float[] GreenFaction = new float[ctotal];
            float[] BlueFaction = new float[ctotal];
            uint[] Index = new uint[ctotal];
            uint[] Objective = new uint[ctotal];
            byte[] Calibrated = new byte[ctotal];
            uint[] StackX_int = new uint[ctotal];
            uint[] StackY_int = new uint[ctotal];
            byte[] NbBitMap = new byte[ctotal];
            byte[] CassettePosition = new byte[ctotal];
            uint[] vorx = new uint[ctotal];
            uint[] vory = new uint[ctotal];
            byte[] BestFocusFrame = new byte[ctotal];
            float[] BackgroundFloat = new float[ctotal];
            byte[] PrimaryColourChannel = new byte[ctotal];
            byte[,] Layer = new byte[ctotal, 2];
            byte[,] Points = new byte[ctotal, 9];
            byte[] NumFeature = new byte[ctotal];
            byte[,] RGB_Order = new byte[ctotal, 3];

            bcurrent = 0;
            icount = 0;


            for (int n = 0; n < ctotal; n++)
            {
                //----------------------------Parse Header Data---------------------------------
                Mode[icount] = cmgdata[bcurrent + 1];
                NbColorMap[icount] = cmgdata[bcurrent + 2];
                Class[icount] = BitConverter.ToUInt32(cmgdata, bcurrent + 3);
                Screenx[icount] = BitConverter.ToUInt32(cmgdata, bcurrent + 7);
                Screeny[icount] = BitConverter.ToUInt32(cmgdata, bcurrent + 11);
                Stagex[icount] = BitConverter.ToUInt64(cmgdata, bcurrent + 15);
                Stagey[icount] = BitConverter.ToUInt64(cmgdata, bcurrent + 23);
                Stagez[icount] = BitConverter.ToUInt64(cmgdata, bcurrent + 31);
                Resolution[icount] = BitConverter.ToSingle(cmgdata, bcurrent + 39);
                LowThreshold[icount] = BitConverter.ToUInt16(cmgdata, bcurrent + 43);
                MidThreshold[icount] = BitConverter.ToUInt16(cmgdata, bcurrent + 45);
                Group[icount] = cmgdata[bcurrent + 47];
                Width[icount] = BitConverter.ToUInt32(cmgdata, bcurrent + 48);
                Height[icount] = BitConverter.ToUInt32(cmgdata, bcurrent + 52);
                Accession[icount] = BitConverter.ToUInt32(cmgdata, bcurrent + 56);


                //byte[] iodBytes = new byte[4];
                //Array.Copy(cmgdata, bcurrent + 60, iodBytes, 0, 4);
                //Array.Reverse(iodBytes);

                Iod[icount] = BitConverter.ToSingle(cmgdata, bcurrent + 60);


                Fluor[icount] = cmgdata[bcurrent + 64];
                Diagnosis[icount] = BitConverter.ToUInt16(cmgdata, bcurrent + 65);
                RedFaction[icount] = BitConverter.ToSingle(cmgdata, bcurrent + 67);
                GreenFaction[icount] = BitConverter.ToSingle(cmgdata, bcurrent + 71);
                BlueFaction[icount] = BitConverter.ToSingle(cmgdata, bcurrent + 75);
                Index[icount] = BitConverter.ToUInt32(cmgdata, bcurrent + 79);
                Objective[icount] = BitConverter.ToUInt32(cmgdata, bcurrent + 83);
                Calibrated[icount] = cmgdata[bcurrent + 87];
                StackX_int[icount] = BitConverter.ToUInt32(cmgdata, bcurrent + 88);
                StackY_int[icount] = BitConverter.ToUInt32(cmgdata, bcurrent + 92);
                NbBitMap[icount] = cmgdata[bcurrent + 96];
                CassettePosition[icount] = cmgdata[bcurrent + 97];
                vorx[icount] = BitConverter.ToUInt32(cmgdata, bcurrent + 98);
                vory[icount] = BitConverter.ToUInt32(cmgdata, bcurrent + 102);
                BestFocusFrame[icount] = cmgdata[bcurrent + 106];
                BackgroundFloat[icount] = BitConverter.ToSingle(cmgdata, bcurrent + 107);
                PrimaryColourChannel[icount] = cmgdata[bcurrent + 111];
                for (int i = 0; i < 2; i++)
                {
                    Layer[icount, i] = cmgdata[bcurrent + 112 + i];
                }
                for (int i = 0; i < 9; i++)
                {
                    Points[icount, i] = cmgdata[bcurrent + 114 + i];
                }
                NumFeature[icount] = cmgdata[bcurrent + 123];
                for (int i = 0; i < 3; i++)
                {
                    RGB_Order[icount, i] = cmgdata[bcurrent + 124 + i];
                }

                int imagesize = (int)(Width[icount] * Height[icount]);

                int metapadding = 0;
                bool isMeta = true;
                while (isMeta)
                {
                    if (cmgdata[bcurrent + 127 + metapadding] != 36)
                    {
                        metapadding = metapadding + 1;
                    }
                    else
                    {
                        isMeta = false;
                    }
                }

                bcurrent = bcurrent + 128 + metapadding;
                //------------------------------------------------------------------------------

                //----------------------------Parse Image Data-----------------------------------
                byte[][] frames = new byte[Height[icount]][];

                for (int i = 0; i < NbColorMap[icount]; i++)
                {
                    byte[] bytevector = new byte[imagesize];
                    Array.Copy(cmgdata, bcurrent + imagesize * i, bytevector, 0, imagesize);

                    frames[i] = bytevector.ToArray();
                }

                Images[icount] = frames;

                bcurrent = bcurrent + imagesize * NbColorMap[icount];
                //------------------------------------------------------------------------------

                //----------------------------Parse Mask Data-------------------------------------
                frames = new byte[Height[icount]][];

                for (int i = 0; i < NbBitMap[icount]; i++)
                {
                    byte[] bytevector = new byte[imagesize];
                    Array.Copy(cmgdata, bcurrent + imagesize * i, bytevector, 0, imagesize);

                    frames[i] = bytevector.ToArray();
                }

                Masks[icount] = frames;

                bcurrent = bcurrent + imagesize * NbBitMap[icount];
                //------------------------------------------------------------------------------

                icount = icount + 1;
            }

            object[] Header = new object[]
            {
                Mode, NbColorMap, Class, Screenx, Screeny, Stagex, Stagey, Stagez, Resolution,
                LowThreshold, MidThreshold, Group, Width, Height, Accession, Iod, Fluor, Diagnosis,
                RedFaction, GreenFaction, BlueFaction, Index, Objective, Calibrated, StackX_int,
                StackY_int, NbBitMap, CassettePosition, vorx, vory, BestFocusFrame, BackgroundFloat,
                PrimaryColourChannel, Layer, Points, NumFeature, RGB_Order
            };
            return (Images, Masks, Header);
        }
    }

}


public class Writer
{
    public void WriteCMG(string[][] Header, byte[][][] Images, byte[][][] Masks, string path, string filename)
    {
        int numRuns = Images.Length;

        string slash = Path.DirectorySeparatorChar.ToString();
        string cmgpath = Path.Combine(path, filename + ".cmg");

        using (BinaryWriter cmgfile = new BinaryWriter(File.Open(cmgpath, FileMode.Create)))
        {
            for (int n = 0; n < numRuns; n++)
            {
                Images[n] = new byte[128][];
                Masks[n] = new byte[20][];


                int H = Images[n].Length;
                int W = Images[n].Length; // Assuming Images[n][0] is not null
                int numImage = Images[n].Length;
                int numMask = Masks[n].Length;

                // Write Header Data
                cmgfile.Write('c');
                cmgfile.Write(Header[0][n]); // Mode
                cmgfile.Write((byte)numImage); // NBColorMap
                cmgfile.Write(Header[2][n]); // Class
                cmgfile.Write(Header[3][n]); // Screenx
                cmgfile.Write(Header[4][n]); // Screeny
                cmgfile.Write(Header[5][n]); // Stagex
                cmgfile.Write(Header[6][n]); // Stagey
                cmgfile.Write(Header[7][n]); // Stagez

                //cmgfile.Write(BitConverter.GetBytes(Header[8][n])); // Resolution
                byte[] resolution = Encoding.ASCII.GetBytes(Header[8][n]);
                cmgfile.Write(resolution);

                cmgfile.Write(Header[9][n]); // LowThreshold
                cmgfile.Write(Header[10][n]); // MidThreshold
                cmgfile.Write(Header[11][n]); // Group
                cmgfile.Write(BitConverter.GetBytes(W)); // Width
                cmgfile.Write(BitConverter.GetBytes(H)); // Height
                cmgfile.Write(Header[14][n]); // Accession

                //cmgfile.Write(BitConverter.GetBytes(Header[15][n])); // Iod
                byte[] iod = Encoding.ASCII.GetBytes(Header[15][n]);
                cmgfile.Write(iod);

                cmgfile.Write(Header[16][n]); // Fluor
                cmgfile.Write(Header[17][n]); // Diagnosis

                //cmgfile.Write(BitConverter.GetBytes(Header[18][n])); // RedFraction
                byte[] redfraction = Encoding.ASCII.GetBytes(Header[18][n]);
                cmgfile.Write(redfraction);

                //cmgfile.Write(BitConverter.GetBytes(Header[19][n])); // GreenFraction
                byte[] greenfraction = Encoding.ASCII.GetBytes(Header[19][n]);
                cmgfile.Write(greenfraction);

                //cmgfile.Write(BitConverter.GetBytes(Header[20][n])); // BlueFraction
                byte[] bluefraction = Encoding.ASCII.GetBytes(Header[20][n]);
                cmgfile.Write(bluefraction);

                cmgfile.Write(Header[21][n]); // Index
                cmgfile.Write(Header[22][n]); // Objective
                cmgfile.Write(Header[23][n]); // Calibrated
                cmgfile.Write(Header[24][n]); // StackX_int
                cmgfile.Write(Header[25][n]); // StackY_int
                cmgfile.Write((byte)numMask); // NbBitMap
                cmgfile.Write(Header[27][n]); // CassettePosition
                cmgfile.Write(Header[28][n]); // vorx
                cmgfile.Write(Header[29][n]); // vory
                cmgfile.Write(Header[30][n]); // BestFocusFrame

                //cmgfile.Write(BitConverter.GetBytes(Header[31][n])); // BackgroundFloat
                byte[] backgroundfloat = Encoding.ASCII.GetBytes(Header[31][n]);
                cmgfile.Write(backgroundfloat);

                cmgfile.Write(Header[32][n]); // PrimaryColorChannel
                cmgfile.Write(Header[33][n][0]); // Layer
                cmgfile.Write(Header[33][n][1]); // Layers
                cmgfile.Write(Header[34][n][0]); // Points
                cmgfile.Write(Header[34][n][1]); // Points
                cmgfile.Write(Header[34][n][2]); // Points
                cmgfile.Write(Header[34][n][3]); // Points
                cmgfile.Write(Header[34][n][4]); // Points
                cmgfile.Write(Header[34][n][5]); // Points
                cmgfile.Write("testing");
                cmgfile.Write(Header[34][n][6]); // Points
                cmgfile.Write(Header[34][n][7]); // Points
                cmgfile.Write(Header[34][n][8]); // Points
                cmgfile.Write(Header[35][n]); // NumFeatures
                cmgfile.Write(Header[36][n][0]); // RGB_Order
                cmgfile.Write(Header[36][n][1]); // RGB_Order
                cmgfile.Write(Header[36][n][2]); // RGB_Order
                cmgfile.Write('$');

                // Write Image Data
                if (Images[n][0] != null) // Check if Images[n][0] is not null
                {
                    for (int z = 0; z < numImage; z++)
                    {
                        for (int y = 0; y < H; y++)
                        {
                            cmgfile.Write(Images[n][y][z]);
                        }
                    }
                }

                // Write Mask Data
                if (Masks[n][0] != null) // Check if Masks[n][0] is not null
                {
                    for (int z = 0; z < numMask; z++)
                    {
                        for (int y = 0; y < H; y++)
                        {
                            cmgfile.Write(Masks[n][y][z]);
                        }
                    }
                }
            }
        }
    }


    static void WriteCMGList(byte[][][] Header, byte[,,] Images, byte[,,] Masks, string path, string filename)
    {
        int numRuns = Images.GetLength(0);
        int numImage = 0;
        int numMask = 0;

        char slash = '/';
        string cmgPath = path + slash + filename + ".cmg";

        using (FileStream cmgfile = new FileStream(cmgPath, FileMode.Create, FileAccess.Write))
        using (BinaryWriter writer = new BinaryWriter(cmgfile))
        {
            for (int n = 0; n < numRuns; n++)
            {
                int H = Images.GetLength(1);
                int W = Images.GetLength(2);
                int ImagesLen = Images.GetLength(0);
                int MasksLen = Masks.GetLength(0);

                byte[,] I_RGB = new byte[H, W];
                byte[,] I_Bitmap = new byte[H, W];

                if (ImagesLen == 2)
                {
                    numImage = 1;
                    for (int i = 0; i < H; i++)
                    {
                        I_RGB[i, 0] = Images[n, i, 0];
                    }
                }
                else
                {
                    numImage = Images.GetLength(2);
                    for (int i = 0; i < H; i++)
                    {
                        for (int z = 0; z < numImage; z++)
                        {
                            I_RGB[i, z] = Images[n, i, z];
                        }
                    }
                }

                if (MasksLen == 2)
                {
                    numMask = 1;
                    for (int i = 0; i < H; i++)
                    {
                        I_RGB[i, 0] = Images[n, i, 0];
                    }
                }
                else
                {
                    numMask = Masks.GetLength(2);
                    for (int i = 0; i < H; i++)
                    {
                        for (int z = 0; z < numMask; z++)
                        {
                            I_RGB[i, z] = Masks[n, i, z];
                        }
                    }
                }
                writer.Write((byte)'c');
                writer.Write(Header[0][n]);
                writer.Write((byte)1);
                writer.Write(Header[2][n]);
                writer.Write(Header[3][n]);
                writer.Write(Header[4][n]);
                writer.Write(Header[5][n]);
                writer.Write(Header[6][n]);
                writer.Write(Header[7][n]);
                writer.Write(Header[8][n]);
                writer.Write(Header[9][n]);
                writer.Write(Header[10][n]);
                writer.Write(Header[11][n]);
                writer.Write((uint)W);
                writer.Write((uint)H);
                writer.Write(Header[14][n]);
                writer.Write(Header[15][n]);
                writer.Write(Header[16][n]);
                writer.Write(Header[17][n]);
                writer.Write(Header[18][n]);
                writer.Write(Header[19][n]);
                writer.Write(Header[20][n]);
                writer.Write(Header[21][n]);
                writer.Write(Header[22][n]);
                writer.Write(Header[23][n]);
                writer.Write(Header[24][n]);
                writer.Write(Header[25][n]);
                writer.Write((byte)1);
                writer.Write(Header[27][n]);
                writer.Write(Header[28][n]);
                writer.Write(Header[29][n]);
                writer.Write(Header[30][n]);
                writer.Write(Header[31][n]);
                writer.Write(Header[32][n]);
                writer.Write(Header[33][n][0]);
                writer.Write(Header[33][n][1]);
                writer.Write(Header[34][n][0]);
                writer.Write(Header[34][n][1]);
                writer.Write(Header[34][n][2]);
                writer.Write(Header[34][n][3]);
                writer.Write(Header[34][n][4]);
                writer.Write(Header[34][n][5]);
                writer.Write(Header[34][n][6]);
                writer.Write(Header[35][n]);
                writer.Write(Header[36][n][0]);
                writer.Write(Header[36][n][1]);
                writer.Write(Header[36][n][2]);
                writer.Write((byte)'$');

                for (int z = 0; z < numImage; z++)
                {
                    for (int y = 0; y < H; y++)
                    {
                        writer.Write(I_RGB[y, z]);
                    }
                }

                for (int z = 0; z < numMask; z++)
                {
                    for (int y = 0; y < H; y++)
                    {
                        writer.Write(I_Bitmap[y, z]);

                    }
                }
            }
        }
    }
}




