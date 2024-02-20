using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// class representing one CMG cell object
public class CMGCell
{
    // properties representing the header data
    public byte Mode { get; set; }
    public byte NbColorMap { get; set; }
    public uint Class { get; set; }
    public uint Screenx { get; set; }
    public uint Screeny { get; set; }
    public ulong Stagex { get; set; }
    public ulong Stagey { get; set; }
    public ulong Stagez { get; set; }
    public float Resolution { get; set; }
    public ushort LowThreshold { get; set; }
    public ushort MidThreshold { get; set; }
    public byte Group { get; set; }
    public uint Width { get; set; }
    public uint Height { get; set; }
    public uint Accession { get; set; }
    public float Iod { get; set; }
    public byte Fluor { get; set; }
    public ushort Diagnosis { get; set; }
    public float RedFaction { get; set; }
    public float GreenFaction { get; set; }
    public float BlueFaction { get; set; }
    public uint Index { get; set; }
    public uint Objective { get; set; }
    public byte Calibrated { get; set; }
    public uint StackXInt { get; set; }
    public uint StackYInt { get; set; }
    public byte NbBitMap { get; set; }
    public byte CassettePosition { get; set; }
    public uint Vorx { get; set; }
    public uint Vory { get; set; }
    public byte BestFocusFrame { get; set; }
    public float BackgroundFloat { get; set; }
    public byte PrimaryColourChannel { get; set; }
    public byte[] Layer { get; set; }
    public byte[] Points { get; set; }
    public byte NumFeature { get; set; }
    public byte[] RGBOrder { get; set; }


    // properties representing image and mask data
    public byte[][] Images { get; set; }
    public byte[][] Masks { get; set; }
}