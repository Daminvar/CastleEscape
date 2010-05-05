
using System;

namespace CastleEscape
{
	public class Clock
	{
		private DateTime snapshot;
		public Clock()
		{
			snapshot = DateTime.Now;
		}
		
		public void Reset()
		{
			snapshot = DateTime.Now;
		}
		
		public TimeSpan ElapsedTime
		{
			get { return DateTime.Now - snapshot; }
		}
		
		public DateTime TotalTime
		{
			get { return DateTime.Now; }
		}
	}
}
