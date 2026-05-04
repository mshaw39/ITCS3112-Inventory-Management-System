# Inventory-Management-System
A generic inventory management system that users can use to track item inventory from a JSON file.

## Build/Run Instructions
1) Press the run button to build/run the project.
2) A new terminal will run. The user will be prompted to enter a json file path (default json/file path is available).
3) User will choose what user/role they would like to login to.
4) The main menu under that user will become available to perform the necessary tasks as necessary. 
5) When finished, the user can save their changes to the json file and exit the program.

## OOP Feature Documentation
| OOP Feature  | File Name | Line Numbers | Reasoning/Purpose
| ------------- | ------------- | ------------- | ------------- |
| Inheritance  | Customer.cs  | 3-9  | Customer inherits from User, sharing its main attributes, but changing the status value.  |
| Inheritance  | Manager.cs  | 3-9  | Manager inherits from User, sharing its main attributes, but changing the status value.  |
| Interface  | IUserService.cs  | All  | Defines CRUD operations for users to be implemented by other classes.  |
| Interface  | IFileService.cs  | All  | Defines reading/saving operations for a json file that can be implemented in Program.cs.  |
| Interface  | IItemRepository.cs  | All  | Defines the beginning CRUD operations for items to be implemented in its service class.  |
| Polymorphism  | SMSNotifier.cs  | 5-9  | Overrides the abstract SendNotification method to produce the accurate notification type.  |
| Polymorphism  | Program.cs  | 48-60  | User variable is dynamically assigned instances of derived classes (Manager, Employee, and/or Customer).  |
| Struct  | NotificationMessage.cs  | 3-18  | Creates a notification message by putting a user's message together with the current date/time.  |
| Enum  | ItemTypeEnum.cs  | All  | Defines the type of item that an item object can be.  |
| Data Structure  | ItemRepository.cs  | 7  | Creates an item dictionary to store/retrieve items within the repository.  |
| Console I/O  | Program.cs  | 63-109  | Asks the user for which user/role they would like to login to, and displays the corresponding menu.  |

## Design Pattern Documentation
| Pattern Name  | Category | File Name | Line Numbers | Rationale
| ------------- | ------------- | ------------- | ------------- | ------------- |
| Strategy  | Behavioral  | Notifier.cs  | 6-11  | Allows different notifier algorithms to be interchangable with each other at runtime.  |
| Template  | Creational  | Notifier.cs  | 11  | Allows other service classes to override the abstract method.  |

## SOLID Principles
Our project made sure none of the primary SOLID principles were violated. One example is we segregated interfaces to make sure that classes do not implement methods that are not necessarily for it. The ICustomerService and IEmployeeService interfaces are separate, not allowing customers to access employee methods. Another example is the open/closed principle can be used if another notifier algorithm needed to be created. No existing code has to be updated, only a new interface and service class inheriting from the notifier template. 

One area that could be factored to establish better principles is the UserService. Regular users might not necessarly need to remove/update other users and could be seen as a method for the ManagerService. 

## Individual Reflection
**Matthew Shaw**
* What were your primary contributions to the project?
    - My primary contributions to the project were the user and item implementation, updating the README.md file, helping with the UML creation, and coming up with our idea for the project. 
* What technical or design concept do you now understand more deeply?
    - The technical or design concept I now understand more deeply is the strategy design. I originally thought it was a different way to do the factory method since they are very similar. Now I know that it incorporates the use of abstract classes and methods with overriding methods. 
* How did collaboration influence your team’s success or challenges?
    - Collaboration influenced my team's success by allowing all of us to work at our own pace and assigning tasks to our own strengths. 
* If given more time, what would you change or extend?
    - If given more time, I would extend the login feature to be more secure by creating a password hash and comparing the user's input to that hash. 

**Member 2**
* What were your primary contributions to the project?
* What technical or design concept do you now understand more deeply?
* How did collaboration influence your team’s success or challenges?
* If given more time, what would you change or extend?

**Member 3**
* What were your primary contributions to the project?
* What technical or design concept do you now understand more deeply?
* How did collaboration influence your team’s success or challenges?
* If given more time, what would you change or extend?
