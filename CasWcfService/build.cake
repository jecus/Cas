///////////////////////////////////////////////////////////////////////////////
//	Build
///////////////////////////////////////////////////////////////////////////////

Task("Build")
	.IsDependentOn("NuGet-Restore")
	.Does(() => {
    	Information("Building project...");
		//DotNetBuild("./CasWcfService.csproj");
		
	MSBuild("./CasWcfService.csproj", new MSBuildSettings()
  .WithProperty("OutDir", "./bin")
  .WithProperty("DeployOnBuild", "true")
  .WithProperty("WebPublishMethod", "Package")
  .WithProperty("PackageAsSingleFile", "true")
  .WithProperty("SkipInvalidConfigurations", "true"));

}).OnError(ex => {
    Error("Build Failed, throwing exception...");
    throw ex; 
});

Task("NuGet-Restore")
    .IsDependentOn("Clenup")
    .Does(() =>
    {
        NuGetRestore("D:/Work/GitCas/CAS.sln");
    });


///////////////////////////////////////////////////////////////////////////////
//	OTHER
///////////////////////////////////////////////////////////////////////////////

Task("Clenup")
	.Does(() => {
			CleanDirectories("./bin");
			CleanDirectories("./obj");	
		});
		
RunTarget("Build");		