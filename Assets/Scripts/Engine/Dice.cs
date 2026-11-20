namespace WhosAboard.Engine
{
    // RNG mulberry32 — phải ra đúng từng số như src/engine/dice.ts (cùng seed -> cùng ván).
    public static class Dice
    {
        public static double Random(ref int seed)
        {
            seed = unchecked(seed + 0x6d2b79f5);
            int t = unchecked((int)((uint)(seed ^ (int)((uint)seed >> 15)) * (uint)(1 | seed)));
            t = unchecked((t + (int)((uint)(t ^ (int)((uint)t >> 7)) * (uint)(61 | t))) ^ t);
            return (uint)(t ^ (int)((uint)t >> 14)) / 4294967296.0;
        }

        public static int RollDie(ref int seed, int sides) => (int)System.Math.Floor(Random(ref seed) * sides) + 1;

        public static int AttackDamage(int d6, int d4) => System.Math.Abs(d6 - d4);
    }
}
