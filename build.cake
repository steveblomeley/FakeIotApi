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
		var testProjects = GetFiles("**/*Tests.csproj");
        
		foreach(var project in testProjects)
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
