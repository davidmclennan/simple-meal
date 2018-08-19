# Simple Meal - Xamarin.Forms
A simple recipe app developed in Xamarin.Forms and using data from [TheMealDB API](https://www.themealdb.com/api.php).

This app has been made possible using:
* [FreshMVVM](https://github.com/rid00z/FreshMvvm)
* [FFImageLoading](https://github.com/luberda-molinet/FFImageLoading)
* [CarouselView.FormsPlugin](https://github.com/alexrainman/CarouselView)
* [Newtonsoft.Json](https://www.newtonsoft.com/json)
* [PropertyChanged.Fody](https://github.com/Fody/PropertyChanged)
* [xUnit](https://xunit.github.io/)
* [Moq](https://github.com/moq/moq4)

## Android
![](Images/demo.gif)
Users can find recipes by category with images, videos, instructions and ingredients provided.

To be implemented:
* Search recipes by name
* Save liked recipes

## iOS
I do not currently own a setup to enable testing on iOS. However, as this app has been created in Xamarin.Forms with the goal of keeping as little code platform specific as possible, only some cosmetic iOS specific changes should be required.