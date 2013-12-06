using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VTMS.Model.Entities
{
    public class Users
    {
        public virtual string UsersId { get; set; }
        public virtual string Password { get; set; }
        public virtual string UsersName { get; set; }
        public virtual string UsersEmail { get; set; }
        public virtual bool UsersIsactive { get; set; }
        public virtual string LoginDate { get; set; }
        public virtual string LoginServer { get; set; }
        public virtual ISet<Privilege> Privileges { get; set; }
    }
}
