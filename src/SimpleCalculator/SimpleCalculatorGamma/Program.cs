using System;

namespace SimpleCalculatorGamma
{
    public class Program
    {
        static int Main(string[] args)
        {
            Console.WriteLine("===簡易電卓プログラム===");

            while (true)
            {
                Console.WriteLine("数式を半角スペース区切りで入力");
                Console.WriteLine("空文字を入力すると、プログラムが終了します。");

                var s = Console.ReadLine();

                if (s == "")
                {
                    Console.WriteLine("簡易電卓を終了します。");
                    return 0;
                }

                var inputs = s.Split(" ");
                //var inputs = s.Split(new[] { ' ' });

                Console.WriteLine($"result : {Calculate(inputs, 0, inputs.Length - 1)}");
            }
        }

        static int Calculate(string[] expressions, int startIndex, int endIndex)
        {
            var result = 0;
            var ope = "+";

            for (var i = startIndex; i <= endIndex; i++)
            {
                if (ope == null)
                {
                    //演算子のターン
                    ope = expressions[i];
                    if (!ValidateOperator(ope))
                    {
                        ExitOnError($"{ope}はサポートされていない演算子です。");
                    }
                }
                else
                {
                    //数値のターン
                    int value;

                    if (expressions[i] == "(")
                    {
                        //括弧の時
                        var end = FindEndIndex(expressions, i);
                        value = Calculate(expressions, i + 1, end - 1);
                        i = end;
                    }
                    else
                    {
                        //数値の時
                        if (!int.TryParse(expressions[i], out value))
                        {
                            ExitOnError($"{expressions[i]}を数値に変換することができません。");
                        }
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
                        default:
                            ExitOnError($"{ope}はサポートされていない演算子です。");
                            break;
                    }

                    ope = null;
                }
            }

            if (ope != null)
            {
                ExitOnError("計算式が演算子で終了しています。");
            }

            return result;
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

        static bool ValidateOperator(string ope)
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

        static void ExitOnError(string message)
        {
            Console.WriteLine(message);
            Environment.Exit(1);
        }

        static int FindEndIndex(string[] expressions, int startIndex)
        {
            var depth = 0;

            for (var i = startIndex; i < expressions.Length; i++)
            {
                switch (expressions[i])
                {
                    case "(":
                        depth++;
                        break;
                    case ")":
                        depth--;
                        break;
                }

                if (depth == 0)
                {
                    return i;
                }

                if (depth < 0)
                {
                    ExitOnError("括弧の終了が先行しています。");
                }
            }

            ExitOnError("括弧の開始と終了の数が不一致です。");
            return -1;
        }
    }
}
