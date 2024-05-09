﻿namespace TSM.WorkLogs.Infrastructure.Options;

internal sealed class PostgreOptions
{
	public const string SectionName = "Postgre";

	public string ConnectionString { get; set; } = string.Empty;
}
