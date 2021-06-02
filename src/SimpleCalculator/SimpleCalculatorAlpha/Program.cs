using System;

namespace SimpleCalculatorAlpha
{
    public class Program
    {
        private static int Main()
        {
            Console.WriteLine("===簡易電卓プログラム===");

            while (true)
            {
                Console.WriteLine("数式を半角スペース区切りで入力してください。");
                Console.WriteLine("空文字を入力すると、プログラムは終了します。");

                var s = Console.ReadLine();
                if (string.IsNullOrEmpty(s))
                {
                    Console.WriteLine("簡易電卓プログラムを終了します。");
                    return 0;
                }

                var inputs = s.Split(new[] { ' ' });
                Console.WriteLine($"結果 => {Calculate(inputs)}");
                Console.WriteLine();
            }
        }

        private static int Calculate(string[] expressions)
        {
            if (expressions.Length % 2 == 0)
            {
                HandleError("式が不正です。");
            }

            if (!int.TryParse(expressions[0], out var result))
            {
                HandleError($"{expressions[0]} を数値に変換することができません。");
            }

            for (var i = 1; i < expressions.Length; i += 2)
            {
                var ope = expressions[i];
                if (!int.TryParse(expressions[i + 1], out var value))
                {
                    HandleError($"{expressions[i + 1]} を数値に変換することができません。");
                }

                switch (ope)
                {
                    case "+":
                        result += value;
                        break;
                    case "-":
                        result -= value;
                        break;
                    case "*":
                        result *= value;
                        break;
                    case "/":
                        if (value == 0)
                        {
                            HandleError("0で割ることはできません。");
                            break;
                        }
                        result /= value;
                        break;
                    default:
                        HandleError($"{ope} は未定義の演算子です。");
                        break;
                }
            }

            return result;
        }

        private static void HandleError(string message)
        {
            Console.WriteLine(message);
            Environment.Exit(1);
        }
    }
}
