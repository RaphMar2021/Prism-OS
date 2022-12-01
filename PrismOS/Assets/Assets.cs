﻿using Cosmos.System.Audio.IO;
using IL2CPU.API.Attribs;

namespace PrismOS
{
    public static class Assets
    {
        // Include The Files At Compile Time
        public const string Base = "PrismOS.Assets.";
        [ManifestResourceStream(ResourceName = Base + "Vista.wav")] public readonly static byte[] VistaB;
        [ManifestResourceStream(ResourceName = Base + "Test.elf")] public readonly static byte[] ELF;

        // System Sounds
        public static MemoryAudioStream Vista = MemoryAudioStream.FromWave(VistaB);
    }
}