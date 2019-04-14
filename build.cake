
#l "nuget:?package=Cake.igloo15.Scripts.Bundle.CSharp&version=2.0.2"

var target = Argument<string>("target", "Default");

AddSetup((d) => {
    d.Set("Markdown-Generator-Filter", "./dist/**/publish/igloo15*.dll");
});

AddTeardown((d) => {
    Information("Finished All Tasks");
});


Task("Pack")
    .IsDependentOn("CSharp-Bundle-Pack-All")
    .CompleteTask();    

Task("Default")
    .IsDependentOn("Pack")
    .CompleteTask();

Task("Deploy")
	.IsDependentOn("CSharp-Bundle-Push-All")
    .CompleteTask();

RunTarget(target);
