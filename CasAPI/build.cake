///////////////////////////////////////////////////////////////////////////////
// VARIABLES
///////////////////////////////////////////////////////////////////////////////

var target = Argument("target", "Build");
const string PUBLISH_DIRECTORY = "published";
var configuration = Argument("configuration", "Debug");


///////////////////////////////////////////////////////////////////////////////
//	BUILDS
///////////////////////////////////////////////////////////////////////////////

Task("Build")
	.IsDependentOn("Clenup")
	.Does(() => {
			// https://cakebuild.net/api/Cake.Common.Tools.DotNetCore/DotNetCoreAliases/8E8365A3
		     var settings = new DotNetCorePublishSettings
			 {
				 Framework = "netcoreapp2.2",
				 // https://docs.microsoft.com/ru-ru/dotnet/core/rid-catalog
				 Runtime = "win10-x64", 
				 Configuration = configuration,
				 OutputDirectory = PUBLISH_DIRECTORY,
				 NoRestore = false,
				 NoBuild = false,
				 SelfContained = false
			 };

			DotNetCorePublish("./", settings);
		});

Task("Publish")
	.IsDependentOn("Build")
	.IsDependentOn("Artifact::Publish");




///////////////////////////////////////////////////////////////////////////////
//	OTHER
///////////////////////////////////////////////////////////////////////////////

Task("Clenup")
	.Does(() => {
			CleanDirectories("./bin");
			CleanDirectories("./obj");
			CleanDirectories(PUBLISH_DIRECTORY);
		});

Task("Artifact::Publish")
	.WithCriteria(TeamCity.IsRunningOnTeamCity)
	.Does(() => {
		TeamCity.PublishArtifacts("GitCas\\CasAPI\\" + PUBLISH_DIRECTORY);
	});


RunTarget(target);