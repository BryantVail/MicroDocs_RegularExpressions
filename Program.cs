using System;
using System.Text.RegularExpressions;

namespace MicroDocs_RegularExpressions
{
	class Program
	{
		static void Main(string[] args)
		{
			string pattern = "(Mr\\.? |Mrs\\.? |Miss |Ms\\.? )";
			string[] names =
			{
				"Mr. Henry Hunt",
				"Ms. Sara Samuels",
				"Abraham Adams",
				"Ms. Nicole Norris"
			};

			foreach(string name in names)
			{
				Console.WriteLine(Regex.Replace(name, pattern, String.Empty));
			}

			pattern = @"\b(\w+?)\s\1\b";
			string input = "This is a nice day. What about this? This tastes good. I saw a a dog.";

			foreach(Match match in Regex.Matches(input, pattern, RegexOptions.IgnoreCase))
			{
				Console.WriteLine($"{match.Value} (duplicates: '{match.Groups[1].Value}') at position {match.Index}");
			}

			// ----------------------
			var number = "598-95-8447";
			pattern = "[0-9]{3}(-)?[0-9]{2}(-)?[0-9]{4}";
			var ssnMatch = Regex.Match(number, pattern);
			if (ssnMatch.Success != false)
			{
				Console.WriteLine($"Number as it was input:\n\t{number}\n\n");

				while(number.IndexOf('-') != -1)
				{
					number = number.Remove(number.IndexOf('-'), 1);
				}

				Console.WriteLine($"Number after Removing '-':\n\t{number}\n\n");
				Console.WriteLine($"Matched Pattern: {number}");
			}else
			{
				Console.WriteLine($"Did not match pattern: {pattern}");
			}

			
		}
	}
}
