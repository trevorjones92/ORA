using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ORA.Models
{
    public class StoryDM
    {
        public int StoryId { get; set; }

        public string StoryName { get; set; }

        public int StoryNumber { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

        public int ClientId { get; set; }
    }
}