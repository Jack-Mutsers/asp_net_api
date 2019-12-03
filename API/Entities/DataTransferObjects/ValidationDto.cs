using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class ValidationDto
    {
        public Guid access_token { get; set; }
        public Guid user_id { get; set; }
        public DateTime creation_date { get; set; }
        public DateTime expiration_date { get; set; }


    }
}