using CSCI1250_FinalProject;

bool exitProgram = false;
int mainSelection = 1;
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
string courseName = " ";
int courseNumber = 0;
int amountOfCourses = 0;
Course[] courses = new Course[amountOfCourses];

List<Student> studentList = new List<Student>();

Console.WriteLine("Hello there! Welcome to the ETSU Student Manager Hub.");
while (exitProgram != true)
{
    Console.WriteLine("\n                Main Menu                \n" +
        "-----------------------------------------");
    Console.WriteLine("[1] - New Student (Create a New Student)\n" +
        "[2] - Student Search (Find a Specific Student)\n" +
        "[3] - View All Students (Will Display All Existing Students)\n" +
        "[4] - Delete Specific Student (Will Erase a Specific Student)\n" +
        "[5] - Delete All Students (Will Erase All Existing Students)\n" +
        "\nInput the respective number for the option you would like to go to: (Input 0 to Exit)");
    mainSelection = Convert.ToInt32(Console.ReadLine());
    while (mainSelection != 0 && mainSelection != 1 && mainSelection != 2 && mainSelection != 3 && mainSelection != 4 && mainSelection != 5)
    {
        Console.WriteLine("Error: Invalid Input. Input the respective number for the option you would like to go to: (Input 0 to Exit)");
        mainSelection = Convert.ToInt32(Console.ReadLine());
    }
    switch (mainSelection)
    {
        case 0:
            {
                exitProgram = true;
                break;
            }
        case 1:
            {
                NewStudent();
                break;
            }
        case 2:
            {
                ViewSpecificStudent();
                break;
            }
        case 3:
            {
                ViewAllStudents();
                break;
            }
        case 4:
            {
                ClearSpecificStudent();
                break;
            }
        case 5:
            {
                ClearAllStudents();
                break;
            }
        default:
            {
                break;
            }
    }
}

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
    // Courses:
    Console.WriteLine("Please enter the amount of courses that the student is currently taking: (Input 0 if N/A)");
    amountOfCourses = Convert.ToInt32(Console.ReadLine());
    while (amountOfCourses < 0)
    {
        Console.WriteLine("Error: Invalid Input. Please enter the amount of courses that the student is currently taking: (Input 0 if N/A)");
        amountOfCourses = Convert.ToInt32(Console.ReadLine());
    }
    courses = SetCourses(amountOfCourses);
    if (major == "" && creditHours == 0 && qualityPoints == 0 && filedForGradCheck == "") // Accepts only Name, E#, and Concentration
    {
        studentList.Add(new Student(firstName, middleName, lastName, eNumber, concentration, courses));
    }
    else
    {
        studentList.Add(new Student(firstName, middleName, lastName, eNumber, major, concentration, creditHours, qualityPoints, filedForGrad, courses));
    }
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
    if (studentList.Contains(new Student(firstName = fn, middleName, lastName = ln, eNumber, major, concentration, creditHours, qualityPoints, filedForGrad, courses)) == true)
    {
        Console.WriteLine(studentList.Find(x => x.firstName.Contains(firstName) && x.lastName.Contains(lastName)));
    }
    else
    {
        Console.WriteLine(studentList.Find(x => x.firstName.Contains(firstName) && x.lastName.Contains(lastName)));
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
    if (studentList.Contains(new Student(firstName = fn, middleName, lastName = ln, eNumber, major, concentration, creditHours, qualityPoints, filedForGrad, courses)) == true)
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

Course[] SetCourses(int amountOfCourses)
{
    if (amountOfCourses != 0)
    {
        Course[] courses = new Course[amountOfCourses];
        for (int i = 0; i < amountOfCourses; i++)
        {
            Console.WriteLine("Please enter the 4-letter subject of Course " + (i + 1) + ": ");
            courseName = Console.ReadLine();
            Console.WriteLine("Please enter the 4-digit identification number of Course " + (i + 1) + ": ");
            courseNumber = Convert.ToInt32(Console.ReadLine());
            courses[i] = new Course(courseName, courseNumber);
        }
        return courses;
    }
    else
    {
        Course[] courses = new Course[1];
        for (int i = 0; i < 1; i++)
        {
            courses[i] = new Course("Courses Taken:", 0);
        }
        return courses;
    }
    return courses;
}