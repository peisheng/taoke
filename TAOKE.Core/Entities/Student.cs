using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Abp.Domain.Entities;

namespace TAOKE.Entities
{
    public class Student : Entity
    {
        [StringLength(50)]
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }

        public bool Gender { get; set; }
    }
}
