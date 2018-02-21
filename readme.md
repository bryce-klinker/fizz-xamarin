# Important

If you are on a Mac make sure you have java 8 installed. Java 9 will result in an error such as:

```
/Library/Frameworks/Mono.framework/External/xbuild/Xamarin/Android/Xamarin.Android.Common.targets(2,2): Error MSB4018: The "AdjustJavacVersionArguments" task failed unexpectedly.
System.NullReferenceException: Object reference not set to an instance of an object
  at Xamarin.Android.Tasks.AdjustJavacVersionArguments.Execute () [0x00124] in <a9f581d0c2a2409a88d42cf1050f6508>:0 
  at Microsoft.Build.BackEnd.TaskExecutionHost.Microsoft.Build.BackEnd.ITaskExecutionHost.Execute () [0x00023] in /Users/builder/data/lanes/4992/mono-mac-sdk/external/bockbuild/builds/msbuild-15.4/src/Build/BackEnd/TaskExecutionHost/TaskExecutionHost.cs:631 
  at Microsoft.Build.BackEnd.TaskBuilder+<ExecuteInstantiatedTask>d__26.MoveNext () [0x0022d] in /Users/builder/data/lanes/4992/mono-mac-sdk/external/bockbuild/builds/msbuild-15.4/src/Build/BackEnd/Components/RequestBuilder/TaskBuilder.cs:787  (MSB4018) (Fizzly.Droid)
```

If you have java9 installed as your default java version you will need to tell VS where to look for java8:

## Visual Studio For Mac

1. Open VS for Mac
1. Go to Preferences
1. Go to Projects > SDK Locations > Android
1. Click on the 'Locations' Tab
1. Change the Java SDK Location to:
  1. `/Library/Java/JavaVirtualMachines/jdk1.8.0_162.jdk/Contents/Home`
1. Now your Android project should build

## NUnit Version

*Xamarin.UITest is not compatible with NUnit 3.x*
*DO NOT UPGRADE NUnit in UITest Projects* 
