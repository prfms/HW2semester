namespace lzwTest;
using NUnit.Framework;
using lzwCode;
public class LzwTests
{
    private static IEnumerable<TestCaseData> TestFiles()
    {
        yield return new TestCaseData("../../../testFiles/13-gui-text.pdf");
        yield return new TestCaseData("../../../testFiles/20240422_vacant.xlsx");
        yield return new TestCaseData("../../../testFiles/pic.jpg");
        yield return new TestCaseData("../../../testFiles/WINMINE.EXE");
    }

    [Test]
    public void EncoderWithEmptyInputArrayOfBytesShouldThrowException()
    {
        var input = Array.Empty<byte>();
        Assert.Throws<ArgumentException>(() => LzwEncoder.Encode(input));
    }

    [Test]
    public void EncoderWithNullInputArrayOfBytesShouldThrowException()
    {
        byte[]? input = null;
        Assert.Throws<ArgumentNullException>(() => LzwEncoder.Encode(input));
    }

    [Test]
    public void DecoderWithEmptyInputArrayOfBytesShouldThrowException()
    {
        var input = Array.Empty<byte>();
        Assert.Throws<ArgumentException>(() => LzwDecoder.Decode(input));
    }

    [Test]
    public void DecoderWithNullInputArrayOfBytesShouldThrowException()
    {
        byte[]? input = null;
        Assert.Throws<ArgumentNullException>(() => LzwDecoder.Decode(input));
    }

    [TestCaseSource(nameof(TestFiles))]
    public void EncoderAndDecoderWithRightInputShouldOutputOriginalFile(string pathToFile)
    {
        var input = File.ReadAllBytes(pathToFile);
        var encoderOutput = LzwEncoder.Encode(input);
        var decoderOutput = LzwDecoder.Decode(encoderOutput);

        Assert.That(input, Is.EqualTo(decoderOutput));
    }
}