# What is Xamarin?

Xamarin allows us to build native mobile applications for the major mobile platforms, leveraging C# and .NET knowledge.

Xamarin.Android and Xamarin.iOS are both part of Native Xamarin. In Native Xamarin we share about 60% of our code between platforms - so 40% of our code will have to be written uniquely for each device operating system: iOS, Android, Windows. In contrast to Native Xamarin, we also have Xamarin.Forms which allows us to write all of our code once and that same code will work on both Android and iOS.

***

Xamarin joins .Net and the devices functionality meaning that you can write C# code using all of the .NET standard libraries that can also use the phones various capabilities including: Flashlight, Maps, Camera, and Sensors.

How can .NET run on an Andrid device? This is because we're not really using .NET, but instead Mono. Mono was the original open-source version of .NET created many years ago by the same people who created Xamarin. What happens is a copy of the Mono framework will be compiled together with our application and it will be used as a runtime. The Mono runtime on the Android Device.

***

In this class you'll write C# Logic to create the UI for the application, then all the code will be compiled with the Mono framework into an Android APK package. That package contains all the device needs to run your application. This APK will be able to be distributed on the Google Store for the world to see.
