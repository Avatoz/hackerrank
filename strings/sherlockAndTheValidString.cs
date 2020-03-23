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

    // Complete the isValid function below.
    static string isValid(string s) {
        Dictionary<char, int> dict = new Dictionary<char, int>();
        char[] ch = s.ToCharArray();
        foreach(char c in ch) {
            if (dict.ContainsKey(c)) {
                dict[c]++;
            } else {
                dict.Add(c,1);
            }
        }
        var arr = new List<int>(dict.Values).GroupBy(x=>x).ToDictionary(x => x.Key, x => x.Count());
        bool valid = true;
        var counter = 0;
        foreach(var i in arr) {
            if ((counter > 0 && i.Value > 1) || counter > 1) {
                valid = false;
                break;
            }
            counter++;
        }
        return valid ? "YES" : "NO";
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string result = isValid(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
