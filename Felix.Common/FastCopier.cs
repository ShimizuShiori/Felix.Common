using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Felix.Common
{
	public static class FastCopier
	{
		public enum Comparer
		{
			Time = 1,
			Length = 2,
			MD5 = 4,
			TimeAndLength = Time + Length
		}

		public enum Result
		{
			Created,
			Copied,
			Skipped
		}
	}
}
