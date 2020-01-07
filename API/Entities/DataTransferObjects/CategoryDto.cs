using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class CategoryDto
    {
        public int id { get; set; }

        public string name { get; set; }

        public string icon { get; set; }

        public IEnumerable<ComponentDto> Components { get; set; }
    }
}
