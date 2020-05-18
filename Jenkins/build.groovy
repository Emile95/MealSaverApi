def getParamFromFile(path) {
	dict = [:];
	str = readFile path;
	str.readLines().each { p ->
		param = p.split("=");
		dict[param[0]] = param[1];
	};
	return dict;
}

properties(
    [
        parameters([
			string(defaultValue: 'http://localhost:5001/', name: 'APP_URL'),
		])
    ]
)

node {
	cleanWs();

	def packagePath = "WebApi\\bin\\Release\\netcoreapp2.1\\publish\\";
	def version;

    
    stage("Fetch repository"){
        git branch: "${BRANCH_NAME}", credentialsId: 'a38db37b-11d9-41fa-9348-cbbb25a8dec8', url: 'https://github.com/Emile95/VimoWebApi';
		version = getParamFromFile("version.txt");
		currentBuild.displayName = "#${BUILD_NUMBER}_${version['MAJOR']}.${version['MINOR']}.${version['PATCH']}.${version['BUILD']}";
    }
    
    stage("Compile"){
        bat("dotnet restore");
        bat("dotnet publish --configuration Release");
		writeFile file: "${packagePath}\\ipAddress.txt", text: "${APP_URL}";
    }

    stage("Other") {
		bat("copy version.txt ${packagePath}");
    }
	
    archiveArtifacts "WebApi/bin/Release/netcoreapp2.1/publish/**";
}