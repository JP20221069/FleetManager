using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagerCommon.Communication
{
    public enum Operation
    {
        Login,
        Disconnect,
        Logout,
        AddUser,
        AddVehicle,
        AlterVehicle,
        DeleteVehicle,
        SearchVehicle,
        GetAllVehicles,
        CheckinVehicle,
        CheckoutVehicle,
        GetCheckinsByUser,
        GetFreeVehicles,
        GetAllServices,
        ServiceVehicle,
        GetAllUsers,
        SearchUsers,
        UpdateUser,
    }
}
