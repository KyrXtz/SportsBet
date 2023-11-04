# SportsBet: A Higly-Available Resilient Betting Technology Solution

<p align="center">
  <img src="https://github.com/KyrXtz/SportsBet/blob/master/Images/1.jpg" width="400" />
</p>

SportsBet serves as the foundation for a dynamic backend platform that seamlessly integrates provider data and statistics, delivering a user-friendly experience while simultaneously remaining business competitive. It harnesses the capabilities of .NET 7 and leverages a robust Hexagonal/Onion architecture with microservices at its core.
## Solution features
<p align="center">
  <img src="https://github.com/KyrXtz/SportsBet/blob/master/Images/5.png" width="200" />
</p>

SportsBet's backend isn't just about functionality; it embodies **principled engineering practices**. Beneath the code, you'll discover principles derived from **Domain Driven Design**, **Clean Code**, and **CQRS**, thoughtfully organized and separated. The design strongly adheres to the timeless **SOLID** and **DRY** principles, resulting in a codebase that is both robust and easily maintainable.

## Analyzing the architecture
<p align="center">
  <img src="https://github.com/KyrXtz/SportsBet/blob/master/Images/2.jpg" width="500" />
</p>

The following analyzes the onion architecture, starting from the inner layer and going outwards

* **Domain**: This inner layer serves as the stronghold for all business logic within SportsBet. It encapsulates the heart of the system, making it accessible through the shared kernel. In synergy, the following DDD principles empower SportsBet to deliver a solid, maintainable, and adaptable codebase.
  
  * By applying the **specification pattern**, we decouple actual objects from the intricate business rules they must adhere to.
  * This design philosophy extends beyond just specifications; it incorporates principles such as **guard clauses**, ensuring that our code remains robust and resilient.
  * Furthermore, we embrace the power of **smart enums**, providing a structured way to represent domain-specific concepts.
    
* **Application**: The application layer within SportsBet orchestrates the processing of **commands and queries**, shaping and organizing data for seamless interaction with the service layer. By leveraging the following technologies and principles, the application layer in SportsBet seamlessly processes and manages commands and queries while maintaining high standards of performance and reliability.
  
  * This vital component integrates various robust technologies and principles, including **AppMetrics**, ensuring efficient monitoring and measurement of system performance.
  * **Autofac**, a powerful dependency injection framework, facilitates effective component management.
  * The integration of **DistributedLock** adds distributed locking capabilities, enhancing resource synchronization.
  * **FluentValidation** serves as a key element for input validation, ensuring that data entering the system adheres to defined rules.
  * **MediatR** brings the power of the Mediator pattern, simplifying command and query handling.
  * **protobuf-net.Core** optimizes data serialization and deserialization.
  * The addition of **Polly** contributes to resilience in the face of transient faults.


* **Infrastructure**: This layer takes care of **technical operations**, including **database** connection, setting up **Entity Framework Core mappings**, and applying **Filters** to the calls. The Infrastructure layer in SportsBet ensures the smooth execution of technical tasks while leveraging the following technologies and principles

  * **HealthChecks** for monitoring RabbitMQ, SQL and other services' health.
  * **AutoMapper** for robust object mapping.
  * **Quartz** for advanced scheduling and job management.
  * **StackExchangeRedis** for efficient caching with Redis.
  * **MassTransit** for handling messaging.

* **API**: The outermost layer serves as the **external interface**, enabling the frontend to **post** and **query** data. The API layer in SportsBet acts as the gateway for interacting with the system, facilitating data submission and retrieval while leveraging the following technologies to enhance usability and documentation.

  * **NLog** for advanced logging and tracing.
  * **NSwag** for generating Swagger documentation.
  * **Swashbuckle** for automatic API documentation and interactive exploration.
 
* **Unit Tests**: SportsBet employs rigorous unit testing to ensure code quality and reliability. By combining the following testing tools, we maintain high-quality code and ensure that our system functions as intended while detecting issues early in the development process.
 
  * **Moq**: A versatile mocking framework for creating mock objects to isolate the code under test.
  * **xunit**: A popular unit testing framework for .NET that provides a simple and extensible platform for running tests.
  * **coverlet.collector**: A code coverage collector for measuring test code coverage, allowing us to assess the thoroughness of our unit tests.
  * **k6**: A load testing tool that helps us simulate real-world traffic and analyze the system's performance under heavy loads.
    
* **Shared**: SportsBet features a shared project designed to **centralize** the definition and exposure of **endpoints**, providing a **unified interface** to interact with the system. This shared project is a core component of the solution, allowing for a consistent and streamlined approach to exposing and consuming endpoints.
  * One notable advantage of this shared project is the ability to create a **NuGet package**, simplifying the distribution of endpoint-related functionalities to other parts of the system or even external consumers. By packaging endpoints as a reusable component, it facilitates seamless integration and extends the versatility of SportsBet for various use cases.

## Containerization
<p align="center">
  <img src="https://github.com/KyrXtz/SportsBet/blob/master/Images/3.png" width="300" />
</p>

SportsBet embraces modern containerization and orchestration technologies, with support for both Docker and Kubernetes. These technologies offer scalability, portability, and ease of deployment for the system.

* **Docker**: We provide Docker containerization for SportsBet, enabling consistent and reliable packaging of your application, its dependencies, and configurations. With Docker, you can easily create, share, and deploy containers across different environments while maintaining consistency and predictability.

* **Kubernetes**: SportsBet extends its support to Kubernetes, a powerful container orchestration platform. Kubernetes empowers you to manage, scale, and automate the deployment and operation of containerized applications. With Kubernetes, you can ensure high availability, resilience, and seamless updates for your SportsBet system.

This Docker and Kubernetes support enhances the agility and efficiency of your SportsBet deployment, allowing you to confidently manage and scale your application in various environments and scenarios.

## k6 Testing:
<p align="center">
  <img src="https://github.com/KyrXtz/SportsBet/blob/master/Images/4.png" width="300" />
</p>

SportsBet proudly supports k6, a powerful and versatile load testing tool that enhances the system's performance and reliability. With k6, we can perform various types of testing, including:

* **Load Testing**: Measure the system's performance under expected load conditions to ensure optimal user experience.

* **Stress Testing**: Evaluate how the system behaves under extreme conditions, pushing its limits to identify bottlenecks and potential weaknesses.

* **Spike Testing**: Simulate sudden spikes in user activity to test the system's ability to handle rapid increases in load.

* **Soak Testing**: Assess the system's stability over an extended period to identify memory leaks and other long-term issues.

By leveraging k6 for these testing scenarios, we can fine-tune and optimize the performance and reliability of SportsBet, ensuring that it delivers a seamless and responsive experience to users, even under demanding conditions.

## Summary

In summary, SportsBet's meticulously designed components form a **robust and efficient** foundation for the SportsBet platform. This architecture ensures a dependable and responsive experience for users while retaining the adaptability to accommodate future growth and innovation in the world of sports betting.

SportsBet is engineered to deliver **high availability**, ensuring that the platform remains accessible even during peak usage periods or unexpected events. The system's inherent **resilience** empowers it to gracefully handle failures and maintain continuous operation.

Future endeavours can have the SportsBet platform harnessing **artificial intelligence (AI)** for personalized recommendations based on user preferences, enhancing the platform's ability to stay ahead of evolving user needs and industry trends.
