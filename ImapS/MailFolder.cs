using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImapS
{
    public class MailFolder
    {

        public string Name { get; protected set; }

        public MailFolder ParentFolder { get; protected set; }
    }
}
