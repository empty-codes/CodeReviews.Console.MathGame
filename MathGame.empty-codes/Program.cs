
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
            getQuestions(getOperatorChoice());
            break;
        case 2:
            Console.Clear();
            Console.WriteLine();
            break;
        case 3:
            return;
        default:
            Console.WriteLine("Error! Invalid option.\n");
            break;
    }
   
}


char getOperatorChoice()
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

// generates five questions using the operator chosen
void getQuestions(char operatorChoice)
{
    int a;
    int b;
    int correctCount = 0;
    int userAnswer;
    int correctAnswer;

    //  generates and displays the five questions
    for (int i = 1; i < 6; i++)
    {
        // randomly generates operands a and b
        Random random = new Random();
        a = random.Next(0, 101);
        b = random.Next(1, 101); // starts at 1 since division by 0 results in an error

        switch(operatorChoice)
        {
            case '+':
                Console.Write($"Question {i}/5: {a} + {b} = ");
                userAnswer = int.Parse(Console.ReadLine());
                correctAnswer = a + b;
                isCorrect(userAnswer, correctAnswer);
                break;
            case '-':
                Console.Write($"Question {i}/5: {a} - {b} = ");
                userAnswer = int.Parse(Console.ReadLine());
                correctAnswer = a - b;
                isCorrect(userAnswer, correctAnswer);
                break;
            case '*':
                Console.Write($"Question {i}/5: {a} * {b} = ");
                userAnswer = int.Parse(Console.ReadLine());
                correctAnswer = a * b;
                isCorrect(userAnswer, correctAnswer);
                break;
            case '/':
                // ensures division results in integers only
                while(a % b != 0)
                {
                    b = random.Next(1, 101);
                    if (a % b == 0) break;
                }
                Console.Write($"Question {i}/5: {a} / {b} = ");
                userAnswer = int.Parse(Console.ReadLine());
                correctAnswer = a / b;
                isCorrect(userAnswer, correctAnswer);
                break;
            default:
                Console.WriteLine("");
                break;
        } 
    }

    void isCorrect(int userAnswer, int correctAnswer)
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

}

Console.ReadLine();