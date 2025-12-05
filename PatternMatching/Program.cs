var buyer = new BuyerProfile(Savings: 300, CostOfBicycle: 1000, MaxLoanAmount: 100, CanGetLoan: true);

string message = buyer switch
{
    // Case 1:
    // Deconstruction of Variables
    { Savings: var s, CostOfBicycle: var c } when s >= c
        => "I have enough money to buy the bicycle.",

    // Case 2:
    var b when b.TotalAvailable >= b.CostOfBicycle
        => "I need a loan, but I can buy the bicycle!",

    // Case 3:
    var b when b.TotalAvailable >= (b.CostOfBicycle * 0.9m)
        => "Close! I have over 90% of the money needed.",

    // Case 4:
    var b when b.TotalAvailable > (b.CostOfBicycle / 2)
        => "I have over half the money needed.",

    // Default:
    _ => "I do not have enough money to buy the bicycle."
};

Console.WriteLine(message);

// Encapsulation using record
public record BuyerProfile(decimal Savings, decimal CostOfBicycle, decimal MaxLoanAmount, bool CanGetLoan)
{
    // If we can't get a loan, the loan amount is effectively 0.
    public decimal TotalAvailable => Savings + (CanGetLoan ? MaxLoanAmount : 0);
}