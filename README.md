# CSharp_Json
A small console application that demonstrates how to read / write json files using NewtonSoft Json &amp; Javascript Serialzer. Also demonstrates use of abstract classes, inheritance, generics, a custom observable list, an INotifyCollectionChanged implementation that updates the UI when a change is made to the list.

###Technologies###
* VS2015
* C#
* Json

###Code Features###
* Generics
* Abstract Classes & Inheritence
* INotifyCollectionChanged implementation
* File IO
* Custom Observable List

###Overview###
The app allows you to add new 'members' to a list. 

The main program class displays the options for adding, removing and showing members. There is also another option for quitting the program. 

The 'Person' class holds the details of each member. 

The 'JsonBase' class is a generic abstract class that contains all the File IO methods, as well as the implementation for our custom list and INotifyCollectionChanged implementation. 

Both the 'JavascriptSerialization' & 'NewtonSoftSerialization' extend the 'JsonBase' class and contain the methods for serializing and de-serializing the json.

