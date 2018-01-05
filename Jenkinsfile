node('master') {
    stage('import') {
        try {
            git url:'https://github.com/TabletopDream/CriticalMiss.git'
        } catch(error) {
            slacksend message:{env.BUILD_NUMBER}  color:'danger'
        }
    }
    
    stage('build') {
        try {
            dir('CriticalMiss') {
                bat 'nuget restore'
                bat 'msbuild /t:build, clean CriticalMiss.sln'
            }
        } catch(error) {
            slacksend message: color:'danger'
        }
    }

    stage('analyze') {
        try {
            dir('CriticalMiss') {
                bat 'C:\\Program Files\\SonarQube\\SonarQube.Scanner.MSBuild.exe begin /k:CriticalMissPipe'
                bat 'msbuild /t:rebuild CriticalMiss.sln'
                bat 'C:\\Program Files\\SonarQube\\SonarQube.Scanner.MSBuild.exe end'
            }
        } catch(error) {
            slacksend message: color:'danger'
        }
    }

    stage('test') {
        try {

        } catch(error) {
            //slacksend message: color:'danger'
        }
    }

    stage('package') {
        try {

        } catch(error) {
            //slacksend message: color:'danger'
        }
    }

    stage('deploy') {
        try {

        } catch(error) {
            //slacksend message: color:'danger'
        }
    }
}