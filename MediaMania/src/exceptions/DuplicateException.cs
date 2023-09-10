using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MediaMania.src.exceptions
{
    public class DuplicateException : Exception
    {
        private string title;

        public DuplicateException(string message, string title) : base(message + "(Title: " + title + ")")
        {
            this.title = title;
        }

        public string GetDuplicateTitle()
        {
            return title;
        }

    }
}
