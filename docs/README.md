# Oxford Research Radiation Assurance Service (ORRAS)

_MSc Clinical Science (Clinical Bioinformatics Physical Sciences) Research Project_

Project Author: _Daniel Bowdrey-Roberts_

This is a project to re-design and build a replacement for the current ORRA system used for the coordination and management of many clinical governance and technical assurance activities that must be undertaken across the Oxford University Hospital NHS Foundation Trust (OUH NHS FT) for the site approval of clinical research projects that involve ionising radiation research exposures.

The current ORRA application was built on VB6 UI/Application with dependencies installed onto Windows only clients. It runs from a internally hosted file share and connects to an MS Access Database for for data persistence, that is hosted on the same file share.

This re-designed system will utilise modern web frameworks and development processes to produce a scalable, supportable and extensible system.

The solution will be built with:

- SPA Backend: ASP.NET Core API
- SPA Frontend: React.js
- ORM: - Entity Framework Core
- RDMS:
  - PostgreSQL
- Authen/Author: Custom Built Security Token Service (STS) using IdentityServer4 Framework
  - Utilising OAuth and OpenID Connect Protocols
- Docker for containerization of App, Databases, and STS

Concepts/Design Patterns:

- CQRS ( Command Query Responsibility Segregation) Pattern
- Mediator Pattern

## Git Workflow

This is mostly a Solo project, but the structure of this repo will follow some best practices in terms of Git Flow. This repo is divided into three main parts/branches:

1. Main and origin (remote)
2. Develop
3. Feature(s)

All development work will occur in the Develop branch and separate feature branches, that will be merged back into develop once they have been finished. All stable releases will be against the master branch and be tagged with version numbers. This workflow is further explained in a blog post by [Scott Lambert](https://sdlambert.github.io/2015/04/09/git-workflow-for-solo-development/).
![Solo Git Workflow](https://sdlambert.github.io/img/git-nodes.png)
