using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addressbook_web_tests
{
    class GroupData
    {
        private string name;
        private string header = "";
        private string footer = "";

        public GroupData(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                this.name = value;
            }
        }

        public string Header
        {
            get
            {
                return header;
            }
            set
            {
                this.header = value;
            }
        }

        public string Footer
        {
            get
            {
                return footer;
            }
            set
            {
                this.footer = value;
            }
        }

    }
}
