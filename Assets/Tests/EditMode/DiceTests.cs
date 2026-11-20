using NUnit.Framework;
using WhosAboard.Engine;

public class DiceTests
{
    // Số chuẩn lấy từ bản TS: createRng(seed) gọi 3 lần (src/engine/dice.ts)
    [TestCase(0, 0.26642920868471265, 0.0003297457005828619, 0.2232720274478197)]
    [TestCase(123, 0.7872516233474016, 0.1785435655619949, 0.49531551403924823)]
    [TestCase(-5, 0.48384718922898173, 0.05296749505214393, 0.9390332337934524)]
    [TestCase(2147483647, 0.4290980885270983, 0.12713524978607893, 0.3852774982806295)]
    public void MatchesTypeScript(int seed, double a, double b, double c)
    {
        Assert.AreEqual(a, Dice.Random(ref seed));
        Assert.AreEqual(b, Dice.Random(ref seed));
        Assert.AreEqual(c, Dice.Random(ref seed));
    }
}
