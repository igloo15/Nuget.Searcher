#tool "nuget:?package=GitVersion.CommandLine"
#addin nuget:?package=Cake.Git
#addin "Cake.Incubator"

var target = Argument<string>("target", "Default");

GitVersion result;
DotNetCoreMSBuildSettings MSBuildSettings;

Setup((c) =>
{
});

Teardown((c) =>
{
    // Executed AFTER the last task.
    Information("Finished running tasks.");
});

Task("Update-Version")
	.Does(() => {

		Information("Calculating Semantic Version...");

        var fullBranchName = "refs/"+GitDescribe(".", false, GitDescribeStrategy.All);

		Environment.SetEnvironmentVariable("Git_Branch", fullBranchName, EnvironmentVariableTarget.Process);
        		
		result = GitVersion(new GitVersionSettings {
					UpdateAssemblyInfo = true,
					OutputType = GitVersionOutput.Json,
                    Branch = fullBranchName,
					NoFetch = true
				});

		var cakeVersion = typeof(ICakeContext).Assembly.GetName().Version.ToString();

        MSBuildSettings = new DotNetCoreMSBuildSettings()
                            .WithProperty("Version", result.LegacySemVerPadded)
                            .WithProperty("AssemblyVersion", result.MajorMinorPatch)
                            .WithProperty("FileVersion",  result.MajorMinorPatch)
                            .WithProperty("AssemblyInformationalVersion", result.InformationalVersion);

		Information($"Cake Version : {cakeVersion}");
        Information("");
        Information("GitVersion:");
        Information(result.Dump());
	});

Task("Restore")
    .Does(() => {
        DotNetCoreRestore("./src/Nuget.Searcher.sln");
    });

Task("Build")
    .IsDependentOn("Restore")
    .IsDependentOn("Update-Version")
	.Does(() => {
        DotNetCoreBuild("./src/Nuget.Searcher.sln", new DotNetCoreBuildSettings {
            Configuration = "Release",
            MSBuildSettings = MSBuildSettings
        });
    });

Task("Pack")
    .IsDependentOn("Build")
    .Does(() => {
        DotNetCorePack("./src/Nuget.Searcher.sln", new DotNetCorePackSettings {
            NoBuild = true,
            Configuration = "Release",
            OutputDirectory = "./packages.local",
            MSBuildSettings = MSBuildSettings
        });
    });

Task("Publish")
    .IsDependentOn("Pack")
    .Does(() => {
        foreach(var nupkgFile in GetFiles("./packages.local/*.nupkg"))
        {
            Information($"Pushing Package {nupkgFile}");
            NuGetPush(nupkgFile, new NuGetPushSettings {
                Source = "https://api.nuget.org/v3/index.json"
            });
            Information($"Succesfully Pushed Package {nupkgFile}");
        }
    })
    .OnError((e) => {
        Error(e.ToString());
    });

    

Task("Default")
    .IsDependentOn("Build");

Task("Deploy")
	.IsDependentOn("Publish");

RunTarget(target);
