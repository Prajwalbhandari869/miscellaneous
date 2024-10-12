using PrajwalStack;
using RE_T_TN_Assignment;
using RE_T_TN_Assignment.NLPAssignmentTwo;
using Utilities;

string filePath = $"C:/Users/USER/Desktop/IOEPulchowk/Practice C#/";
filePath = $"C:/Users/USER/Desktop/IOEPulchowk/Projects/PracticePython/ForTTS_2/preprocessed_data/NepaliSpeech copy/pitch";
RenameFileName();
//await NLPAssignmentOne();
//NLPAssignmentTwo();
//TokenizeNepaliWords();

//CallStaticStack();
//CallDynamicStack();

//ExpressionConversion();

//int diskCount = 3;
//Hanoi.Tower(diskCount, "FirstTower", "SecondTower", "ThirdTower");

void RenameFileName()
{
    Renamer renamer = new Renamer(filePath);
    renamer.Rename("NepaliSpeech2", "NepaliSpeech");
}
void TokenizeNepaliWords()
{
    string file = $"{filePath}metadata.txt";
    Tokenizer tokenizer = new Tokenizer();
    tokenizer.TokenizeNepaliWords(file);
}


void ExpressionConversion()
{
    try
    {
        StackOperations operations = new StackOperations();
        string postFixStr = operations.ConvertToPostfix("(a+(b*c+d)/e)");
        Console.WriteLine(postFixStr);
        Console.WriteLine(operations.ConvertToPostfix("a+b*c/d^e^f*d-c"));
        Console.WriteLine(operations.ConvertToPostfix("a+b+c+d"));
        Console.WriteLine(operations.EvaluatePostfix("8 2 3 * 1 / + 4 1 ^ 2 ^ +"));
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        Console.WriteLine(ex.StackTrace);
        throw;
    }

}



void NLPAssignmentTwo()
{
    try
    {
        string word1 = "EDUCATION";
        string word2 = "VACATION";
        EditDistance editDistance = new EditDistance();
        var distanceTable = editDistance.CalculateEditDistance(word1, word2);
        int numberOfRows = distanceTable.GetLength(0);
        int numberOfColumns = distanceTable.GetLength(1);
        Console.Write('\t');
        for (int j = 0; j < numberOfColumns; j++)
        {
            Console.Write(j != 0 ? word2[j - 1] : '#');
            Console.Write('\t');
        }
        Console.WriteLine();
        for (int i = 0; i < numberOfRows; i++)
        {
            Console.Write(i != 0 ? word1[i - 1] : '#');
            Console.Write('\t');
            for (int j = 0; j < numberOfColumns; j++)
            {
                Console.Write(distanceTable[i, j]);
                Console.Write('\t');
            }
            Console.WriteLine();
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        throw;
    }
}


void CallDynamicStack()
{
    try
    {
        DynamicStack<int> dynamicStack = new DynamicStack<int>();
        dynamicStack.Push(1);
        dynamicStack.Push(2);
        dynamicStack.Push(3);
        dynamicStack.Push(4);
        dynamicStack.Push(5);

        int count = dynamicStack.Size;
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine(dynamicStack.Pop());
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

void CallStaticStack()
{
    try
    {
        int stackSize = 5;
        StaticStack<int> stack = new StaticStack<int>(stackSize);
        stack.Push(9);
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        stack.Push(4);
        for (int i = 0; i <= stackSize; i++)
        {
            Console.WriteLine(stack.Pop());
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        throw;
    }
}

async Task NLPAssignmentOne()
{
    RegularExpression regularExpression = new RegularExpression();
    string filePath = $"C:/Users/USER/Desktop/IOEPulchowk/Practice C#/";
    string fileName = $"metadata.txt";
    //if (File.Exists($"{filePath}{fileName}"))
    //{
    //    var fileContent = File.ReadAllText($"{filePath}{fileName}");
    //    if (!string.IsNullOrEmpty(fileContent))
    //    {
    //        await regularExpression.ExtractPhoneNumbersAndEmail(fileContent, filePath);
    //    }
    //    else
    //        Console.WriteLine("File is Empty");
    //}


    Tokenizer tokenizer = new Tokenizer();
    string anEnglishTxtFile = $"metadata.txt";
    if (File.Exists($"{filePath}{anEnglishTxtFile}"))
    {
        var fileContent = File.ReadAllText($"{filePath}{anEnglishTxtFile}");
        if (!string.IsNullOrEmpty(fileContent))
        {
            await tokenizer.Mapper(fileContent, filePath);
            await tokenizer.Reducer(filePath);
        }
        else
            Console.WriteLine("File is Empty");
        await tokenizer.Cleaner(filePath);
    }
}
//Written in c# 10, Dotnet 8. No main function required.
