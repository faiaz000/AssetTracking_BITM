using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using AssetTracking.Model;

namespace AssetTracking.Model
{
    public class Branch
    {
        public int id { get; set; }

        public int Organization_id { get; set; }

        public string BranchName { get; set; }

        public string ShortName { get; set; }

        public virtual Organization Organization { get; set; }
    }
}