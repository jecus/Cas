
var target = Argument("target", "Build");
///////////////////////////////////////////////////////////////////////////////
//	Build
///////////////////////////////////////////////////////////////////////////////

Task("Build")
	.IsDependentOn("Clenup")
	.Does(() => {
    	Information("Publish project...");
		  //DotNetBuild("./CasWcfService.csproj", settings => settings.SetConfiguration("Release").WithProperty("OutDir", "./bin/Release"));

	MSBuild("./CasWcfService.csproj", new MSBuildSettings()
  .WithProperty("OutDir", "./bin/Publish")
  .WithProperty("DeployOnBuild", "true")
  .WithProperty("WebPublishMethod", "Package")
  .WithProperty("PackageAsSingleFile", "true")
  .WithProperty("SkipInvalidConfigurations", "true"));

}).OnError(ex => {
    Error("Build Failed, throwing exception...");
    throw ex; 
});


///////////////////////////////////////////////////////////////////////////////
//	OTHER
///////////////////////////////////////////////////////////////////////////////

Task("Clenup")
	.Does(() => {
			CleanDirectories("./bin");
			CleanDirectories("./obj");	
		});
		
RunTarget(target);		