using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonAPI
{
    public enum EFeedProcessingStatus
    {
        AwaitingAsynchronousReply = 1,
        Cancelled = 2,
        Done = 3,
        InProgress = 4,
        InSafetyNet = 5,
        Submitted = 6,
        Unconfirmed = 7
    }
}
