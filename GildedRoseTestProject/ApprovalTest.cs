using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;
using GildedRose;
using System.Linq;

namespace GildedRoseTestProject
{
	public class ApprovalTest
	{
		[Fact]
		public void ThirtyDays()
		{
			var lines = File.ReadAllLines("ThirtyDays.txt");

			StringBuilder fakeoutput = new StringBuilder();
			Console.SetOut(new StringWriter(fakeoutput));
			Console.SetIn(new StringReader("a\n"));

			Program.Main(new string[] { });
			String output = fakeoutput.ToString();

			var outputLines = output.Split('\n');
			
			for (var i = 0; i < outputLines.Length; i++)
			{
				outputLines[i] = outputLines[i].TrimEnd(Environment.NewLine.ToCharArray());
			}

			for (var i = 0; i < Math.Min(lines.Length, outputLines.Length); i++)
			{
				Assert.Equal(lines[i], outputLines[i]);
			}
		}
	}
}
