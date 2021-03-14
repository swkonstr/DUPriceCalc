using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp4.Models
{
    public class Factory
    {
		public Dictionary<string, Recipe> Dict;

		public Factory(Recipe[] Array)
		{
			Dict = new Dictionary<string, Recipe>();
			foreach (Recipe r in Array)
			{
				Dict.Add(r.Name, r);
			}
		}

		public string GetType(string s)
		{
			return Dict[s].Type;
		}

		public double GetOutput(string s)
		{
			return Dict[s].Output;
		}

		public Dictionary<string, double> GetIngradients(string s)
		{
			Recipe r = Dict[s];
			return r.Input;
		}

		public void GetOreIngradients(string s)
		{
			Dictionary<string, double> a = GetIngradients(s);

			while (HaveIngradients(a))
			{
				foreach (KeyValuePair<string, double> keyValue in a)
				{
					if (GetIngradients(keyValue.Key).Keys.Count > 0)
					{
						Dictionary<string, double> b = GetIngradients(keyValue.Key);
						b = MultiplierValues(b, 1 / GetOutput(keyValue.Key) * keyValue.Value);
						var c = a.Concat(b).GroupBy(item => item.Key).Select(sumitem => new KeyValuePair<string, double>(sumitem.Key, sumitem.Sum(item => item.Value))).ToDictionary(x => x.Key, x => x.Value);
						c.Remove(keyValue.Key);
						a = c;
						break;
					}
				}
			}
			a = CeilingValues(a);


			double sum = 0;
			foreach (KeyValuePair<string, double> keyValue in a)
			{
				sum = sum + 1;//Price[keyValue.Key] * keyValue.Value; 
			}
			Console.WriteLine("Себестоимость {0}: {1}", s, sum);
		}

		// Если какой-то инградиент содержит непустой рецепт True
		public bool HaveIngradients(Dictionary<string, double> a)
		{
			foreach (KeyValuePair<string, double> keyValue in a)
			{
				if (GetIngradients(keyValue.Key).Keys.Count > 0)
				{
					return true;
				}
			}

			return false;
		}

		// Печать массива
		public void PrintDict(Dictionary<string, double> a)
		{
			foreach (KeyValuePair<string, double> keyValue in a)
			{
				Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
			}
		}

		// Умножаем кол-во инградиента
		public Dictionary<string, double> MultiplierValues(Dictionary<string, double> a, double q)
		{
			Dictionary<string, double> b = new Dictionary<string, double>();
			foreach (KeyValuePair<string, double> keyValue in a)
			{
				b.Add(keyValue.Key, keyValue.Value * q);
			}
			return b;
		}

		// Округляем итоговый рецепт
		public Dictionary<string, double> CeilingValues(Dictionary<string, double> a)
		{
			Dictionary<string, double> b = new Dictionary<string, double>();
			foreach (KeyValuePair<string, double> keyValue in a)
			{
				b.Add(keyValue.Key, Math.Ceiling(keyValue.Value));
			}
			return b;
		}
	}
}

