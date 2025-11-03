using System;
using System.Globalization;
using Classes_M3;

Console.WriteLine("Creating BankCustomer objects...");
BankCustomer customer1 = new BankCustomer("Tim", "Shao");
BankCustomer customer2 = new BankCustomer("Lisa", "Shao");
BankCustomer customer3 = new BankCustomer("Sandy", "Zoeng");

Console.WriteLine($"BankCustomer 1: {customer1.FirstName} {customer1.LastName} {customer1.CustomerId}");
Console.WriteLine($"BankCustomer 2: {customer2.FirstName} {customer2.LastName} {customer2.CustomerId}");
Console.WriteLine($"BankCustomer 3: {customer3.FirstName} {customer3.LastName} {customer3.CustomerId}");

Console.WriteLine("\nCreating BankAccount objects for customers...");
BankAccount account1 = new BankAccount(customer1.CustomerId, 0);
BankAccount account2 = new BankAccount(customer2.CustomerId, 1500);
BankAccount account3 = new BankAccount(customer3.CustomerId, 2500);

Console.WriteLine(account1.DisplayAccountInfo());
Console.WriteLine(account2.DisplayAccountInfo());
Console.WriteLine(account3.DisplayAccountInfo());

Console.WriteLine("\nUpdating BankCustomer 1's name...");
customer1.UpdateName("Thomas", "Margand");
Console.WriteLine($"Updated BankCustomer 1: {customer1.FirstName} {customer1.LastName} {customer1.CustomerId}");

Console.WriteLine("\nDemonstrating BankAccount methods...");
double depositAmount = 500;
Console.WriteLine($"Depositing {depositAmount.ToString("C", CultureInfo.CurrentCulture)} into Account 1...");
account1.Deposit(depositAmount);
Console.WriteLine($"Account 1 after deposit: Balance = {account1.Balance.ToString("C", CultureInfo.CurrentCulture)}");

double withdrawalAmount = 200;
Console.WriteLine($"Withdrawing {withdrawalAmount.ToString("C", CultureInfo.CurrentCulture)} from Account 2...");
bool withdrawSuccess = account2.Withdraw(withdrawalAmount);
Console.WriteLine($"Account 2 after withdrawal: Balance = {account2.Balance.ToString("C", CultureInfo.CurrentCulture)}, Withdrawal successful: {withdrawSuccess}");

double transferAmount = 300;
Console.WriteLine($"Transferring {transferAmount.ToString("C", CultureInfo.CurrentCulture)} from Account 3 to Account 1...");
bool transferSuccess = account3.Transfer(account1, transferAmount);
Console.WriteLine($"Account 3 after transfer: Balance = {account3.Balance.ToString("C", CultureInfo.CurrentCulture)}, Transfer successful: {transferSuccess}");
Console.WriteLine($"Account 1 after receiving transfer: Balance = {account1.Balance.ToString("C", CultureInfo.CurrentCulture)}");

Console.WriteLine("\nDemonstrating utility methods in AccountCalculations...");
double principal = account1.Balance;
double rate = BankAccount.InterestRate;
double time = 1;
double compoundInterest = AccountCalculations.CalculateCompoundInterest(principal, rate, time);
Console.WriteLine($"Compound interest on account1 balance of {principal.ToString("C", CultureInfo.CurrentCulture)} at {rate * 100:F2}% for {time} year: {compoundInterest.ToString("C", CultureInfo.CurrentCulture)}");

int accountNumber = account1.AccountNumber;
bool isValidAccountNumber = AccountCalculations.ValidateAccountNumber(accountNumber);
Console.WriteLine($"Is account number {accountNumber} valid? {isValidAccountNumber}");

double transactionAmount = 800;
double transactionFee = AccountCalculations.CalculateTransactionFee(transactionAmount, BankAccount.TransactionRate, BankAccount.MaxTransactionFee);
Console.WriteLine($"Transaction fee for a {transactionAmount.ToString("C", CultureInfo.CurrentCulture)} wire transfer at a {BankAccount.TransactionRate * 100:F2}% rate and a max fee of {BankAccount.MaxTransactionFee.ToString("C", CultureInfo.CurrentCulture)} is: {transactionFee.ToString("C", CultureInfo.CurrentCulture)}");

double overdrawnAmount = 500;
double overdraftFee = AccountCalculations.CalculateOverdraftFee(overdrawnAmount, BankAccount.OverdraftRate, BankAccount.MaxOverdraftFee);
Console.WriteLine($"Overdraft fee for an account that's {overdrawnAmount.ToString("C", CultureInfo.CurrentCulture)} overdrawn, using a penalty rate of {BankAccount.OverdraftRate * 100:F2}% and a max fee of {BankAccount.MaxOverdraftFee.ToString("C", CultureInfo.CurrentCulture)} is: {overdraftFee.ToString("C", CultureInfo.CurrentCulture)}");

double originalCurrencyProvided = 100;
double currentExchangeRate = 1.2;
double foreignCurrencyReceived = AccountCalculations.ReturnForeignCurrency(originalCurrencyProvided, currentExchangeRate);
Console.WriteLine($"The foreign currency received after exchanging {originalCurrencyProvided.ToString("C", CultureInfo.CurrentCulture)} at an exchange rate of {currentExchangeRate:F2} is: {foreignCurrencyReceived.ToString("C", CultureInfo.CurrentCulture)}");

Console.WriteLine("\nApplying interest to Account 1...");
double timePeriodYears = 30 / 365.0;
account1.ApplyInterest(timePeriodYears);
Console.WriteLine($"Account 1 after applying interest: Balance = {account1.Balance.ToString("C", CultureInfo.CurrentCulture)}, Interest Rate = {BankAccount.InterestRate:P2}, Time Period = {timePeriodYears:F2} years");

Console.WriteLine("Issue cashier's check from account 2...");
double checkAmount = 500;
bool receivedCashiersCheck = account2.IssueCashiersCheck(checkAmount);
Console.WriteLine($"Account 2 after requesting cashier's check: Received cashier's check: {receivedCashiersCheck}, Balance = {account2.Balance.ToString("C", CultureInfo.CurrentCulture)}, Transaction Amount = {checkAmount.ToString("C", CultureInfo.CurrentCulture)}, Transaction Fee Rate = {BankAccount.TransactionRate:P2}, Max Transaction Fee = {BankAccount.MaxTransactionFee.ToString("C", CultureInfo.CurrentCulture)}");

Console.WriteLine("Applying refund to Account 3...");
double refundAmount = 50;
account3.ApplyRefund(refundAmount);
Console.WriteLine($"Account 3 after applying refund: Balance = {account3.Balance.ToString("C", CultureInfo.CurrentCulture)}, Refund Amount = {refundAmount.ToString("C", CultureInfo.CurrentCulture)}");

Console.WriteLine("\nDemonstrating extension methods...");
Console.WriteLine(customer1.GreetCustomer());
Console.WriteLine($"Is customer1 ID valid? {customer1.IsValidCustomerId()}");
Console.WriteLine($"Can account2 withdraw 2000? {account2.CanWithdraw(2000)}");
Console.WriteLine($"Is account3 overdrawn? {account3.IsOverdrawn()}");

Console.WriteLine("\nDisplaying customer and account information...");
Console.WriteLine(customer1.DisplayCustomerInfo());
Console.WriteLine(account1.DisplayAccountInfo());

Console.WriteLine("\nDemonstrating named and optional parameters...");
string customerId = customer1.CustomerId;
double openingBalance = 1500;

BankAccount account4 = new BankAccount(customerId);
Console.WriteLine(account4.DisplayAccountInfo());

BankAccount account5 = new BankAccount(customer1.CustomerId, openingBalance);
Console.WriteLine(account5.DisplayAccountInfo());

BankAccount account6 = new BankAccount(customer2.CustomerId, accountType: "Checking");
Console.WriteLine(account6.DisplayAccountInfo());

BankAccount account7 = new BankAccount(accountType: "Checking", balance: 5000, customerIdNumber: customer2.CustomerId);
Console.WriteLine(account7.DisplayAccountInfo());

Console.WriteLine("\nDemonstrating object initializers and copy constructors...");
BankCustomer customer4 = new BankCustomer("Mikaela", "Lee") { FirstName = "Mikaela", LastName = "Lee" };
Console.WriteLine($"BankCustomer 4: {customer4.FirstName} {customer4.LastName} {customer4.CustomerId}");

BankCustomer customer5 = new BankCustomer(customer4);
Console.WriteLine($"BankCustomer 5 (copy of customer4): {customer5.FirstName} {customer5.LastName} {customer5.CustomerId}");

BankAccount account8 = new BankAccount(customer4.CustomerId) { AccountType = "Savings" };
Console.WriteLine($"Account 8: Account # {account8.AccountNumber}, type {account8.AccountType}, balance {account8.Balance}, rate {BankAccount.InterestRate}, customer ID {account8.CustomerId}");

BankAccount account9 = new BankAccount(account4);
Console.WriteLine($"Account 9 (copy of account4): Account # {account9.AccountNumber}, type {account9.AccountType}, balance {account9.Balance}, rate {BankAccount.InterestRate}, customer ID {account9.CustomerId}");
