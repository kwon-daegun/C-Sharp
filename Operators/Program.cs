using System;

// 1. UNARY OPERATORS (Action on a single variable)
Console.WriteLine("--- Unary Operators ---");

int counter = 1;
counter++; // Increment
Log("Increment (++)", 2, counter);

bool isActive = true;
bool isInactive = !isActive; // Negation (Not)
Log("Negation (!)", false, isInactive);


// 2. MATH OPERATORS
Console.WriteLine("\n--- Math Operators ---");

int baseNum = 5;
Log("Multiplication (*)", 10, baseNum * 2);

int divisionBase = 10;
Log("Division (/)", 5, divisionBase / 2);

// Modulo (Remainder) is crucial for finding even/odd numbers
int remainderBase = 10;
Log("Modulo (%)", 1, remainderBase % 3); // 10 divided by 3 is 3, with remainder 1


// 3. RELATIONAL OPERATORS (Comparison)
Console.WriteLine("\n--- Relational Operators ---");

int val = 4;
Log("Greater Than (>)", true, val > 2);
Log("Less Than (<)", false, val < 1);
Log("Greater/Equal (>=)", true, val >= 4);
Log("Lesser/Equal (<=)", false, val <= 3);


// 4. TYPE CHECKING (is / as)
Console.WriteLine("\n--- Type Checking ---");

object numberObject = 12; // Boxing an int inside an object
Log("IS operator (int)", true, numberObject is int);

// Note: 10.2 is essentially a 'double' in C#, not a float.
object doubleObject = 10.2;
Log("IS operator (float)", false, doubleObject is float);
Log("IS operator (double)", true, doubleObject is double);

// AS operator (Safe casting)
object textObject = "Hello World";
string? textResult = textObject as string; // if this failed, textResult would be null
Log("AS operator", "Hello World", textResult);


// 5. BITWISE OPERATORS (Binary Math)
// These look like logical operators, but they act on Bits (0s and 1s)
Console.WriteLine("\n--- Bitwise Operators ---");

int bitValue = 7; // Binary: 0111
// AND (&) - Both bits must be 1 to stay 1
// 0111 (7)
// 0011 (3)
// ----
// 0011 (Result is 3)
Log("Bitwise AND (&)", 3, bitValue & 3);

// OR (|) - Either bit is 1 to become 1
// 0111 (7)
// 0011 (3)
// ----
// 0111 (Result is 7)
Log("Bitwise OR (|)", 7, bitValue | 3);


// 6. SHIFT OPERATORS (Moving bits left or right)
Console.WriteLine("\n--- Shift Operators ---");

int shiftBase = 8; // Binary: 0000 1000
// Shift Left (<<) multiplies by 2
// Becomes: 0001 0000 (16)
Log("Shift Left (<<)", 16, shiftBase << 1);

// Shift Right (>>) divides by 2
// Becomes: 0000 0100 (4)
Log("Shift Right (>>)", 4, shiftBase >> 1);


// 7. NULL OPERATORS
Console.WriteLine("\n--- Null Operators ---");

string? nullString = null;
// The Null Coalescing Operator (??)
// "If the left side is null, use the right side."
string finalString = nullString ?? "Default Value";
Log("Null Coalescing (??)", "Default Value", finalString);

// 8. TERNARY OPERATOR
Console.WriteLine("\n--- Ternary Operator ---");

int teenager = 13;
string welcomeMessage = (teenager >= 13) ? "Welcome, teenagers are allowed." : "You're not allowed, you're not a teenager.";
Log("Ternary (?:)", "Welcome, teenagers are allowed.", welcomeMessage);

// --- HELPER METHOD ---
void Log(string operation, object expected, object actual)
{
    // String interpolation with alignment padding {0, -25}
    // (-25): Align Left. (Add spaces to the right).
    // (25): Align Right. (Add spaces to the left).
    Console.WriteLine($"{operation, -25} | Expected: {expected} | Actual: {actual}");
}