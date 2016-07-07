# CSharp_Json
A small console application that demonstrates json manipulation using NewtonSoftJson & Javascript Serialzer. The app also demonstrates use of abstract classes, inheritance, generics, a custom observable list, and an INotifyCollectionChanged implementation that updates the UI when a change is made to the list.

Built using VS2015 Community

---
####Main Features
|Feature |Description |
|--------|------------|
|NewtonSoft.Json| Demonstrates 'JsonConvert.DeserializeObject' & 'JsonConvert.SerializeObject' |
|JavaScriptSerializer| Demonstrates 'JavaScriptSerializer.Deserialize' & 'JavaScriptSerializer.Serialize |
|DataContractJsonSerialization| Demonstrates 'DataContractJsonSerializer' to write to a MemoryStream object and then reads from from the MemoryStrem object using 'StreamReader'|
|Abstraction| Both NewtonSoft.Json & JavaScriptSerializer classes derive from 'JsonBase' abstract class and override 2 methods |
---

####Code Features
* Generics
* Abstract Classes & Inheritence
* INotifyCollectionChanged event handling
* File IO
* ObservableCollection(T)

####Overview
|Description|
|-----------|
| All examples use the Person model |
| Data is saved to 
The app allows you to manage 'members' in a list and save them to file.

The main program class displays the options for adding, removing and showing members. There is also another option for quitting the program. 

The 'Person' class holds the details of each member. 

The 'JsonBase' class is a generic abstract class that contains all the File IO methods, as well as the implementation for our custom list and INotifyCollectionChanged implementation. 

Both the 'JavascriptSerialization' & 'NewtonSoftSerialization' classes extend the 'JsonBase' class that contains the methods for serializing and de-serializing the json.

