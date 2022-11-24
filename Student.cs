using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI1250_FinalProject
{
    internal class Student : IEquatable<Student>
    {
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string eNumber { get; set; }
        public string major { get; set; }
        public string concentration { get; set; }
        public int compCredHours { get; set; }
        public int compCredPoints { get; set; }
        public bool filedForGraduation { get; set; }
        public Course[] courses { get; set; }

        public Student()
        {
            firstName = "XXXX";
            middleName = "XXXX";
            lastName = "XXXXXXXX";
            eNumber = "EXXXXXXXX";
            major = "CSCI";
            concentration = "XX";
            compCredHours = 0;
            compCredPoints = 0;
            filedForGraduation = false;
            this.courses = courses;
        }

        public Student(string firstName, string middleName, string lastName, string eNumber, string concentration, Course[] courses)
        {
            this.firstName = firstName;
            this.middleName = middleName;
            this.lastName = lastName;
            this.eNumber = eNumber;
            major = "CSCI";
            this.concentration = concentration;
            compCredHours = 0;
            compCredPoints = 0;
            filedForGraduation = false;
            this.courses = courses;
        }

        public Student(string firstName, string middleName, string lastName, string eNumber, string major,
        string concentration, int compCredHours, int compCredPoints, bool filedForGraduation, Course[] courses)
        {
            this.firstName = firstName;
            this.middleName = middleName;
            this.lastName = lastName;
            this.eNumber = eNumber;
            this.major = major;
            this.concentration = concentration;
            this.compCredHours = compCredHours;
            this.compCredPoints = compCredPoints;
            this.filedForGraduation = filedForGraduation;
            this.courses = courses;
        }

        public Student(Student copyStudent)
        {
            this.firstName = copyStudent.firstName;
            this.middleName = copyStudent.middleName;
            this.lastName = copyStudent.lastName;
            this.eNumber = copyStudent.eNumber;
            this.major = copyStudent.major;
            this.concentration = copyStudent.concentration;
            this.compCredHours = copyStudent.compCredHours;
            this.compCredPoints = copyStudent.compCredPoints;
            this.filedForGraduation = copyStudent.filedForGraduation;
            this.courses = copyStudent.courses;
        }

        public override string ToString()
        {
            string msg = "";
            if (middleName == "")
            {
                msg += $"\nInformation About Student: {this.firstName} {this.lastName} ({GetClassification(compCredHours)})\n";
            }
            else
            {
                msg += $"\nInformation About Student: {this.firstName} {this.middleName[0]}. {this.lastName} ({GetClassification(compCredHours)})\n";
            }
            msg += "-------------------------------------------------\n";
            msg += $"E#: {this.eNumber}\n\n";
            msg += $"Advisor: {GetAdvisor(lastName)}\n\n";
            msg += $"Major: {GetFullMajor(major)}";
            msg += $"Concentration: {GetFullConcentration(concentration)}";
            msg += $"GPA: {GetGPA(compCredHours, compCredPoints)}\n\n";
            msg += $"Graduation Filing Status: {GetGraduationStatus(compCredHours, GetGPA(compCredHours, compCredPoints), filedForGraduation)}\n";
            msg += $"Courses: \n";
            msg += "-------------------------------------------------\n";
            foreach (var course in courses)
            {
                msg += course + "\n";
            }
            return msg;
        }

        public string GetAdvisor(string lastName)
        {
            string advisor = "";
            char lastNameInit = Convert.ToChar(Char.ToUpper(lastName[0]));
            // A = 65, N = 78, Z = 90
            if (lastNameInit >= 65 && lastNameInit <= 78)
            {
                advisor = "Desjardins";
            }
            else if (lastNameInit >= 78 && lastNameInit <= 90)
            {
                advisor = "Price";
            }
            return advisor;
        }

        public string GetClassification(int creditHours)
        {
            //Freshman < 30 hours, Sophomore 30-59 hours, Junior 60-89, Senior 90 and up

            string classification = "";
            if (creditHours < 30)
            {
                classification = "Freshman";
            }
            else if (creditHours >= 30 && creditHours <= 59)
            {
                classification = "Sophomore";
            }
            else if (creditHours >= 60 && creditHours <= 89)
            {
                classification = "Junior";
            }
            else if (creditHours >= 90)
            {
                classification = "Senior";
            }
            else
            {
                classification = "Error: Not Valid Number";
            }
            return classification;
        }

        public double GetGPA(double creditHours, double qualityPoints)
        {
            double gpa = 0.0;
            gpa = (qualityPoints / creditHours);
            return Math.Round(gpa, 2);
        }

        public string GetGraduationStatus(int creditHours, double gpa, bool filedForGrad)
        {
            string graduationStatus = "";
            if (creditHours > 124 && filedForGrad == true && gpa > 2.5)
            {
                graduationStatus += "Ready\n\n";
                graduationStatus += "Qualifications for Graduation:\n";
                graduationStatus += "-------------------------------------\n";
                graduationStatus += "Credit Hours: Satisfactory (" + creditHours + ")\n";
                graduationStatus += "GPA: Satisfactory (" + gpa + ")\n";
                graduationStatus += "Filed for Graduation: True\n";
            }
            else
            {
                graduationStatus += "Not Ready\n\n";
                graduationStatus += "Qualifications for Graduation:\n";
                graduationStatus += "-------------------------------------\n";

                if (creditHours > 124)
                {
                    graduationStatus += "Credit Hours: Satisfactory (" + creditHours + ")\n";
                }
                else
                {
                    graduationStatus += "Credit Hours: Not Satisfactory (" + creditHours + ")\n";
                }

                if (gpa > 2.5)
                {
                    graduationStatus += "GPA: Satisfactory (" + gpa + ")\n";
                }
                else
                {
                    graduationStatus += "GPA: Not Satisfactory (" + gpa + ")\n";
                }

                if (filedForGrad == true)
                {
                    graduationStatus += "Filed for Graduation: True\n";
                }
                else
                {
                    graduationStatus += "Filed for Graduation: False\n";
                }
            }
            return graduationStatus;
        }

        public string GetFullMajor(string major)
        {
            string fullMajor = "";
            if (major.ToUpper() == "CSCI")
            {
                fullMajor += "Computing\n";
            }
            else
            {
                fullMajor += "Error - Improper Major Received\n";
            }
            return fullMajor;
        }

        public string GetFullConcentration(string concentration)
        {
            string fullConcentration = "";
            if (concentration.ToUpper() == "CS")
            {
                fullConcentration += "Computer Science\n";
            }
            else if (concentration.ToUpper() == "CSMN")
            {
                fullConcentration += "Cybersecurity and Modern Networks\n";
            }
            else if (concentration.ToUpper() == "IT")
            {
                fullConcentration += "Information Technology\n";
            }
            else if (concentration.ToUpper() == "IS")
            {
                fullConcentration += "Information Systems\n";
            }
            else
            {
                fullConcentration += "Error - Improper Concentration Received\n";
            }
            return fullConcentration;
        }

        public bool Equals(Student compareStudent)
        {
            if (this.firstName == compareStudent.firstName &&
            this.middleName == compareStudent.middleName &&
            this.lastName == compareStudent.lastName &&
            this.eNumber == compareStudent.eNumber &&
            this.major == compareStudent.major &&
            this.concentration == compareStudent.concentration &&
            this.compCredHours == compareStudent.compCredHours &&
            this.compCredPoints == compareStudent.compCredPoints &&
            this.filedForGraduation == compareStudent.filedForGraduation)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}