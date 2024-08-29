using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C42_G01_EF01.Entities
{
    internal class Course
    {
        [Key]
        public int AnyThing { get; set; }
        [MaxLength(100)]
        [Column("CouresName", TypeName = "nvarchar")]
        public string Name { get; set; }
        [MaxLength(150)]
        public string Description { get; set; }
        public string Duration { get; set; }
        [ForeignKey("Topic")]
        public int TopicId { get; set; }
    }
}
