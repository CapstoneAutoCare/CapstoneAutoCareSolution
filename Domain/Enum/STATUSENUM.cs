using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Enum
{
    public class STATUSENUM
    {

        public enum STATUSMI
        {
            WAITINGBYCAR,
            CHECKIN,
            REPAIRING,
            PAYMENT,
            DONE
        }

        public enum STATUSBOOKING
        {
            INACTIVE,
            ACCEPTED,
            CANCELLED
        }
    }
}
