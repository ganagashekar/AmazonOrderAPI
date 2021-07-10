using System;
using System.Collections.Generic;
using System.Text;

namespace AmazonOrderAPI.Business.Common
{
    public class AuthorizationConsts
    {
        public const string AdministrationPolicy = "RequireAdministratorRole";
        public const string AdministrationRole = "SkorubaIdentityAdminAdministrator";

        public const string AdminPolicy = "RequireAdministratorRole";
        public const string AdminRole = "Admin";

        public const string SellerUserPolicy = "RequireSellerRole";
        public const string SellerRole = "SellerUser";

        public const string CourierUserPolicy = "RequireCourierUserRole";
        public const string CourierRole = "CourierUser";

        public const string MultipleRole = "SellerUser,Admin";
    }
}