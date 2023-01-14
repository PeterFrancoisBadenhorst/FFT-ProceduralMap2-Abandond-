using System;
using System.Linq;
using Newtonsoft.Json;

class Program
{
    static void Main()
    {
        var combinations = GetCombinations("NESWTB");
        SaveAsJson(combinations.ToArray());
        SortByExample(combinations, "NESWTB");
        var json = JsonConvert.SerializeObject(combinations.ToArray());
        File.WriteAllText(@"C:\data\combinations.json", json);
    }

    static void SaveAsJson(string[] combinations)
    {
        var json = JsonConvert.SerializeObject(combinations);
        File.WriteAllText("combinations.json", json);
    }
    static List<string> SortByExample(List<string> input, string example)
    {
        var output = new List<string>();
        foreach (var item in input)
        {
            var sorted = new string(item.OrderBy(c => example.IndexOf(c)).ToArray());
            output.Add(sorted);
        }
        return output;
    }
    static List<string> GetCombinations(string input)
    {
        var combinations = new List<string>();
        for (int i = 0; i < input.Length; i++)
        {
            var c = input[i];
            var remainingString = input.Substring(0, i) + input.Substring(i + 1);
            var subCombinations = GetCombinations(remainingString);
            if (subCombinations.Count == 0)
            {
                combinations.Add(c.ToString());
            }
            else
            {
                foreach (var subCombination in subCombinations)
                {
                    combinations.Add(c + subCombination);
                }
            }
        }
        return combinations;
    }

}
