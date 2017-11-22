﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ORA.Models
{
    public class ProjectVM
    {
        public int ProjectId { get; set; }

        [DisplayName("Project Name")]
        public string ProjectName { get; set; }

        [DisplayName("Project Number")]
        public string ProjectNumber { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("End Date")]
        public DateTime EndDate { get; set; }

        public int ClientId { get; set; }

        public List<ClientsVM> Clients { get; set; }

        public DateTime Created { get; set; }

        [DisplayName("Created By")]
        public string CreatedBy { get; set; }

        public DateTime Modified { get; set; }

        [DisplayName("Modified By")]
        public string ModifiedBy { get; set; }
    }
}