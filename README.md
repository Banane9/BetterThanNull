BetterThanNull
==============

Adds ways to make sure you get a not-null object and to indicate that your method might not return a value.

---------------------------------------------------------------------------------------------------------------------------------

##Usage##

To start, include a reference to the .dll you downloaded in the [release section](https://github.com/Banane9/BetterThanNull/releases) and add this to the top of your code file, before using the types like described below:

``` CSharp
using BetterThanNull;
```

####Definitely&lt;T&gt;####

If you declare a method's return type or a field/property as `Definitely<T>`, you tell the consumer that it will always contain a not null value.  
When you use it for a method argument's type, you tell the consumer that your method absolutely needs a not null value, and you don't have to worry about doing null checks!

``` CSharp
// Will definitely contain not null values.
private Definitely<MyObject> myField = new MyObject();

public Definitely<MyObject> MyProperty
{
    get { return myField; }
}


// Definitely doesn't work without a value.
public void DoSomething(Definitely<MyObject> myObject)
{
    Console.WriteLine(myObject.Value.ToString());
}
```

####Perhaps&lt;T&gt;####

If you declare a method's return type or a field/property as `Perhaps<T>`, you tell the consumer that it may or may not have a value.  
When you use it for a method argument's type, you tell the consumer that that argument is not required to have a value.

``` CSharp
// Might contain values.
private Perhaps<MyObject> myField;

public Perhaps<MyObject> MyProperty
{
    get { return myField; }
}


// Might return a value from an optional argument.
public Perhaps<string> DoSomething(Perhaps<MyObject> myObject)
{
    return myObject.Select(myObj => myObj.ToString());
}
```

##Known Problems##

* When `Definitely<T>` is used for a field in a class, the Value will be `default(T)` even though there's a parameterless constructor that throws an Exception. It seems to ignore the constructor in this case.  
Please feel free to send in any tips on how to circumvent the circumventing!

``` CSharp
// myField.Value will be null.
private Definitely<object> myField;
```

---------------------------------------------------------------------------------------------------------------------------------

##License##

#####[LGPL V2.1](https://github.com/Banane9/BetterThanNull/blob/master/LICENSE.md)#####
