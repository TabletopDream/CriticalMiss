node('master') {
    stage('import') {
        try {
            checkout scm
        } catch(error) {
            //slacksend message:{env.BUILD_NUMBER}  color:'danger'
        }
    }
    
    stage('build') {
        try {
            dir('CriticalMiss') {
                bat 'dotnet restore CriticalMiss.sln'
                bat 'msbuild /t:clean,build CriticalMiss.sln'
            }
        } catch(error) {
            throw error
            //slacksend message: color:'danger'
        }
    }

    stage('analyze') {
        try {
            dir('CriticalMiss') {
                bat 'SonarQube.Scanner.MSBuild.exe begin /k:CriticalMissPipe'
                bat 'msbuild /t:rebuild CriticalMiss.sln'
                bat 'SonarQube.Scanner.MSBuild end'
            }
        } catch(error) {
            throw error
            //slacksend message: color:'danger'
        }
    }

    stage('test') {
        try {
            dir('CriticalMiss') {
                bat 'dotnet test'
            }
        } catch(error) {
            throw error
            //slacksend message: color:'danger'
        }
    }

    stage('package') {
        try {
            dir('CriticalMiss') {
                bat 'dotnet publish CriticalMiss.sln --output ../../Package'
            }
        } catch(error) {
            throw error
            //slacksend message: color:'danger'
        }
    }

    stage('deploy') {
        try {
            bat 'dotnet build ./CriticalMiss/CriticalMiss.sln /p:DeployOnBuild=true /p:PublishProfile=publish'
            bat '"C:\\Program Files (x86)\\IIS\\Microsoft Web Deploy V3\\msdeploy.exe" ' +
                '-verb:sync -source:iisApp="C:\\Program Files (x86)\\Jenkins\\workspace\\CriticalMiss\\Package\\" ' +
                '-dest:iisApp="Default Web Site/CriticalMiss",' +
                'computerName=https://ec2-18-221-176-158.us-east-2.compute.amazonaws.com:8172/msdeploy.axd,' +
                'username=Administrator,password="z5rmV!IARSFQReROgoPAU%%ur3oeb%%RM!",authType="Basic" ' +
                '-allowUntrusted -enableRule:AppOffline'
        } catch(error) {
            throw error
            //slacksend message: color:'danger'
        }
    }
}