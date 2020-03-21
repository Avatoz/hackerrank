using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution {

    // Complete the isBalanced function below.
    static string isBalanced(string s) {
        bool valid = true;
        Stack openBrackets = new Stack();
        char[] charBrackets = s.ToCharArray();
        foreach (char c in charBrackets) {
            if (c == '{' || c == '[' || c == '(') {
                openBrackets.Push(c);
            } else {
                if (openBrackets.Count > 0) {
                    char lastOpen = Convert.ToChar(openBrackets.Peek());
                    if ((lastOpen == '{' && c == '}') || (lastOpen == '(' && c == ')') || (lastOpen == '[' && c == ']')) {
                        openBrackets.Pop();
                    } else {
                        valid = false;
                        break;
                    }
                } else {
                    valid = false;
                    break;                    
                }
            }
        }
        return valid && openBrackets.Count == 0 ? "YES" : "NO";

    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int t = Convert.ToInt32(Console.ReadLine());

        for (int tItr = 0; tItr < t; tItr++) {
            string s = Console.ReadLine();

            string result = isBalanced(s);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
