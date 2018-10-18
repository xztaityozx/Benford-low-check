using System;
using System.Collections.Generic;
using System.Linq;

namespace BenfordLow
{
	internal class Program
	{
		private static void Main(string[] args) {
			var n = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
			var bf=new BenfordLow(n);
			for (int i = 0; i < n; i++) {
				bf.Add(Console.ReadLine());
			}

			bf.Show();
		}
	}

	public class BenfordLow {
		private readonly Map<char, int> map;
		private int N;

		public BenfordLow(int N) {
			map = new Map<char, int>();
			this.N = N;
		}

		public void Add(string str) {
			this.map[str[0]]++;
		}

		public void Show() {
			foreach (var item in map.OrderBy(x=>x.Key)) {
				Console.WriteLine($"{item.Key}: {item.Value}: {(double)item.Value/N * 100}");
			}
		}
	}

	public class Map<TKey, TValue> : Dictionary<TKey, TValue>
	{
		private readonly TValue Default = default(TValue);

		public Map(TValue def = default(TValue)) : base() {
			Default = def;
		}

		public new TValue this[TKey index] {
			get => TryGetValue(index, out var v) ? v : base[index] = Default;
			set => base[index] = value;
		}
	}
}
