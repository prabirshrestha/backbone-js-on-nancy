var njake = require('./src/njake'),
	msbuild = njake.msbuild,
	nuget = njake.nuget;

msbuild.setDefaults({
	version: 'net4.0',
	processor: 'x86',
	Configuration: ['Release']
})


task('default', ['clean', 'build'])

task('build', function () {
	msbuild({
		file: 'src/BackboneJsOnNancy.sln',
		targets: ['Build']
	});
});

task('clean', function () {
	msbuild({
		file: 'src/BackboneJsOnNancy.sln',
		targets: ['Clean']
	})
})
