﻿using PE_Explorer.Core.PE;
using PE_Explorer.Core.PE.Headers;

namespace PE_Explorer.Core.Utils
{
    public static class Utils
    {
        public static uint RVAToFileOffset(PortableExecutable pe,uint rva)
        {
            if (rva <= 0)
                return 0;

            SectionHeader section;
            for(int i = 0; i < pe.sections.Count; i++)
            {
                section = pe.sections[i];
                if (rva >= section.VirtualAddress && rva < section.VirtualAddress + section.VirtualSize )
                {
                    return section.PointerToRawData + (rva - section.VirtualAddress);
                }
            }

            return 0;
        }
    }
}