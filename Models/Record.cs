
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace IdentityApp.Models {

    public class Record {
        public long? Id { get; set; }

        public DateTime InterviewDate { get; set; }
        public DateTime EmploymentDate { get; set; }
        public string Note { get; set; } = String.Empty;
        public string Interests { get; set; } = String.Empty;
        public bool Employed { get; set; }


        [Column(TypeName = "decimal(8, 2)")]
        public decimal Rating { get; set; }


        [ForeignKey(nameof(Person))]
        public long? PersonId { get; set; }

    }
}