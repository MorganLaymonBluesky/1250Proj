using CSCI1250_FinalProject;

string firstName = " ";
string middleName = " ";
string lastName = " ";
string eNumber = " ";
string major = " ";
string concentration = " ";
int creditHours = 0;
int qualityPoints = 0;
bool filedForGrad = false;
string filedForGradCheck = " ";
List<Student> studentList = new List<Student>();

NewStudent();
ClearSpecificStudent();
ViewAllStudents();

void NewStudent()
{
    Console.WriteLine("Please enter the student's first name: ");
    firstName = Console.ReadLine();
    while (firstName == "" || Char.ToUpper(firstName[0]) < 65 || Char.ToUpper(firstName[0]) > 90)
    {
        Console.WriteLine("Error: Invalid Input. Please enter the student's First Name: ");
        firstName = Console.ReadLine();
    }
    Console.WriteLine("Please enter the student's middle name: (Optional: Leave Blank for N/A.)");
    middleName = Console.ReadLine();
    ERROR1: // Look Matt, I used a goto. \(•◡•)/
    if (middleName != "")
    {
        while (Char.ToUpper(middleName[0]) < 65 || Char.ToUpper(middleName[0]) > 90)
        {
            Console.WriteLine("Error: Invalid Input. Please enter the student's Middle Name: (Optional: Leave Blank for No Middle Name.)");
            middleName = Console.ReadLine();
            goto ERROR1;
        }
    }
    Console.WriteLine("Please enter the student's last name: ");
    lastName = Console.ReadLine();
    while (lastName == "" || Char.ToUpper(lastName[0]) < 65 || Char.ToUpper(lastName[0]) > 90)
    {
        Console.WriteLine("Error: Invalid Input. Please enter the student's Last Name: ");
        lastName = Console.ReadLine();
    }
    Console.WriteLine("Please enter the student's E#: (Must Start with E and be Followed by Exactly 8 Digits.)");
    eNumber = Console.ReadLine();
    while (eNumber[0] != 'E' || eNumber.Length != 9)
    {
        Console.WriteLine("Error: Invalid Input. Please enter the student's E#: (Must Start with E and be Followed by Exactly 8 Digits.)");
        eNumber = Console.ReadLine();
    }
    Console.WriteLine("Please enter the student's Major: (Formatted by using the shortened, 4-letter variant of the Major. Leave blank if N/A.)");
    major = Console.ReadLine();
    while (major != "" && major.ToUpper() != "CSCI")
    {
        Console.WriteLine("Error: Invalid Input. Please enter the student's Major: (Formatted by using the shortened, 4-letter variant of the Major. Leave blank if N/A.)");
        major = Console.ReadLine();
    }
    Console.WriteLine("Please enter the student's Concentration: (Formatted by using the shortened variant of the Concentration.)");
    concentration = Console.ReadLine();
    while (major != "" && concentration.ToUpper() != "CS" && concentration.ToUpper() != "CSMN" && concentration.ToUpper() != "IT" && concentration.ToUpper() != "IS")
    {
        Console.WriteLine("Error: Invalid Input. Please enter the student's Concentration: (Formatted by using the shortened variant of the Concentration.)");
        concentration = Console.ReadLine();
    }
    Console.WriteLine("Please enter the student's Credit Hours: (This value cannot be negative. Input 0 if N/A.)");
    creditHours = Convert.ToInt32(Console.ReadLine());
    while (creditHours < 0)
    {
        Console.WriteLine("Error: Invalid Input. Please enter the student's Credit Hours: (This value cannot be negative. Input 0 if N/A.)");
        creditHours = Convert.ToInt32(Console.ReadLine());
    }
    Console.WriteLine("Please enter the student's Quality Points: (This value cannot be negative. Input 0 if N/A.)");
    qualityPoints = Convert.ToInt32(Console.ReadLine());
    while (qualityPoints < 0)
    {
        Console.WriteLine("Error: Invalid Input. Please enter the student's Quality Points: (This value cannot be negative. Input 0 if N/A.)");
        qualityPoints = Convert.ToInt32(Console.ReadLine());
    }
    Console.WriteLine("Has the student filed for graduation yet? (Please, say yes or no. Leave Blank if N/A.)");
    filedForGradCheck = Console.ReadLine().ToUpper();
    while (filedForGradCheck != "YES" && filedForGradCheck != "NO" && filedForGradCheck != "")
    {
        Console.WriteLine("Error: Invalid Input. Has the student filed for graduation yet? (Please, say yes or no. Leave Blank if N/A.)");
        filedForGradCheck = Console.ReadLine().ToUpper();
    }
    if (filedForGradCheck == "YES")
    {
        filedForGrad = true;
    }
    else
    {
        filedForGrad = false;
    }
    if (major == "" && creditHours == 0 && qualityPoints == 0 && filedForGradCheck == "") // Accepts only Name, E#, and Concentration
    {
        studentList.Add(new Student(firstName, middleName, lastName, eNumber, concentration));
    }
    else
    {
        studentList.Add(new Student(firstName, middleName, lastName, eNumber, major, concentration, creditHours, qualityPoints, filedForGrad));
    }
    Console.WriteLine("Please enter any courses that the student is currently taking or has completed: ");

}

void ViewAllStudents()
{
    foreach (Student student in studentList)
    {
        Console.WriteLine(student);
    }
}

void ViewSpecificStudent()
{
    Console.WriteLine("Please enter the student's first name: ");
    string fn = Console.ReadLine();
    Console.WriteLine("Please enter the student's last name: ");
    string ln = Console.ReadLine();
    if (studentList.Contains(new Student(firstName = fn, middleName, lastName = ln, eNumber, concentration)) == true)
    {
        Console.WriteLine(studentList.Find(x => x.firstName.Contains(firstName) && x.lastName.Contains(lastName)));
    }
    else
    {
        Console.WriteLine("Error: Student Could Not Be Found");
    }
}

void ClearAllStudents()
{
    studentList.Clear();
}

void ClearSpecificStudent()
{
    string removeConfirmation = "";
    Console.WriteLine("Please enter the first name of the student you would like to remove: ");
    string fn = Console.ReadLine();
    Console.WriteLine("Please enter the last name of the student you would like to remove: ");
    string ln = Console.ReadLine();
    if (studentList.Contains(new Student(firstName = fn, middleName, lastName = ln, eNumber, concentration)) == true)
    {
        Console.WriteLine("Is this the student you would like to remove?:\n" + studentList.Find(x => x.firstName.Contains(firstName) && x.lastName.Contains(lastName)));
        Console.WriteLine("Please input yes to remove, or no to exit.");
        removeConfirmation = Console.ReadLine().ToUpper();
        while (removeConfirmation != "YES" && removeConfirmation != "NO")
        {
            Console.WriteLine("Error: Invalid Input. Please input yes to remove, or no to exit.");
            removeConfirmation = Console.ReadLine().ToUpper();
        }
        if (removeConfirmation == "YES")
        {
            studentList.Remove(studentList.Find(x => x.firstName.Contains(firstName) && x.lastName.Contains(lastName)));
        }
    }
    else
    {
        Console.WriteLine("Error: Student Could Not Be Found");
    }
}
