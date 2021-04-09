using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace HeadstormSample.Model
{
    public class Enrollment
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int SIGId { get; set; }
        [JsonIgnore]
        public Employee Employee { get; set; }
        [JsonIgnore]
        public SIG SIG { get; set; }
    }
}
