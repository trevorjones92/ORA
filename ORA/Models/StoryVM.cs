using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ORA.Models
{
    public class StoryVM
    {
        public int StoryId { get; set; }

        [DisplayName("Story Name")]
        public string StoryName { get; set; }

        [DisplayName("Story Number")]
        public int StoryNumber { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("End Date")]
        public DateTime EndDate { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }
    }
}