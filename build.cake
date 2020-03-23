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

Task("AllTests")
	.IsDependentOn("Build")
	.Does(() => 
	{
		//TODO: Experiment: Try directly plugging a path into DotNetCoreTest, eg: "**/bin/{configuration}/netcoreapp2.1/*Tests.dll"
		//as this method stops if it finds a failing test in the current project (i.e. subsequent test projects are not run)
		var projects = GetFiles("**/*Tests.csproj");
        
		foreach(var project in projects)
        {
            DotNetCoreTest(
                project.FullPath,
                new DotNetCoreTestSettings()
                {
                    Configuration = configuration,
                    NoBuild = true
                });
        };
	});

RunTarget(target);
