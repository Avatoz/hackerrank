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

    // Complete the twoStrings function below.
    static string twoStrings(string s1, string s2) {
        Dictionary<char, int> dict = new Dictionary<char, int>();
        char[] ch1 = s1.ToCharArray();
        char[] ch2 = s2.ToCharArray();
        ch1 = ch1.GroupBy(x => x).Select(y => y.First()).ToArray();
        ch2 = ch2.GroupBy(x => x).Select(y => y.First()).ToArray();
        foreach(char c in ch1) 
            if (!dict.ContainsKey(c)) 
                dict.Add(c, 1);
        foreach (char c in ch2) 
            if (dict.ContainsKey(c))
                return "YES";
        return "NO";
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine());

        for (int qItr = 0; qItr < q; qItr++) {
            string s1 = Console.ReadLine();

            string s2 = Console.ReadLine();

            string result = twoStrings(s1, s2);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
