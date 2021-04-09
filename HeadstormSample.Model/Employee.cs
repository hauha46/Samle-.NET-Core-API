using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HeadstormSample.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public List<Enrollment> SIGEnrollment { get; set; } 
    }
}
