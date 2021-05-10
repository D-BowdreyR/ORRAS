# Oxford Research Radiation Assurance Service (ORRAS)

:blue_book:_MSc Clinical Science (Clinical Bioinformatics Physical Sciences) Research Project_

:pencil2: **Project Author:** [_Daniel Bowdrey-Roberts_](](https://github.com/D-BowdreyR)

:scroll: Copyright Notice: _This repository and its content is Copyright © 2021 Oxford University NHS Foundation Trust_

[GitHub Licensing Terms](https://docs.github.com/en/github/creating-cloning-and-archiving-repositories/licensing-a-repository#choosing-the-right-license)

## About This Project

A software development project to re-design and build a replacement system for the current Oxford Research Radiation Assurance (ORRA) software system used for the coordination and management of clinical governance and technical assurance activities undertaken at the Oxford University Hospital NHS Foundation Trust (OUH NHS FT) for the site approval of clinical research projects that involve ionising radiation research exposures.

The current ORRA software application is built on a Visual Basic 6 and is only compatible with Microsoft Windows clients.
It runs from a internally hosted network file share and connects to an MS Access Database for data persistence, which is also hosted on the same file share.

This re-design will utilise modern backend and frontend web frameworks and employ software engineering processes to produce a scalable, supportable and extensible product.

## Tools being used

The solution will be built with:

- Single Page Application (SPA) Backend: ASP.NET Core API (.Net 5)
- Single Page Application (SPA) Frontend: React.js
- Object Relational Mapper (ORM): - Entity Framework Core
- Relational Database Management System (RDMS): PostgreSQL

- Authentication /Authorization: 
  - utilising a OAuth 2.0 and OpenID Connect Web Security Protocols
  - JWT Tokens
  - with a view to using a custom Built Security Token Service (STS) using IdentityServer4 Framework

- Docker for containerization of App, Databases, and STS

Concepts/Design Patterns:

- CQRS ( Command Query Responsibility Segregation) Pattern
- Mediator Pattern

## Git Workflow

This is mostly a Solo project, but the structure of this repository will follow some best practices in terms of Git Flow. 
This repository is divided into three main parts/branches:

1. Main and origin (remote)
2. Develop
3. Feature(s)

All development work will occur in the Develop branch and separate feature branches, that will be merged back into develop once they have been finished. All stable releases will be against the master branch and be tagged with version numbers. This workflow is further explained in a blog post by [Scott Lambert](https://sdlambert.github.io/2015/04/09/git-workflow-for-solo-development/).
![Solo Git Workflow](https://sdlambert.github.io/img/git-nodes.png)
