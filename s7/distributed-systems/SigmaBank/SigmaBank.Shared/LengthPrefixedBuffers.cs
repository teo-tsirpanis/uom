using System.Buffers.Binary;

namespace Dai19090.DistributedSystems.SigmaBank;

/// <summary>
/// Functions to read and write length-prefixed byte buffers.
/// </summary>
/// <remarks>The length is stored as a little-endian 32-bit integer.</remarks>
internal static class LengthPrefixedBuffers
{
    /// <summary>
    /// Reads a length-prefixed byte buffer from a <see cref="Stream"/>.
    /// </summary>
    /// <param name="stream">The stream from which to read.</param>
    /// <param name="cancellationToken">Used to cancel the operation.</param>
    /// <param name="maxLength">The maximum allowed length of the buffer.
    /// Used to combat memory exhaustion attacks and defaults to 2^20 bytes (1M).</param>
    /// <exception cref="InvalidOperationException">The incoming buffer's
    /// length exceeded <paramref name="maxLength"/>.</exception>
    public static async Task<Memory<byte>> ReadLengthPrefixedAsync(this Stream stream, CancellationToken cancellationToken, int maxLength = 1 << 20)
    {
        var lengthBuffer = new byte[sizeof(int)];
        await stream.ReadAsync(lengthBuffer, cancellationToken);

        var length = BinaryPrimitives.ReadUInt32LittleEndian(lengthBuffer);
        if (length > maxLength)
            throw new InvalidOperationException($"Message cannot exceed maximum length of {maxLength}, was {length}");

        var buffer = new byte[length].AsMemory();
        // The actual message might have been smaller.
        var actualLength = await stream.ReadAsync(buffer, cancellationToken);
        return buffer.Slice(0, actualLength);
    }

    public static async Task WriteLengthPrefixedAsync(this Stream stream, ReadOnlyMemory<byte> buffer, CancellationToken cancellationToken)
    {
        var lengthBuffer = new byte[sizeof(int)];
        BinaryPrimitives.WriteUInt32LittleEndian(lengthBuffer, (uint) buffer.Length);

        await stream.WriteAsync(lengthBuffer, cancellationToken);
        await stream.WriteAsync(buffer, cancellationToken);
    }
}
