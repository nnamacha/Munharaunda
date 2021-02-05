using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munharaunda.Core.Constants
{
    public static class ReturnCodesConstant
    {
        //Response codes
        public const string R00 = "R00";
        public const string R01 = "R01";
        public const string R02 = "R02";
        public const string R03 = "R03";
        public const string R04 = "R04";
        public const string R05 = "R05";
        public const string R06 = "R06";
        public const string R07 = "R07";
        public const string R08 = "R08";

        //Unhandled exceptions/ System Error
        public const string R99 = "R99";

        //Response messages
        public const string R00Message = "Success";
        public const string R01Message = "Failure";
        public const string R02Message = "Validation error";
        public const string R03Message = "SMS message failed to save to NotifyMessage table";
        public const string R04Message = "Connection to database failed";
        public const string R05Message = "Database Error";
        public const string R06Message = "Record not found";
        public const string R07Message = "Record already exist";
        public const string R08Message = "Invalid request. ";

        //Error Message

        public const string CREATE_NEW_PAYMENT_FAILED = "Error was encountered when trying to create a new payment";
    }
}
