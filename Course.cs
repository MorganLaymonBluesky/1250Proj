using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI1250_FinalProject
{
    internal class Course
    {
        string courseName;
        int courseNumber;

        public Course()
        {
            this.courseName = "XXXX";
            this.courseNumber = 0;
        }
        public Course(string courseName, int courseNumber)
        {
            this.courseName = courseName;
            this.courseNumber = courseNumber;
        }
        public override string ToString()
        {
            string msg = "";
            msg += $"{courseName} {courseNumber}";
            return msg;
        }
    }
}
