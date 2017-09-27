using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProCore.Connector.Web.Models
{
    public class ProCoreModel
    {
        [RegularExpression(@"[^\{\}]*",ErrorMessage = "Please replace token with it value.")]
        public string EndPoint { get; set; }
    }

    public class RefreshToken
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string refresh_token { get; set; }
    }
}