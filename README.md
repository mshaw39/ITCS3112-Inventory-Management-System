# Inventory-Management-System
A generic inventory management system that users can use to track item inventory from a JSON file.

## Build/Run Instructions
**Required Version:** net10.0
1) Load the project using your desired IDE (JetBrains Rider for best results).
2) Press the run button on `Program.cs` to build/run the project.
3) A new terminal will run. The user will be prompted to enter a json file path (default json/file path is available).
4) User will choose what user/role they would like to login to.
5) The main menu under that user will become available to perform the necessary tasks as necessary. 
6) When finished, the user can save their changes to the json file and exit the program.

## OOP Feature Documentation
| OOP Feature  | File Name | Line Numbers | Reasoning/Purpose
| ------------- | ------------- | ------------- | ------------- |
| Inheritance  | Customer.cs  | 3-9  | Customer inherits from User, sharing its main attributes, but changing the status value.  |
| Inheritance  | Manager.cs  | 3-9  | Manager inherits from User, sharing its main attributes, but changing the status value.  |
| Interface  | IUserService.cs  | All  | Defines CRUD operations for users to be implemented by other classes.  |
| Interface  | IFileService.cs  | All  | Defines reading/saving operations for a json file that can be implemented in Program.cs.  |
| Interface  | IItemRepository.cs  | All  | Defines CRUD operations for items to be implemented in its service class.  |
| Polymorphism  | SMSNotifier.cs  | 5-9  | Overrides the abstract SendNotification method to produce the accurate notification type.  |
| Polymorphism  | Program.cs  | 48-54  | User objects are assigned instances of derived classes at runtime (Manager, Employee, and Customer).  |
| Access Modifiers  | OrderService.cs  | All  | The class is public to allow other classes interaction with the OrderService class when necessary. _notifier is private readonly since only the OrderService class should be reading the information from the Notifier service class, when calling upon the OrderService class.  |
| Struct  | NotificationMessage.cs  | 3-18  | Creates a notification message by putting a user's message together with the current date/time.  |
| Enum  | ItemTypeEnum.cs  | All  | Defines the type of item that an item object can be.  |
| Data Structure  | ItemRepository.cs  | 7  | Creates an item dictionary to store/retrieve items within the repository.  |
| Console I/O  | Program.cs  | 63-109  | Asks the user for which user/role they would like to login to, and displays the corresponding menu.  |

## Design Pattern Documentation
| Pattern Name  | Category | File Name | Line Numbers | Rationale
| ------------- | ------------- | ------------- | ------------- | ------------- |
| Strategy  | Behavioral  | Notifier.cs  | 6-11  | Allows different notifier algorithms to be interchangable with each other at runtime.  |
| Template  | Behavioral  | Notifier.cs  | 11  | Allows other service classes to override the abstract method.  |
| Singleton  | Creational  | ItemRepository.cs  | 11-26  | Ensures only one instance of the item repository exists in memory. This prevents duplicate or out-of-sync data.  |

## Design Decisions

**Main Components**\
Our project is built around four directories: Domain, Repositories, Services, and Contracts. The Domain directory holds all of the base classes/enums. The Repositories directory holds all of the repositories used. The Services directory holds all of the service classes needed to run our project. The Contracts directory holds all of the interface classes that initialize the service/repository classes. Each layer can communicate with each other through interfaces rather than the concrete classes. This keeps our project easy to follow and does not violate the Dependency Inversion Principle in SOLID.   

**Key Abstractions**
* Interfaces
    * Defines a skeleton for class implementation instead of relying on concrete implementation
* User Class
    * The Employee, Manager, and Customer classes inherit from the User class
* Notifier Class
    * Both a Template Method and Strategy pattern
    * Defines a notification skeleton with other classes implementing their own message strategy
* ItemRepository
    * Uses the Singleton design pattern
    * Only allows one object to exist in memory, preventing duplicate or out-of-sync data

**Trade Offs**\
Using interfaces does add more files within the project, but it makes it easier to understand the implementation behind the classes and provide extension when necessary. 