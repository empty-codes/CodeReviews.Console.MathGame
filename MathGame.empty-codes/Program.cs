using System.Diagnostics;

// Creates List to record results.
List<string> previousGames = new List<string>();

bool isRandomGame;
char operatorChoice;

Stopwatch timer = new Stopwatch();

Console.WriteLine("Welcome to emptycode's math quiz game! :)");
while (true)
{
    int menuChoice;
    int difficultyLevel = 0;
    isRandomGame = false;

    Console.WriteLine("\nEnter one of the options:\n1: Single Operator Game\n2: Random Operator Game\n3: View Previous Games\n4: Exit");
    menuChoice = int.Parse(Console.ReadLine());

    if (menuChoice == 1 || menuChoice == 2)
    {
        while(true)
        {
            Console.WriteLine("\nChoose level of difficulty:");
            Console.WriteLine("\n1: Easy\n2: Medium\n3: Difficult");
            difficultyLevel = int.Parse(Console.ReadLine());

            if (difficultyLevel == 1 || difficultyLevel == 2 || difficultyLevel == 3) break;
            else
            {
                Console.WriteLine("Error! Invalid option.\n");
                continue;
            }
        }
    }
    switch (menuChoice)
    {
        case 1:
            timer.Start();
            Console.Clear();
            GetOperatorChoice();
            GetQuestions(GetNumberOfQuestions(), difficultyLevel);
            break;
        case 2:
            isRandomGame = true;
            timer.Start();
            Console.Clear();
            operatorChoice = '+';
            GetQuestions(GetNumberOfQuestions(), difficultyLevel);
            break;
        case 3:
            Console.Clear();
            GetPreviousGames();
            break;
        case 4:
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
int GetNumberOfQuestions()
{
    Console.Write("How many questions would you like to solve? ");
    int questionNum = int.Parse(Console.ReadLine());
    return questionNum;
}

// Generates questions using the operator chosen.
void GetQuestions(int questionNum, int difficultyLevel)
{
    int a;
    int b;
    int correctCount = 0;
    int userAnswer;
    int correctAnswer;

    //  Generates and displays the questions.
    for (int i = 1; i < questionNum+1; i++)
    {
        // Randomly generates operands a and b.
        Random random = new Random();

        // Changes random generation limits based on difficulty.
        if(difficultyLevel == 1)
        {
            a = random.Next(0, 10);
            // Starts at 1 since division by 0 results in an error.
            b = random.Next(1, 10);
        }
        else if (difficultyLevel == 2)
        {
            a = random.Next(50, 100);
            b = random.Next(10, 20);
        }
        else 
        {
            a = random.Next(100, 1000);
            b = random.Next(10, 500);
        }

        // Randomly selects an operator for each question
        if (isRandomGame)
        {
            char[] operators = { '+', '-', '*', '/', };
            int s = random.Next(operators.Length);
            operatorChoice = operators[s];
        }
        switch (operatorChoice)
        {
            case '+':
                Console.Write($"Question {i}/{questionNum}: {a} + {b} = ");
                userAnswer = int.Parse(Console.ReadLine());
                correctAnswer = a + b;
                IsCorrect(userAnswer, correctAnswer);
                break;

            case '-':
                Console.Write($"Question {i}/{questionNum}: {a} - {b} = ");
                userAnswer = int.Parse(Console.ReadLine());
                correctAnswer = a - b;
                IsCorrect(userAnswer, correctAnswer);
                break;

            case '*':
                Console.Write($"Question {i}/{questionNum}: {a} * {b} = ");
                userAnswer = int.Parse(Console.ReadLine());
                correctAnswer = a * b;
                IsCorrect(userAnswer, correctAnswer);
                break;

            case '/':
                // Ensures division results in integers only.
                while(a % b != 0)
                {
                    // Changes random generation limits based on difficulty.
                    if (difficultyLevel == 1) b = random.Next(1, 10);
                    if (difficultyLevel == 2) b = random.Next(10, 20);
                    if (difficultyLevel == 3) b = random.Next(10, 500);

                    if (a % b == 0) break;
                }
                Console.Write($"Question {i}/{questionNum}: {a} / {b} = ");
                userAnswer = int.Parse(Console.ReadLine());
                correctAnswer = a / b;
                IsCorrect(userAnswer, correctAnswer);
                break;

            default:
                Console.WriteLine("");
                break;
        } 
    }
    // Stops timer
    timer.Stop();

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
    Console.WriteLine($"\nYou got {correctCount}/{questionNum} questions correct in {timer.Elapsed.TotalSeconds} seconds!\n");

    // Stores operator and number of correct answers in the created list.
    previousGames.Add($"Difficulty Level(1 - 3): {difficultyLevel}\nRandom Operator Game? {isRandomGame}" +
        $"\nCorrect Answers: {correctCount}/{questionNum} in {timer.Elapsed.TotalSeconds} seconds.");
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
