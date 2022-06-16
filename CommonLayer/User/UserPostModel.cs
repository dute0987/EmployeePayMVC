using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.User
{
    public class UserPostModel
    {
            public int EmployeeId { get; set; }
            [Required]
            public string Name { get; set; }
            [Required]
            public string profileImage { get; set; }
            [Required]
            public string Gender { get; set; }
            [Required]
            public string Department { get; set; }
            [Required]
            public long salary { get; set; }
            [Required]
            public DateTime startDate { get; set; }
            [Required]
            public string notes { get; set; }
        
    }
}
