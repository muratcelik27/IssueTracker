﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IssueTracker.Models
{
    public class Issue : AppCode.BaseEntity
    {
       
        [Required, StringLength(128), Column(TypeName = "varchar")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(MAX)")]
        public string Desription { get; set; }


        public int ProjectID { get; set; }
        [ForeignKey("ProjectID")]
        public Project Project { get; set; }

        public int CollobratorID { get; set; }
        [ForeignKey("CollobratorID")]
        public Collobrator Collobrator { get; set; }

        public int ColumnID { get; set; }
        [ForeignKey("ColumnID")]
        public Column Column { get; set; }

        public int PriorityID { get; set; }
        [ForeignKey("PriorityID")]
        public Priority Priority { get; set; }

        public int TypeID { get; set; }
        [ForeignKey("TypeID")]
        public Type Type { get; set; }


        [NotMapped]
        public List<Watcher> Watchers { get; set; }
        [NotMapped]
        public List<Comment> Comments { get; set; }
        [NotMapped]
        public List<IssueTag> IssueTags { get; set; }

    }
}