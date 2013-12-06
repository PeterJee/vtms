using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VTMS.Model.Entities
{
    public class Privilege
    {
        public virtual int Id { get; set; }
        public virtual Users User { get; set; }
        public virtual string Itmename { get; set; }
        public virtual string ParentName { get; set; }
        public virtual bool Isactive { get; set; }
    }
}
