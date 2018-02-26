using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tahfiz.classes
{
    public class User
    {
        public string ID { get; }
        public string username { get; }

        public User(string ID, string username)
        {
            this.ID = ID;
            this.username = username;
        }
    }
}
