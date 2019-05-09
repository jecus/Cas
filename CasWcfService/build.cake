///////////////////////////////////////////////////////////////////////////////
//	Build
///////////////////////////////////////////////////////////////////////////////

Task("Build")
	.IsDependentOn("Clenup")
	.Does(() => {
    	Information("Building project...");
		  DotNetBuild("./CasWcfService.csproj");
		

}).OnError(ex => {
    Error("Build Failed, throwing exception...");
    throw ex; 
});


Task("Publish")
	.IsDependentOn("Clenup")
	.Does(() => {
    	Information("Publish project...");
		
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


///////////////////////////////////////////////////////////////////////////////
//	OTHER
///////////////////////////////////////////////////////////////////////////////

Task("Clenup")
	.Does(() => {
			CleanDirectories("./bin");
			CleanDirectories("./obj");	
		});
		
RunTarget("Build");		