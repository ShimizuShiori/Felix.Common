using System.IO.Compression;

namespace Felix.Common
{
    /// <summary>
    /// WARNING WARNING WARNING - The format used is not actually the standard Zip (PKZIP) format. This is just Deflate with a two-byte 'PK' header.
    /// Do not try to unzip this data or replace it with a zip file. Things will fail, probably spectacularly.
    /// </summary>
    static class ZipCompressor
    {
        public static byte[] Decompress(byte[] filterData)
        {
            if (filterData is null)
            {
                throw new ArgumentNullException(nameof(filterData));
            }

            if (filterData.Length > 2 && filterData[0] == 'P' && filterData[1] == 'Z')
            {
                using var inputMemoryStream = new MemoryStream(filterData, 2, filterData.Length - 2);
                using var inflaterInputStream = new DeflateStream(inputMemoryStream, CompressionMode.Decompress);
                using var resultMemoryStream = new MemoryStream();
                inflaterInputStream.CopyTo(resultMemoryStream);

                var result = resultMemoryStream.ToArray();
                return result;
            }
            else
            {
                return filterData;
            }
        }

        public static byte[] Compress(byte[] filterData)
        {
            if (filterData is null)
            {
                throw new ArgumentNullException(nameof(filterData));
            }

            using var ms = new MemoryStream(filterData.Length);
            ms.Write(new byte[] { (byte)'P', (byte)'Z' }, 0, 2);
            using (var outputStream = new DeflateStream(ms, CompressionMode.Compress, leaveOpen: true))
            {
                outputStream.Write(filterData, 0, filterData.Length);
            }

            return ms.ToArray();
        }
    }
}
