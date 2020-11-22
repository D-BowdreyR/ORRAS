# Oxford Research Radiation Assurance (ORRA) Single Page Application (SPA) #

*MSc Clinical Science (Clinical Bioinformatics Physical Sciences) Research Project*

This is a project to re-design and build a replacement for the current ORRA system used for the coordination and management of many clinical governance and technical assurance activities that must be undertaken across the Oxford University Hospital NHS Foundation Trust (OUH NHS FT) for the site approval of clinical research projects that involve ionising radiation research exposures.

The current ORRA application was built on VB6 UI/Application with dependencies installed onto Windows only clients. 
The application runs from a internally hosted file share and connects to an MS Access Database for for data persistence, that is hosted on the same file share. 
This re-design will utilise modern web frameworks and development processes to produce a scalable, supportable and extensible system.

The solution will be built with:
- SPA Backend: ASP.NET Core API 
- SPA Frontend: React.js
- ORM: - Entity Framework Core
- RDMS: (yet to be decided) either: 
  - MySQL
  - MSSQL
- Authen/Author: Custom Built Security Token Service (STS) using IdentityServer4 Framework 
  - Utilising OAuth and OpenID Connect Protocols
- Docker for containerization of App, Databases, and STS

Concepts/Design Patterns:
- CQRS ( Command Query Responsibility Segregation) Pattern
- Mediator Pattern