using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace todoApi.Models
{
    public class TodoItem
    {
        public long Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public bool IsComplete { get; set; }
    }
}