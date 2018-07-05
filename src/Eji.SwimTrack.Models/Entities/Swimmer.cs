using Eji.SwimTrack.Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Eji.SwimTrack.Models.Entities
{
    [Table("Swimmers")]
    public class Swimmer : EntityBase
    {
        public int SwimmerId { get; set; }

        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

        [MaxLength(100)]
        public string DisplayName { get; set; }

        [MaxLength(100)]
        public string Nickname { get; set; }

        [Column(TypeName="DATE")]
        public DateTime BirthDate { get; set; }

        public List<Swim> Swims { get; set; }
    }
}
