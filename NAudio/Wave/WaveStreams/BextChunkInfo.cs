using System;

// Source: http://markheath.net/post/naudio-rf64-bwf
namespace NAudio.Wave.WaveStreams
{
    // https://tech.ebu.ch/docs/tech/tech3285.pdf
    public class BextChunkInfo
    {
        public BextChunkInfo()
        {
            Reserved = new byte[190];
        }

        public string Description { get; set; } // max 256 chars
        public string Originator { get; set; } // max 32 chars
        public string OriginatorReference { get; set; } // max 32 chars
        public DateTime OriginationDateTime { get; set; }
        public string OriginationDate { get { return OriginationDateTime.ToString("yyyy-MM-dd"); } }
        public string OriginationTime { get { return OriginationDateTime.ToString("HH:mm:ss"); } }
        public long TimeReference { get; set; } // first sample count since midnight
        public ushort Version { get { return 1; } } // version 2 has loudness stuff which we don't know so using version 1
        public string UniqueMaterialIdentifier { get; set; } // 64 bytes http://en.wikipedia.org/wiki/UMID
        public byte[] Reserved { get; private set; } // for version 2 = 180 bytes (10 before are loudness values), using version 1 = 190 bytes
        public string CodingHistory { get; set; } // arbitrary length string at end of structure
        // http://www.ebu.ch/CMSimages/fr/tec_text_r98-1999_tcm7-4709.pdf
        //A=PCM,F=48000,W=16,M=stereo,T=original,CR/LF
    }
}
