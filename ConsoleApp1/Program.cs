using PrajwalLinkedList;
using PrajwalQueue;
using PrajwalStack;
using PrajwalTree;
using RE_T_TN_Assignment;
using RE_T_TN_Assignment.NLPAssignmentTwo;
using Utilities;

//string filePath = $"C:/Users/USER/Desktop/IOEPulchowk/Practice C#/";
string filePath = $"C:/Users/USER/Desktop/IOEPulchowk/Practice C#/NepaliTokensPerLengthFirst.txt";
//filePath = $"C:/Users/USER/Desktop/IOEPulchowk/Projects/PracticePython/ForTTS_2/preprocessed_data/NepaliSpeech copy/pitch";
string destinationPath = $"C:/Users/USER/Desktop/IOEPulchowk/Practice C#/NepaliSylla.txt";
//RenameFileName();
//await NLPAssignmentOne();
//NLPAssignmentTwo();
//TokenizeNepaliWords();
//TokenizeWindowWise();
//SortNepaliChars();
CreateSyllabus();

//CallStaticStack();
//CallDynamicStack();
//CallStaticQueue();
//CallCircularQueue();
//CallDynamicCircularQueue();
//CallBinaryTree();
//CallAVLTree();
//SplitAndRemoveSentense();

//ExpressionConversion();
//int diskCount = 3;
//Hanoi.Tower(diskCount, "FirstTower", "SecondTower", "ThirdTower");

//TestLinkedList();
void CreateSyllabus()
{
    NepaliChars chars = new NepaliChars();
    chars.CreateSyllabus(filePath,destinationPath);
}
void SortNepaliChars()
{
    NepaliChars chars = new NepaliChars();
    chars.Sort(filePath);
}
void TokenizeWindowWise()
{
    Tokenizer tokenizer = new Tokenizer();
    tokenizer.TokenizeEachWordWithWindow(filePath, 4);
}
void CallAVLTree()
{
    AVLTree<int> avlTree = new(21);
    avlTree.Insert(26);
    avlTree.Insert(30);
    avlTree.Insert(9);
    avlTree.Insert(4);
    avlTree.Insert(14);
    avlTree.Insert(28);
    avlTree.Insert(18);
    avlTree.Insert(15);
    avlTree.Insert(10);
    avlTree.Insert(2);
    avlTree.Insert(3);
    avlTree.Insert(7);
    avlTree.InOrderTraverse();
    Console.WriteLine();
    avlTree.Delete(2);
    avlTree.Delete(3);
    avlTree.Delete(10);
    avlTree.Delete(18);
    avlTree.Delete(4);
    avlTree.Delete(9);
    avlTree.Delete(14);
    avlTree.Delete(7);
    avlTree.Delete(15);
    avlTree.InOrderTraverse();

}
void CallBinaryTree()
{
    BinarySearchTree<string> binaryTree = new("Hanuman");
    binaryTree.Delete("Egg");
    binaryTree.TraverseInOrder();
    Console.WriteLine();
    binaryTree.TraversePreOrder();
    Console.WriteLine();
    binaryTree.TraversePostOrder();
}
void CallDynamicCircularQueue()
{
    DynamicCircularQueue<char> dynamicCircularQueue = new();
    dynamicCircularQueue.Enqueue('a');
    dynamicCircularQueue.Enqueue('b');
    dynamicCircularQueue.Enqueue('c');
    dynamicCircularQueue.Enqueue('c');
    dynamicCircularQueue.Enqueue('d');
    Console.WriteLine(dynamicCircularQueue.Dequeue());
    Console.WriteLine(dynamicCircularQueue.Dequeue());
    Console.WriteLine(dynamicCircularQueue.Dequeue());
    Console.WriteLine(dynamicCircularQueue.Dequeue());
    Console.WriteLine(dynamicCircularQueue.Dequeue());
    Console.WriteLine(dynamicCircularQueue.Dequeue());
}
void CallCircularQueue()
{
    StaticCircularQueue<string> circularQueue = new StaticCircularQueue<string>(5);
    circularQueue.Enqueue("Prajwal");
    Console.WriteLine(circularQueue.Dequeue());
}
void CallDynamicQueue()
{
    DynamicQueue<char> dynamicQueue = new DynamicQueue<char>();
    dynamicQueue.Enqueue('a');
    Console.WriteLine(dynamicQueue.Dequeue());
}

void CallStaticQueue()
{
    StaticQueue<int> staticQueue = new StaticQueue<int>(10);
    staticQueue.Enqueue(1);
    Console.WriteLine(staticQueue.Dequeue());
}

void RenameFileName()
{
    Renamer renamer = new Renamer(filePath);
    //renamer.Rename("NepaliSpeech2", "NepaliSpeech");
    renamer.Rename();
}
void TokenizeNepaliWords()
{
    //string file = $"{filePath}metadata.txt";
    string file = $"{filePath}";
    Tokenizer tokenizer = new Tokenizer();
    tokenizer.TokenizeNepaliWords(file);
}

void SplitAndRemoveSentense()
{
    //string file = $"{filePath}val1.txt";
    string file = $"{filePath}";
    SplitAndRemove remover = new SplitAndRemove();
    remover.ReWrite(file);
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

void TestLinkedList()
{
    try
    {
        DoublyLinkedList<int> doublyLinkedList = new DoublyLinkedList<int>();
        doublyLinkedList.InsertAtEnd(0);
        doublyLinkedList.InsertAtEnd(1);
        doublyLinkedList.InsertAtEnd(2);
        doublyLinkedList.InsertAtEnd(3);
        doublyLinkedList.InsertAtEnd(4);
        doublyLinkedList.InsertAtEnd(5);
        doublyLinkedList.InsertAtBegining(-1);
        doublyLinkedList.InsertAtEnd(-2);
        doublyLinkedList.AddNode(0);
        doublyLinkedList.AddNode(1);
        doublyLinkedList.DeleteAtBegining();
        doublyLinkedList.DeleteAtEnd();
        doublyLinkedList.DeleteAtEnd();
        doublyLinkedList.DeleteAtEnd();
        doublyLinkedList.TraverseList();
        Console.WriteLine();
        doublyLinkedList.TraverseListReverse();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"{ex.Message}");
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
    //string filePath = $"C:/Users/USER/Desktop/IOEPulchowk/Practice C#/";
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
    //if (File.Exists($"{filePath}{anEnglishTxtFile}"))
    if (File.Exists($"{filePath}"))
    {
        await tokenizer.Mapper(filePath);
        //var fileContent = File.ReadAllText($"{filePath}{anEnglishTxtFile}");
        //var fileContent = File.ReadAllText($"{filePath}");
        //if (!string.IsNullOrEmpty(fileContent))
        //{
        //    await tokenizer.Mapper(fileContent, filePath);
        //    await tokenizer.Reducer(filePath);
        //}
        //else
        //    Console.WriteLine("File is Empty");
        //await tokenizer.Cleaner(filePath);
    }
}
//Written in c# 10, Dotnet 8. No main function required.
