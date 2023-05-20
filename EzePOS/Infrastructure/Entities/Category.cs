using EzePOS.Infrastructure.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzePOS.Infrastructure.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        [NotMapped]
        public string Color { get; set; }
        [NotMapped]
        public string Foreground { get; set; }

    }
}
