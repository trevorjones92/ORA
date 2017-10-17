using System;
using System.ComponentModel;

namespace ORA.Models
{
    public class StoryVM
    {
        public int StoryId { get; set; }

        [DisplayName("Story Name")]
        public string StoryName { get; set; }

        [DisplayName("Story Number")]
        public int StoryNumber { get; set; }

        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }

        [DisplayName("End Date")]
        public DateTime EndDate { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }
    }
}