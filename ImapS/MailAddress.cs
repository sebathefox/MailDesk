using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImapS
{
    /// <summary>
    /// A holder object to hold both the address and the custom sender name.
    /// </summary>
    public class MailAddress
    {
        public MailAddress(string address, string name)
        {
            this.Address = address;
            this.Name = name;
        }

        /// <summary>
        /// The mail address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// The sender's name
        /// </summary>
        public string Name { get; set; }
    }
}
