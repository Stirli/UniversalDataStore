namespace UniversalDataStore
{
    public class CircleCursor
    {
        public int Value { get; private set; }
        public int MaxValue { get; private set; }
        public CircleCursor(int maxValue, int value = 0)
        {
            MaxValue = maxValue;
            Value = value;
        }

        public static implicit operator int(CircleCursor cursor)
        {
            return cursor.Value;
        }

        public static CircleCursor operator ++(CircleCursor cursor)
        {
            cursor.Value = Mod(cursor.Value+1, cursor.MaxValue);
            return cursor;
        }

        public static CircleCursor operator --(CircleCursor cursor)
        {
            cursor.Value = Mod(cursor.Value-1, cursor.MaxValue);
            return cursor;
        }

        public static bool operator ==(CircleCursor c1, CircleCursor c2) => c1.Equals(c2);
        public static bool operator !=(CircleCursor c1, CircleCursor c2) => !c1.Equals(c2);

        public bool Equals(CircleCursor cursor)
        {
            return this.Value == cursor.Value;
        }

        public override bool Equals(object obj)
        {
            return obj != null && obj is CircleCursor cursor && Equals(cursor);
        }

        private static int Mod(int k, int n)
        {
            return (k %= n) < 0 ? k + n : k;
        }
    }
}
