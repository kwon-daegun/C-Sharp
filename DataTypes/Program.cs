// System.Object - base type for all data types in C#

// 1. System.String - this is reference type
//    1.1 Delegate
//    1.2 Dynamic
//    1.3 Array
//    1.4 DateTime

// 2. System.ValueType - this is value type
//    2.1 System.Byte
//    2.2 System.Int16
//    2.3 System.Int32
//    2.4 System.Int64
//    2.5 System.Single
//    2.6 System.Double
//    2.7 System.Decimal
//    2.8 System.Char
//    2.9 System.Boolean

int employeeId = 0;
string firstName = string.Empty;
string? lastName;
decimal annualSalary;
char gender = '\0';
bool isManager = false;

string? employeeGender;
string? managementPart;
string? narrative;

Console.Write("Please enter your unique employee ID: ");
employeeId = Convert.ToInt32(Console.ReadLine());

Console.Write("Please enter your first name: ");
firstName = Console.ReadLine() ?? string.Empty;

Console.Write("Please enter your last name: ");
lastName = Console.ReadLine() ?? string.Empty;

Console.Write("Please enter your annual salary: ");
annualSalary = Convert.ToDecimal(Console.ReadLine());

Console.Write("Please enter your gender (M/F): ");
gender = Convert.ToChar(Console.ReadLine().ToLower());
employeeGender = gender == 'm' ? "male" : "female";

Console.Write("Are you a manager (yes/no): ");
isManager = Console.ReadLine().ToLower() == "yes" ? true : false;

managementPart = isManager ? "part of the management team" : "not part of the management team";

narrative = $"{firstName} {lastName} with an employee ID of {employeeId}, ";
narrative += $"has an annual salary of ${annualSalary}, and identifies as {employeeGender}. ";
narrative += $"Who is {managementPart}.";

Console.Clear();
Console.WriteLine(narrative);