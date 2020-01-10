using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class ValidationForCreationDto
    {
        public Guid access_token { get; set; }
        public Guid user_id { get; set; }
    }
}