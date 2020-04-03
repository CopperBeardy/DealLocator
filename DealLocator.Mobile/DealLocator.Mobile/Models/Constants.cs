using System;
using System.Collections.Generic;
using System.Text;

namespace DealLocator.Mobile.Models
{

    public static class Constants
    {

      
       
        static readonly string tenantName = "";

        static readonly string tenantId = "";

        static readonly string clientId = "";

        static readonly string policySignin = "";

        static readonly string policyPassword = "";


        static readonly string[] scopes = { "" };
        static readonly string authorityBase = $"https://{tenantName}.b2clogin.com/tfp/{tenantId}/";
        public static string ClientId
        {
            get
            {
                return clientId;
            }
        }
        public static string AuthoritySignin
        {
            get
            {
                return $"{authorityBase}{policySignin}";
            }
        }
        public static string AuthorityPasswordReset
        {
            get
            {
                return $"{authorityBase}{policyPassword}";
            }
        }
        public static string[] Scopes
        {
            get
            {
                return scopes;
            }
        }

    }
}
