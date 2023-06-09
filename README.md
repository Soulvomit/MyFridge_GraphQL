MyFridge System Documentation

GOAL (this is an unfinisehd product and this text decribes the goal of the project):

MyFridge System is an innovative and user-friendly solution to manage and optimize your fridge's inventory. It simplifies the tedious task of tracking grocery items, ensuring you never run out of essential ingredients or let food go to waste:

1. Fridge Inventory Manager
The Fridge Inventory Manager allows users to keep track of their fridge's contents, including item names, quantities, and expiration dates. Users can add, update, or delete items and view a list of all items in their fridge.

2. Recipe Recommendation Engine
The Recipe Recommendation Engine suggests recipes based on the available ingredients in the user's fridge. It helps users discover new meal ideas, minimize food waste, and optimize their grocery shopping.

3. Grocery Shopping Assistant
The Grocery Shopping Assistant generates a dynamic shopping list based on the user's fridge inventory and their preferred recipes. It helps users plan their grocery shopping more efficiently and avoid purchasing unnecessary items.

4. Expiration Date Reminder
The Expiration Date Reminder sends notifications to users when items in their fridge are about to expire. This feature helps users consume their perishable goods in time and minimize food waste.

5. User Authentication and Authorization
The User Authentication and Authorization feature allows users to create accounts, log in, and manage their own fridge inventory, recipes, and shopping lists securely.

Back-end technologies used:
  - .Net
  - Azure
  - MSSQL Server
  - Entity Framwork
  - Web-API (REST)
  - GraphQL (HotChocolate)

Front-end technoligies:
  - .Net
  - Xaml
  - MAUI

Data_Model: 

The Data Model project is responsible for defining and managing the database schema and interactions. By utilizing Entity Framwork, a powerful and flexible Object Relational Mapper (ORM), it enables seamless communication between the application and the database. This project contains models for essential entities, such as users, fridge items, and recipes, ensuring proper data storage and retrieval. Additionally, it handles database migrations to support the evolution of the application schema over time. Overall, the Data Model project serves as the foundation for the MyFridge System, facilitating efficient and organized data management.

Data_Lbrary:

The Data Library project serves as an abstraction layer between the application logic and the Data Model, simplifying data access and manipulation. It consists of Entity Framwork functions that streamline database interactions, allowing other components of the system to work seamlessly with the underlying data. The Data Library ensures that business logic remains separate from data access, promoting code readability and maintainability. By providing a consistent and easy-to-use interface, it enables testability and focuses on building robust features without getting entangled in the complexities of database operations. It also provides a mechanism to create seed data for the database.

Data_Interface:

The Data Interface project within MyFridge System is a critical component that facilitates communication between the frontend and the backend, acting as a bridge for data exchange. It exposes well-defined APIs to enable smooth interaction with the Data Model and Data Library, allowing the frontend to access and manipulate data as needed. Built using a .Net Web-API, the Data Interface ensures a clean and modular architecture.

[NEW: Key features of the Data Interface include a GraphQL API for managing fridge inventory, recipe recommendations, grocery shopping lists, and user authentication. By implementing standard GraphQL methods, such as Queries, Mutations and Subscriptions, it supports a wide range of operations for a seamless user experience. The Data Interface also handles error and exception handling, providing meaningful responses to the frontend in case of issues.]

[OBSELETE: Key features of the Data Interface include REST APIs for managing fridge inventory, recipe recommendations, grocery shopping lists, and user authentication. By implementing standard HTTP methods, such as GET, POST, PUT, and DELETE, it supports a wide range of operations for a seamless user experience. The Data Interface also handles error and exception handling, providing meaningful responses to the frontend in case of issues.]

Client_Model:

The Client Model project serves as a representation of the Data Model tailored for client-server communication. It essentially converts the Data Model into a format that is easily consumable and transferable between the frontend and the backend. By providing a consistent structure for data exchange, it ensures seamless communication between the client and the web service. The Client Model acts as an intermediary layer, handling data conversion and validation, which simplifies interactions with the Data Interface.

Client_Library:

This library abstracts the complexity of making API calls, simplifying the process for the frontend components. By utilizing the Client Model, the library ensures data consistency and proper formatting while sending and receiving data from the backend. The Client Library promotes code reusability and maintainability by centralizing API interactions, allowing developers to focus on building the frontend without worrying about low-level data exchange details. It also handles client side caching so calls are not always made to the Data Interface. 

Client_Interface:

The Client Interface is responsible for creating a user-friendly and visually appealing frontend that interacts with the backend services through the Client Library. It utilizes modern web technologies, such as .Net MAUI, to build a responsive and dynamic user interface that offers an engaging user experience. The interface is designed with a modular approach, using reusable components to ensure maintainability and scalability.

It encompasses various key features, including inventory management, recipe recommendations, grocery shopping assistance, and expiration date reminders. It offers seamless integration with the backend services, making use of the Client Library to interact with the Data Interface efficiently. Additionally, the Client Interface provides user authentication and authorization to ensure secure access to the application's features.



