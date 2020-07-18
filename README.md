# PhysicsAdvertisements portal created as a part of my master thesis project.
The same version of the app was built in the ASP.NET WebForms and ASP.NET MVC technologies.
- The Bootstrap 3 was used in both of the projects. Same for Entity Framework; Code First approach.
- The MVP pattern was used in the WebForms project to show the approach to how the stuff can be better maintain(SOC) and testable.
- As an innovation, I explored the way of implementing the DataAnnotations and jQuery-unobtrusive to validate the forms in the ASP.NET WebForms technology.
The approach allows you to establish the front-end validators based on the DataAnnotations decorators added to the model object fields just for free.

Both apps were used to create a number of tests to compare both technologies in terms of:
- amount of generated HTML code as in both cases the pages are generated on the server-side,
- pages loading speed,
- maintainability, especially the approach to forms validation.
