using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElmersAPIService
{
    public class Coffee : ICoffee
    {
        public CoffeeSettings ProcessCoffee(string settings)
        {
            try
            {
                //remove "0x"
                if (settings.StartsWith("0x"))
                {
                    settings = settings.Substring(2);
                }
                short number = Convert.ToInt16(settings, 16);
                byte[] result = BitConverter.GetBytes(number);
                BitArray bitArray = new BitArray(result);
                uint numberofcups = Bits2Int(result, 4, 8);
                CoffeeSettings coffeeSettings = new CoffeeSettings()
                {
                    machine_on = bitArray[0],
                    grinding_beans = bitArray[1],
                    empty_grounds_fault = bitArray[2],
                    water_empty_fault = bitArray[3],
                    number_of_cups_today = numberofcups,
                    descale_required = bitArray[14],
                    have_another_one_carl = CheckBit(bitArray, 13, 15)
                };
                return coffeeSettings;
            }
            catch
            {
                throw;
            }

        }

        private bool CheckBit(BitArray bitArray, int v1, int v2)
        {           
            if (bitArray.Count > v2 )
            {
                if (bitArray[v2])
                    return true;

                if (bitArray[v1])
                    return true;
            }
            return false;
        }

        public static byte[] GetPartOfByteArray(byte[] source, int offset, int length)
        {
            byte[] retBytes = new byte[length];
            Buffer.BlockCopy(source, offset, retBytes, 0, length);
            return retBytes;
        }
        public static uint Bits2Int(byte[] source, int offset, int length)
        {
            if (source.Length > 4)
            {
                source = GetPartOfByteArray(source, offset / 8, (source.Length - offset / 8 > 3 ? 4 : source.Length - offset / 8));
                offset -= 8 * (offset / 8);
            }
           
            byte[] intBytes = new byte[4];
            source.CopyTo(intBytes, 0);
            Int32 full = BitConverter.ToInt32(intBytes,0);
    
            Int32 mask = (1 << length) - 1;
            return (uint)((full >> offset) & mask);
        }
    }
}
