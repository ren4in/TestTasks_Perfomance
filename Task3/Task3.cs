using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

class Task3
{
    static void Main(string[] args)
    {
        if (args.Length != 3)
        {
            Console.WriteLine("Ошибка: нужно передать 3 аргумента (values.json, tests.json, report.json)");
            return;
        }

        string valuesPath = args[0];
        string testsPath = args[1];
        string reportPath = args[2];

        try
        {
            var valueData = JsonConvert.DeserializeObject<ValueRoot>(File.ReadAllText(valuesPath));
            var valueDict = new Dictionary<int, string>();
            foreach (var v in valueData.values)
                valueDict[v.id] = v.value;

            var testData = JsonConvert.DeserializeObject<TestRoot>(File.ReadAllText(testsPath));

            foreach (var test in testData.tests)
                FillValues(test, valueDict);

            string resultJson = JsonConvert.SerializeObject(testData, Formatting.Indented);
            File.WriteAllText(reportPath, resultJson);

            Console.WriteLine("report.json успешно создан.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
    }

    static void FillValues(TestNode node, Dictionary<int, string> values)
    {
        if (values.TryGetValue(node.id, out string val))
            node.value = val;

        if (node.values != null)
        {
            foreach (var child in node.values)
            {
                FillValues(child, values);
            }
        }
    }

    class ValueRoot
    {
        public List<ValueEntry> values { get; set; }
    }

    class ValueEntry
    {
        public int id { get; set; }
        public string value { get; set; }
    }

    class TestRoot
    {
        public List<TestNode> tests { get; set; }
    }

    class TestNode
    {
        public int id { get; set; }
        public string title { get; set; }
        public string value { get; set; }
        public List<TestNode> values { get; set; } // Вложенные тесты
    }
}
