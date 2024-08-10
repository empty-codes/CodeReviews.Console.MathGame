
int menuChoice;
Console.WriteLine("Welcome to emptycode's math quiz game! :)");
Console.Write("Enter 1 to Start or 2 to View Previous Games:");
menuChoice = int.Parse(Console.ReadLine());

switch (menuChoice) {
    case 1:
        getOperatorChoice();
        break;
    case 2:
        Console.WriteLine();
        break;
    default:
        Console.WriteLine("Error!, Enter 1 to Start or 2 to View Previous Games");
        break;  
}

void getOperatorChoice()
{
    Random random = new Random();
    int a = 0, b = 0;
    char operatorChoice;
    Console.WriteLine("Choose an operation using the options below:");
    Console.WriteLine("'+' for addition\n'-' for subtraction\n'*' for multiplication\n'/' for division");
    operatorChoice = char.Parse(Console.ReadLine());

    switch(operatorChoice)
    {
        case '+':
            getAdditionQuestions();
            break;
        case '-':
            getSubtractionQuestions();
            break;
        case '*':
            getMultiplicationQuestions();
            break;
        case '/':
            getDivisionQuestions();
            break;
        default:
            Console.WriteLine("Error!, Input only the specified symbols");
            break;
    }
}

void getAdditionQuestions()
{

}



Console.ReadLine();