#load nuget:?package=nunit&version=3.10.1.0
#tool nuget:?package=NUnit.ConsoleRunner&version=3.11.1
//#tool xunit.runner.console

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

Task("Default")
	.Does(() =>
	{
		Information("Hello World!");
	});

Task("Path")
	.IsDependentOn("Default")
	.Does(() =>
	{
		Information("Doing something else, that is dependent on printing Hello World.");
		Information($"Path is: {EnvironmentVariable("PATH")}");
	});

Task("Build")
	.Does(() =>
	{
		DotNetCoreBuild("", new DotNetCoreBuildSettings{ Configuration = configuration });
	});

Task("Test")
	.IsDependentOn("Build")
	.Does(() =>
	{
		var testSearchPath = $"**/bin/{configuration}/netcoreapp2.1/*Tests.dll";
		Information($"Searching for tests in {testSearchPath}");
		NUnit3(testSearchPath);
	});

RunTarget(target);
