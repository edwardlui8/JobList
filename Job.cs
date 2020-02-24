using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobList
{
    public class Job
    {
        private string title;
        private string link;
        private string salary;
        private string date;

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        public string Link
        {
            get
            {
                return link;
            }
            set
            {
                link = value;
            }
        }

        public string Salary
        {
            get
            {
                return salary;
            }
            set
            {
                salary = value;
            }
        }

        public string Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
            }
        }
    }
}
