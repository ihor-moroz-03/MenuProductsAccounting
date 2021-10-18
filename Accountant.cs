using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MenuProductsAccounting
{
    static class Accountant
    {
        static Dictionary<string, double> GetProductList(string text)
        {
            var result = new Dictionary<string, double>();
            Regex reg = new Regex(@"(\w+) (\d*\.?\d+)");
            foreach (string line in text.Split('\n'))
            {
                var match = reg.Match(line);
                if (match.Success)
                {
                    string name = match.Groups[1].Value;
                    double weight = double.Parse(match.Groups[2].Value);
                    if (result.ContainsKey(name)) result[name] += weight;
                    else result[name] = weight;
                }
            }
            return result;
        }

        public static string GetReport(string menu, string priceList)
        {
            var products = GetProductList(menu);
            var prices = new Dictionary<string, double>();
            foreach (string line in priceList.Split('\n'))
            {
                string[] split = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                prices.Add(split[0], double.Parse(split[1]));
            }
            string[] result = new string[prices.Count];
            int i = 0;
            foreach (var pair in prices)
            {
                result[i] = $"{pair.Key} {products[pair.Key]:f2} {(products[pair.Key] * pair.Value):f2}";
                i++;
            }
            return string.Join<string>('\n', result);
        }
    }
}
