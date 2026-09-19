Presented by:Diyar Kabyken IT-2503


Runs:
Regular inputs
<img width="974" height="274" alt="image" src="https://github.com/user-attachments/assets/f12dadf2-9f47-4ed5-b4be-fd9c9a530f44" />
<img width="867" height="217" alt="image" src="https://github.com/user-attachments/assets/356505fe-06b8-413f-9a0d-90b1353f835a" />
<img width="886" height="214" alt="image" src="https://github.com/user-attachments/assets/0a9bdd29-788b-4e89-8370-dda0b2df381f" />
<img width="891" height="211" alt="image" src="https://github.com/user-attachments/assets/4f396474-a2dc-4da3-9e80-ad95e980fc29" /> 
Empty input
 <img width="974" height="154" alt="image" src="https://github.com/user-attachments/assets/c5e81dbb-c77a-44e0-9c91-27572c1e538c" />
Negative input
<img width="974" height="181" alt="image" src="https://github.com/user-attachments/assets/ba2de4e8-cf45-459c-8b9a-1868ba4945ad" />


How to Run
1.	Open your terminal in VS Code inside the project directory:
Bash
cd IFP/FunctionalDeliveryCalculator

2.	Build and run the project:
Bash
dotnet run

3.Enter the requested inputs (base price, quantity, delivery type, zone, express flag) when prompted.


Answers to questions:

Q1: Which parts of your program handle user input and output?
Answer: The Main method handles all user I/O operations (reading inputs with Console.ReadLine and outputting results or error messages with Console.WriteLine). Calculation functions are isolated from console operations.

Q2: Which functions perform only delivery price calculations?
Answer: The functions CalculateTotalPrice, ApplyQuantityRule, ApplyRule, and the delegate variables (applyType, applyZone) perform pure price calculations. They contain no console interaction or global mutable state.

Q3: How is Func<...> used to apply delivery pricing rules?
Answer: Func<decimal, decimal> represents a rule that accepts a decimal price and returns a transformed decimal price. These rule delegates are passed into the higher-order function ApplyRule to modify the price step-by-step.

Q4: Why is TryParse useful when processing delivery data entered by the user?
Answer: TryParse converts raw string input into target data types (decimal, int, bool, Enum) without throwing runtime exceptions when the input is malformed. It returns false on failure, allowing the program to handle errors gracefully with early exits.



