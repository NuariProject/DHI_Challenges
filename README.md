# DHI_Challenges

Thank you for the opportunity. Below is the description of the homework I have completed. I focused on developing the **REST API**, and I did not have time to complete the **UI** part.

## Approach

### Main Layer Structure
This project is built using an **n-tier architecture** structure consisting of several main layers:

1. **DHI_Challenges.Models**: Contains definitions of models and entities used.
2. **DHI_Challenges.Services**: Provides business logic implementations.
3. **DHI_Challenges.UI** (Not completed): Planned to include the user interface.

I used a **Code First** approach to create entities and databases. Additionally, I implemented the **Unit of Work** pattern. This project uses an option with three schemas in a single database for better-organized data separation.

Initially, I wanted to use the **Clean Architecture** approach, as this structure provides more modular and cleaner code. However, I decided to use the **n-tier architecture** approach, with business logic not yet fully separated from the controller.

---

## Features

### User Management
Handles user data management, including storing, retrieving, and updating information.

#### Screenshots:
![User Feature 1](https://github.com/user-attachments/assets/5ed74f51-2d21-47ff-a50a-cfb0ed601a6e)
![User Feature 2](https://github.com/user-attachments/assets/d0a60ba1-7d4b-4b1c-9b3b-913ab67a0a7f)
![User Feature 3](https://github.com/user-attachments/assets/068a4040-4307-4ead-af7a-c7d9172242ee)
![User Feature 4](https://github.com/user-attachments/assets/406bb94c-1105-4b1b-9d97-d991e66d5353)
![User Feature 5](https://github.com/user-attachments/assets/225a494c-86f8-4521-a5a4-f3b2d118543e)
![User Feature 6](https://github.com/user-attachments/assets/a0984b05-650e-4599-a575-c70caa55b81a)

### Product Management
Provides APIs for product management, including adding, deleting, and updating product data.

#### Screenshots:
![Product Feature 1](https://github.com/user-attachments/assets/7dac037a-c84a-4d38-bd3e-f7046424e526)
![Product Feature 2](https://github.com/user-attachments/assets/c62d7c70-01bf-46d8-84ec-2153922b828d)
![Product Feature 3](https://github.com/user-attachments/assets/2362e3da-a950-4772-a3a7-4dc2b15d8722)
![Product Feature 4](https://github.com/user-attachments/assets/6b89e96e-9f46-4325-92a0-8b67fcc08f5c)
![Product Feature 5](https://github.com/user-attachments/assets/a53e788b-1816-43e7-8cae-79d40905320e)
![Product Feature 6](https://github.com/user-attachments/assets/8a3dc3b6-f17b-4276-952e-b34c4a8a8567)

### Transaction Management
Manages conducted transactions, including validation, storage, and reporting of transaction data.

#### Screenshots:
![Transaction Feature 1](https://github.com/user-attachments/assets/8ffdc898-9d7f-464c-8e93-cba4e9b37031)
![Transaction Feature 2](https://github.com/user-attachments/assets/e42e3de9-03cf-483d-8065-70aa8bacc46f)
![Transaction Feature 3](https://github.com/user-attachments/assets/80210777-aefc-4056-afd6-5b9aec679d7b)
![Transaction Feature 4](https://github.com/user-attachments/assets/465ba051-b068-41fc-8cf8-00369b8afb10)
![Transaction Feature 5](https://github.com/user-attachments/assets/45f7b206-f66b-4fb3-b44a-8b157c8bb6a8)

### UI (Not Completed)
This section is planned to provide a user interface to allow users easy access to existing features.

#### Screenshot:
![UI Design](https://github.com/user-attachments/assets/27e64e24-fdd0-43ad-a4ba-8b600b3090e1)

---

## Technologies Used
- **ASP.NET Core** for REST API development.
- **Entity Framework Core** with the **Code First** approach.
- **Unit of Work** as a design pattern for database transaction management.
- **SQL Server** as the database.
- **Swagger** for API documentation, created in a detailed and user-friendly manner.

---

## Development Plans
1. Separate business logic from controllers into the service layer for better modularity.
2. Complete the UI development.
3. Enhance API documentation in Swagger if needed.
4. Integrate authentication and authorization for data security.

---

## How to Run the Project

1. Clone the repository:
   ```bash
   git clone https://github.com/your-repository-url.git
   ```

2. Run migrations to create the database:
   ```bash
   dotnet ef database update
   ```

3. Run the application:
   ```bash
   dotnet run
   ```

4. Access API endpoints via Postman or other tools you use.

---

Thank you for your attention!

