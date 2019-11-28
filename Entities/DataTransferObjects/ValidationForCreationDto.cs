using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class ValidationForCreationDto
    {
        [Required(ErrorMessage = "user id is required")]
        public Guid user_id { get; set; }
    }
}
