using System;

namespace AntaresUtilities
{
    public class RecipeGeometry : IComparable<RecipeGeometry>
    {
        public string RecipeId;
        public int LineId;
        public int ItemType;
        public int X;
        public int Y;
        public int Z;
        public int Total;

        public int CompareTo(RecipeGeometry other)
        {
            if (this.LineId > other.LineId) return 1;
            else if (this.LineId > other.LineId) return -1;

            if (this.ItemType > other.ItemType) return 1;
            else if (this.ItemType > other.ItemType) return -1;
            return 0;
        }
    }
}
