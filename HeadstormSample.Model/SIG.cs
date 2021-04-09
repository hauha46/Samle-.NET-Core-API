using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HeadstormSample.Model

{
    public class SIG
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int LeaderId { get; set; }
        [JsonIgnore]
        public List<Enrollment> EmployeeEnrollment { get; set; }
    }
}
