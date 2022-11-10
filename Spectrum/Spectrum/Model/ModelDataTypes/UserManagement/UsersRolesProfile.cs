using System;
using System.Collections.Generic;
using System.Text;

namespace Spectrum.Model.ModelDataTypes
{
    public class UsersRolesProfile : BaseEntity
    {
        public Int64 UserInRolesID { get; set; }
        public Int64 UserID { get; set; }
        public Int32 RoleID { get; set; }
    }
}
