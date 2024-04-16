using lzwCode.Buffers;

namespace lzwCode;

/// <summary>
/// Class that represents LZW-encoder.
/// </summary>
public static class LzwEncoder
{
    private const int StartMaximumAmountOfCodes = 512;

    private const int StartByteSize = 9;

    /// <summary>
    /// Encodes input array of bytes with LZW-algorithm.
    /// </summary>
    /// <param name="input">Input array of bytes.</param>
    /// <returns>Array of LZW-decoded bytes.</returns>
    public static byte[] Encode(byte[]? input)
    {
        if (input == null)
        {
            throw new ArgumentNullException(nameof(input));
        }

        if (input.Length == 0)
        {
            throw new ArgumentException("Input bytes stream can't be empty!");
        }

        var trie = new Trie();
        trie.InitTrie();
        CompressByteBuffer buffer = new();

        var stream = new List<byte>();

        var currentMaximumAmountOfCodes = StartMaximumAmountOfCodes;
        foreach (var t in input)
        {
            var elementToAdd = new List<byte>();

            elementToAdd.AddRange(stream);
            elementToAdd.Add(t);

            if (trie.Contains(elementToAdd))
            {
                stream = elementToAdd;
            }
            else
            {
                buffer.Add(trie.GetValueOfElement(stream));
                trie.Add(elementToAdd);

                if (trie.Size == currentMaximumAmountOfCodes)
                {
                    currentMaximumAmountOfCodes *= 2;
                    ++buffer.CurrentByteSize;
                }

                stream.Clear();
                stream.Add(t);
            }
        }

        buffer.Add(trie.GetValueOfElement(stream));

        if (buffer.CurrentLengthOfBufferedByte != 0)
        {
            buffer.PutBufferedByteInCompressedBytes();
        }

        return buffer.CompressedBytes.ToArray();
    }
}
