using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DriveHub.Models
{
    public class TestDriveRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int request_id { get; set; }

        [Required]
        public DateTime preferred_date { get; set; }

        [Required]
        public TimeSpan preferred_time { get; set; }

        [Required]
        [StringLength(50)]
        public string status { get; set; }
    }
}