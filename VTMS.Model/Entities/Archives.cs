using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VTMS.Model.Entities
{
    public class Archives
    {
        public virtual string License { get; set; }
        public virtual string Process { get; set; }
        public virtual string Reason { get; set; }
        public virtual string Saver { get; set; }
        public virtual DateTime SaveDate { get; set; }
    }
}
