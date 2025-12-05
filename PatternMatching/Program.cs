using PatternMatching;

decimal savings = AskDecimal("How much cash do you have?");
decimal income = AskDecimal("What's your annual income?");
decimal cost = AskDecimal("How much does the bike cost?");
int? score = AskNullableInt("What's your credit score? (Press \"ENTER\" if you don't know)");

var userProfile = new UserFinancials(savings, income, score, cost);

decimal maxLoan = LoanSystem.CalculateMaxLoan(userProfile);
decimal totalPurchasingPower = userProfile.Savings + maxLoan;

// --- HELPER METHODS ---
static string UserInput(string prompt)
{
    Console.WriteLine(prompt);
    return Console.ReadLine();
}

static decimal AskDecimal(string prompt)
{
    while (true)
    {
        string input = UserInput(prompt);

        if (decimal.TryParse(input, out decimal result))
        {
            return result;
        }
        
        Console.WriteLine("Invalid number. Please try again.");
    }
}

static int? AskNullableInt(string prompt)
{
    string input = UserInput(prompt);

    if (string.IsNullOrWhiteSpace(input))
    {
        return null;
    }

    if (int.TryParse(input, out int result))
    {
        return result;
    }

    Console.WriteLine("Invalid input, treating as Unknown.");
    return null;
}

string resultMessage = totalPurchasingPower switch
{
    var t when userProfile.Savings >= userProfile.BikeCost
    => "APPROVED: You can pay with cash.",

    var t when t >= userProfile.BikeCost
    => $"APPROVED: You need a loan of {userProfile.BikeCost - userProfile.Savings:C}, and the Bank approved it.",

    _ => $"DENIED: Even with a loan of {maxLoan:C}, you cannot afford this."
};

Console.WriteLine();
Console.WriteLine($"--- BANK SYSTEM REPORT ---");
Console.WriteLine($"Credit Score: {userProfile.CreditScore?.ToString() ?? "Unknown"}");
Console.WriteLine($"Max Loan Offered: {maxLoan:C}");
Console.WriteLine($"Decision: {resultMessage}");

namespace PatternMatching
{
    public record struct UserFinancials(
    decimal Savings,
    decimal AnnualIncome,
    int? CreditScore,
    decimal BikeCost
    );

    public static class LoanSystem
    {
        public static decimal CalculateMaxLoan(UserFinancials user)
        {
            return user.CreditScore switch
            {
                < 600 => 0,
                >= 700 => user.AnnualIncome * 0.5m,
                >= 600 => user.AnnualIncome * 0.2m,
                // Rule: If user don't know credit score, we assume High Risk. 
                // We give a tiny loan (5% of income) just to be safe.
                null => user.AnnualIncome * 0.05m
            };
        }

        public static bool IsEligibleForLoan(UserFinancials user)
            => CalculateMaxLoan(user) > 0;
    };
}
