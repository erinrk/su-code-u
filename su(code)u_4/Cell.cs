using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace su_code_u_4
{
    internal class Cell
    {
        public int value;          //1-9
        public readonly int col;   //0-8
        public readonly int row;   //0-8
        public readonly int box;   //1-9

        static readonly int[] forList = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        public List<int> possibleValues = new(forList);

        public Cell(int value, int row, int col, int box)
        {
            this.value = value;
            this.row = row;
            this.col = col;
            this.box = box;
        }
    }
}
