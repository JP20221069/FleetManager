using Common.Exceptions;
using Common.Localization;
using FleetManagerCommon.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Common.Localization
{
    public class ExceptionLocalization
    {
        Langset l;
        public ExceptionLocalization(Langset l)
        {
            this.l = l;
        }
        public string LocalizeException(object ex)
        {
            string ret = "";

            if(ex.GetType()==typeof(ActiveVehicleExistsException))
            {
               ret= l.GetString("EXC_AVE");
            }
            else if(ex.GetType() == typeof(ClientLimitException))
            {
                ret= l.GetString("EXC_CLE");
            }
            else if(ex.GetType() == typeof(RecordNotFoundException))
            {
                ret = l.GetString("EXC_RNF");
            }
            else if(ex.GetType() == typeof(UnableToCheckInException))
            {
                ret = l.GetString("EXC_UCI");
            }
            else if(ex.GetType() == typeof(UnableToDeleteException))
            {
                ret = l.GetString("EXC_UDE");
            }
            else if(ex.GetType() == typeof(UnableToDisconnectException))
            {
                ret = l.GetString("EXC_UDC");
            }
            else if(ex.GetType() == typeof(UpdateDeniedUserLoggedIn))
            {
                ret = l.GetString("EXC_UPD_DDUL");
            }
            else if(ex.GetType() == typeof(UserAlreadyExistsException))
            {
                ret = l.GetString("EXC_UAE");
            }
            else if(ex.GetType() == typeof(UserAlreadyLoggedInException))
            {
                ret = l.GetString("EXC_UAL");
            }
            else if(ex.GetType() == typeof(UserNotFoundException))
            {
                ret = l.GetString("EXC_UNF");
            }
            else
            {
                ret = ((Exception)ex).Message;
            }   
            return ret;
        }
    }
}
