using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JobConnection.Models
{
    public class Connection
    {
        public int Id { get; set; }

        public Seeker Seeker { get; set; }
        [ForeignKey("Seeker")]
        public int SeekerId { get; set; }


        public Professional Professional { get; set; }
        [ForeignKey("Professional")]
        public int ProfessionalId { get; set; }


        public string SeekersMessage { get; set; }


        public bool isConnectionAccepted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModified { get; set; }
    }
}