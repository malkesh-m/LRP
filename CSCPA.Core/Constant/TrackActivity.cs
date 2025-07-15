using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCPA.Core
{
    public enum RateType
    {
        FixedPrice = 1,
        HourlyRate = 2,
        NotPaid = 3
    }

    public enum WorkActivity
    {
        Work = 1,
        Break = 2
    }

    public enum TrackActivity
    {
        Untracked = 0,
        Work = 1,
        Break = 2,
        Away = 3
    }
}
