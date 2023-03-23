﻿using Felix.Common;
using Felix.Tools.Attributes;

namespace Felix.Tools.Tools.Runs
{
	[Tool("DevLogin", "Glow")]
	class RunDevLogin : ITool
	{
		public void Start()
		{
			UrlHelper.Open("https://localhost/Glow/dev/login");
		}
	}
}
