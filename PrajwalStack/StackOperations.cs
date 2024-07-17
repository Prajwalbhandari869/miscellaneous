using System.Runtime.ExceptionServices;

namespace PrajwalStack
{
    public class StackOperations
    {

        public StackOperations()
        {

        }
        /// <summary>
        /// Converts infix expression to postfix expression
        /// </summary>
        /// <returns></returns>
        public string ConvertToPostfix(string infix)
        {
            string result = "";
            DynamicStack<char> Stack = new DynamicStack<char>();
            foreach (char newChar in infix)
            {
                if (char.IsLetter(newChar))
                {
                    result += newChar;
                    result += ' ';
                }
                else if (newChar.Equals(')'))
                {
                    bool flag = true;
                    while (flag)
                    {
                        char popped = Stack.Pop();
                        if (popped == '(')
                        {
                            flag = false;
                        }
                        else
                        {
                            result += popped;
                            result += ' ';
                        }

                    }
                }
                else
                {
                    bool flag = true;
                    while (flag)
                    {
                        if (newChar.Equals('('))
                        {
                            Stack.Push(newChar);
                            flag = false;
                        }
                        else
                        {
                            char topData = Stack.GetTopData();
                            if (this.Precedence(topData) >= this.Precedence(newChar) && Associativity(newChar).Equals('L'))
                            {
                                char popped = Stack.Pop();
                                result += popped;
                                result += ' ';
                            }
                            else
                            {
                                Stack.Push(newChar);
                                flag = false;
                            }
                        }
                    }
                }
            }
            while (Stack.Size > 0)
            {
                char popped = Stack.Pop();
                result += popped.Equals('(') ? ' ' : popped;
                result += ' ';
            }
            return result;
        }
        public double EvaluatePostfix(string postfix)
        {
            try
            {
                DynamicStack<string> Stack = new DynamicStack<string>();
                string[] chars = postfix.Split(' ');
                foreach (string c in chars)
                {
                    if (!IsOperator(c))
                    {
                        Stack.Push(c);
                    }
                    else
                    {
                        string? popped1 = Stack.Pop();
                        string? popped2 = Stack.Pop();
                        double result = this.DoOperation(popped1, popped2, c);
                        Stack.Push(result.ToString());
                    }
                }
                string? finalResult = Stack.Pop();
                double.TryParse(finalResult, out double intResult);
                return intResult;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private double DoOperation(string? popped1, string? popped2, string c)
        {
            char _operator = char.Parse(c);
            if (double.TryParse(popped1, out double firstOperand) && double.TryParse(popped2, out double secondOperand))
            {
                switch (_operator)
                {
                    case '*':
                        return secondOperand * firstOperand;
                    case '/':
                        return secondOperand / firstOperand;
                    case '+':
                        return secondOperand + firstOperand;
                    case '-':
                        return secondOperand - firstOperand;
                    case '^':
                        return Math.Pow(secondOperand, firstOperand);                    
                    default:
                        break;
                }
            }
            throw new InvalidOperationException($"Invalid Operator: {c}");
        }

        private bool IsOperator(string c)
        {
            char _operator = char.Parse(c);
            return _operator.Equals('*') || _operator.Equals('/') || _operator.Equals('-') || _operator.Equals('+') || _operator.Equals('^');
        }
        private int Precedence(char c)
        {
            if (c.Equals('+') || c.Equals('-'))
            {
                return 1;
            }
            else if (c.Equals('*') || c.Equals('/'))
                return 2;
            else if (c.Equals('^'))
                return 3;
            return 0;
        }
        private char Associativity(char c)
        {
            return c.Equals('^') ? 'R' : 'L';
        }
    }
}
