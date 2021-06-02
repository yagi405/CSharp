using System;

namespace SimpleCalculatorBeta
{
    public class Program
    {
        static int Main(string[] args)
        {
            Console.WriteLine("===簡易電卓プログラム===");

            while (true)
            {
                Console.WriteLine("数式を半角スペース区切りで入力してください。");
                Console.WriteLine("空文字を入力するとプログラムは終了します。");

                var s = Console.ReadLine();

                if (s == "")
                {
                    Console.WriteLine("簡易電卓プログラムを終了します。");
                    return 0;
                }

                var inputs = s.Split(" ");
                Console.WriteLine($"result : {Calculate(inputs)}");
                Console.WriteLine();
            }

        }

        static int Calculate(string[] expressions)
        {
            var result = 0;
            var ope = "+";

            for (var i = 0; i < expressions.Length; i++)
            {
                if (ope == null)
                {
                    //演算子のターン
                    ope = expressions[i];
                    if (!ValidateOperators(ope))
                    {
                        ExitOnError($"{ope} は未定義の演算子です。");
                    }
                }
                else
                {
                    //数値のターン
                    if (!int.TryParse(expressions[i], out var value))
                    {
                        ExitOnError($"{expressions[i]}を数値に変換することができません。");
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
                                ExitOnError("0で割ることはできません。");
                            }
                            result /= value;
                            break;
                    }

                    ope = null;
                }
            }

            if (ope != null)
            {
                ExitOnError("数式が演算子で終了しています。");
            }

            return result;
        }

        static void ExitOnError(string message)
        {
            Console.WriteLine(message);
            Environment.Exit(1);
        }

        static bool ValidateOperators(string ope)
        {
            var operators = GetOperators();
            for (var i = 0; i < operators.Length; i++)
            {
                if (ope == operators[i])
                {
                    return true;
                }
            }
            return false;
        }

        static string[] GetOperators()
        {
            return new[]
            {
                "+",
                "-",
                "*",
                "/",
            };
        }
    }
}
