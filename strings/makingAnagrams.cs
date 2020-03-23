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

    // Complete the makeAnagram function below.
    static int makeAnagram(string a, string b) {
        Dictionary<char, int> dict = new Dictionary<char, int>();
        char[] cha = a.ToCharArray();
        char[] chb = b.ToCharArray();
        int counter = 0;
        foreach(char c in cha) {
            if (dict.ContainsKey(c)) {
                dict[c]++;
            } else {
                dict.Add(c, 1);
            }
        }
        foreach(char c in chb) {
            if (dict.ContainsKey(c) && dict[c] > 0) {
                dict[c]--;
            } else {
                counter++;
            }
        }
        var leftovers = dict.Where(k => k.Value > 0);
        foreach(var c in leftovers) {
            counter+=c.Value;
        }
        return counter;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string a = Console.ReadLine();

        string b = Console.ReadLine();

        int res = makeAnagram(a, b);

        textWriter.WriteLine(res);

        textWriter.Flush();
        textWriter.Close();
    }
}
