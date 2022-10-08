using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    public sealed class RowStatusValues
    {
        public const byte RowStatusActive = 1;
        public const byte RowStatusPassive = 2;
        public const byte RowStatusBanned = 3;
        public const byte RowStatusDeleted = 4;
    }
}
