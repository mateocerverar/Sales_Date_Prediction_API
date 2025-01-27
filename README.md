# Sales_Date_Prediction_Web_API

Informacion relevante: 
- El proyecto esta hecho en .NET 7.0 debido a problemas de incompatibilidad con .NET 8.0 en mi equipo.
- El proyecto esta contruido siguiendo recomendacion de principios SOLID y Clean Arquitecture, teniendo un enfoque en el patron CQRS (Command Query Responsibility Segregation) para una posible escalabilidad y mejor manejo en caso de que quiera ser transformado a un microservicio o a una estructura mas grande.
- El proyecto es apto para implementar librerias como Automapper, FluentValidation o RabbitMQ para el manejo y transformacion de datos desde el proyecto.
Explicación de la ejecución de la prueba:
De acuerdo al esquema que se proporciona al principio de la prueba, construí la arquitectura con los 5 features proporcionados en el diagrama de arquitectura de la aplicación. La aplicación consta de 5 proyectos:
- Application: En donde tenemos la logica de los features (queries, commands y handlers), junto con las interfaces de los repositorios utilizados en la capa de infraestructura.
- Infrastructure: Aqui realizamos el manejo de las operaciones en base de datos, cada feature tiene su respectivo repositorio implementando los respectivos metodos definidos en la interfaz de cada uno.
- Domain: Aqui estan almacenadas las entidades utilizadas a lo largo de la aplicación.
- API: Aqui estan dispuestos los controladores los cuales invocan el respectivo query o command segun sea el metodo que este siendo solicitado.
Todo el manejo de los metodos se hace a traves del patron mediador, con el cual nos ayuda la libreria mediatR, esta es la encargada de redireccionar segun sea la solicitud al respectivo command o query.

Adicionalmente, en el inicio del proyecto, deje los procedimientos almacenados que fueron utilizados en la creacion de la aplicación, los cuales deben ser ejecutados antes de iniciar con la revisión. La conexión a base de datos es manejada a traves del micro ORM llamado Dapper, el cual es una opción bastante eficiente al tratarse de una herramienta basada en Ado.Net.
La conexión a la base de datos queda con la instancia creada localmente en mi equipo.
