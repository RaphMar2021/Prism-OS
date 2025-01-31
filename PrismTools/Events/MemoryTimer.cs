﻿using static Cosmos.HAL.Global;
using Cosmos.Core.Memory;

namespace PrismTools.Events
{
	public static class MemoryTimer
	{
		/// <summary>
		/// Initializes the memory cleanup timer, collects loose memory on the heap every 2 seconds.
		/// </summary>
		public static void Init()
		{
			PIT.RegisterTimer(new(() => Heap.Collect(), 2000000000, true));
		}
	}
}