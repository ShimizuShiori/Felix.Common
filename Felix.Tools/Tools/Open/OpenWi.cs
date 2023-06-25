﻿using Felix.Common;
using Felix.Tools.Attributes;
using System.Text.RegularExpressions;

namespace Felix.Tools.Tools.Open
{
	[TextTool("WI", "Open", Reg)]
	class OpenWi : ITool
	{
		public const string Reg = @"(WI)\d{8}";
		public void Start()
		{
			var match = Regex.Match(AppContext.SelectedText, Reg);
			var id = match.Groups[0];
			var type = match.Groups[1];
			string uri = $"edient:Command=ShortCode&Id={id}&Type={type}";
			UrlHelper.Open(uri);
		}
	}
}