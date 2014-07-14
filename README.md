BetterThanNull
==============

Adds ways to make sure you get a not-null object and to indicate that your method might not return a value.

------------------------------------------------------------------------------------------------------------------------------------

##Usage##

To start, include a reference to the .dll you downloaded in the [release section](https://github.com/Banane9/BetterThanNull/releases) and add this to the top of your code file, before using the types like described below:

``` CSharp
using BetterThanNull;
```

####Definitely<T>####

If you declare a method's return type or a field/property as `Definitely<T>`, you tell the consumer that it will always contain a not null value.

And when you declare a method argument's type as `Definetely<T>`, you tell the consumer that your method absolutely needs a not null value, and you don't have to worry about doing null checks!

##License##

#####[GPL V2](https://github.com/Banane9/BetterThanNull/blob/master/LICENSE.md)#####
