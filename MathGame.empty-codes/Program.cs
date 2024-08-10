// Creates List to record results.
List<string> previousGames = new List<string>(); 

Console.WriteLine("Welcome to emptycode's math quiz game! :)");
while (true)
{
    int menuChoice;
    Console.WriteLine("Enter:\n1: Start\n2: View Previous Games\n3: Exit");
    menuChoice = int.Parse(Console.ReadLine());

    switch (menuChoice)
    {
        case 1:
            Console.Clear();
            GetQuestions(GetOperatorChoice());
            break;
        case 2:
            Console.Clear();
            GetPreviousGames();
            break;
        case 3:
            return;
        default:
            Console.WriteLine("Error! Invalid option.\n");
            break;
    }
}

char GetOperatorChoice()
{
    while(true)
    {
        char operatorChoice;
        Console.WriteLine("Choose an operation using the options below:");
        Console.WriteLine("'+' for addition\n'-' for subtraction\n'*' for multiplication\n'/' for division");
        operatorChoice = char.Parse(Console.ReadLine());

        if (operatorChoice == '+' || operatorChoice == '-' || operatorChoice == '*' || operatorChoice == '/')
        {
            Console.Clear();
            return operatorChoice;
        }
        else
        {
            Console.WriteLine("Error!, Invalid option.\n");
            continue;
        }
    }
}

// Generates five questions using the operator chosen.
void GetQuestions(char operatorChoice)
{
    int a;
    int b;
    int correctCount = 0;
    int userAnswer;
    int correctAnswer;

    //  Generates and displays the five questions.
    for (int i = 1; i < 6; i++)
    {
        // Randomly generates operands a and b.
        Random random = new Random();
        a = random.Next(0, 101);
        // Starts at 1 since division by 0 results in an error.
        b = random.Next(1, 101); 

        switch (operatorChoice)
        {
            case '+':
                Console.Write($"Question {i}/5: {a} + {b} = ");
                userAnswer = int.Parse(Console.ReadLine());
                correctAnswer = a + b;
                IsCorrect(userAnswer, correctAnswer);
                break;

            case '-':
                Console.Write($"Question {i}/5: {a} - {b} = ");
                userAnswer = int.Parse(Console.ReadLine());
                correctAnswer = a - b;
                IsCorrect(userAnswer, correctAnswer);
                break;

            case '*':
                Console.Write($"Question {i}/5: {a} * {b} = ");
                userAnswer = int.Parse(Console.ReadLine());
                correctAnswer = a * b;
                IsCorrect(userAnswer, correctAnswer);
                break;

            case '/':
                // Ensures division results in integers only.
                while(a % b != 0)
                {
                    b = random.Next(1, 101);
                    if (a % b == 0) break;
                }
                Console.Write($"Question {i}/5: {a} / {b} = ");
                userAnswer = int.Parse(Console.ReadLine());
                correctAnswer = a / b;
                IsCorrect(userAnswer, correctAnswer);
                break;

            default:
                Console.WriteLine("");
                break;
        } 
    }

    void IsCorrect(int userAnswer, int correctAnswer)
    {
        if (userAnswer == correctAnswer)
        {
            Console.WriteLine("Correct!");
            correctCount++;
        }
        if (userAnswer != correctAnswer)
        {
            Console.WriteLine($"Wrong! {a} {operatorChoice} {b} = {correctAnswer}");
        }
    }
    Console.WriteLine($"\nYou got {correctCount}/5 questions correct!\n");
    // Stores operator and number of correct answers in the created list.
    previousGames.Add($"Operator: {operatorChoice}\nCorrect Answers: {correctCount}");
}

void GetPreviousGames()
{
    if (previousGames.Count > 0)
    {
        Console.WriteLine("Previous Game History: ");
        // Displays results for each game stored as a list object.
        for (int i = 0; i < previousGames.Count; i++)
        {
            Console.WriteLine($"\nGame {i+ 1}\n--------\n{previousGames[i]}\n");
        }
    }
    else Console.WriteLine("No previous games are recorded.\n");
}
