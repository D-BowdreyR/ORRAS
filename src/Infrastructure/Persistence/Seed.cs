using System.Net;
using System;
using System.Runtime.InteropServices;
using System.Linq;
using System.Threading.Tasks;
using ORRA.Domain.Entities;
using System.Collections.Generic;
using ORRA.Domain.Enums;
using ORRA.Domain.ValueObjects;

namespace ORRA.Infrastructure.Persistence
{
    public class Seed
    {
        public static async Task SeedDataAsync(ApplicationDbContext context)
        {
            
            //TODO: check if seed is necessary
            if (!context.ImagingModalities.Any())
            {
                var modalities = new List<ImagingModality> 
                {
                    new ImagingModality
                    {
                        Id = Guid.NewGuid(),
                        ModalityCode = "A",
                        ModalityName = "Angiography",

                        ImagingProcedures =
                        {
                            new ImagingProcedure {
                                Id = 58588,
                                Status = ImagingProcedureStatus.Active,
                                ShortCode = "FPACE",
                                DisplayTerm = "Cardiac pacing wire screening",
                                BodyPartMultiplicationFactor = 1,
                                IsInterventional = true,
                                IsDiagnostic = false,
                                SNOMEDCT_ConceptID = "432953000",
                                SNOMEDCT_FSN = "Fluoroscopy of heart for checking of cardiac pacemaker electrode position (procedure)"
                            },
                            new ImagingProcedure {
                                Id = 58589,
                                Status = ImagingProcedureStatus.Active,
                                ShortCode = "FPASC",
                                DisplayTerm = "Cardiac permanent pacemaker check",
                                BodyPartMultiplicationFactor = 1,
                                IsInterventional = false,
                                IsDiagnostic = true,
                                SNOMEDCT_ConceptID = "431306005",
                                SNOMEDCT_FSN = "Fluoroscopy of heart for checking of permanent pacemaker position (procedure)"
                            },
                            new ImagingProcedure {
                                Id = 4082,
                                Status = ImagingProcedureStatus.Active,
                                ShortCode = "FALLR",
                                DisplayTerm = "Angio lower limbs Right",
                                BodyPartMultiplicationFactor = 1,
                                IsInterventional = false,
                                IsDiagnostic = true,
                                SNOMEDCT_ConceptID = "418994005",
                                SNOMEDCT_LateralityID = "24028007",
                                SNOMEDCT_FSN = "Fluoroscopic angiography of lower limb artery (procedure)"
                            },
                        }
                    },
                    new ImagingModality 
                    {
                        Id = Guid.NewGuid(),
                        ModalityCode = "X",
                        ModalityName = "X-Ray",
                        ImagingProcedures = 
                        {
                            new ImagingProcedure {
                                Id = 3032,
                                Status = ImagingProcedureStatus.Active,
                                ShortCode = "XPATR",
                                DisplayTerm = "XR Patella Rt",
                                BodyPartMultiplicationFactor = 1,
                                IsInterventional = false,
                                IsDiagnostic = true,
                                SNOMEDCT_ConceptID = "168669007",
                                SNOMEDCT_LateralityID = "24028007",
                                SNOMEDCT_FSN = "Plain X-ray of patella (procedure)"
                            }
                        }
                   
                    }
                };
                context.ImagingModalities.AddRange(modalities);
            }

            if(!context.Companies.Any())
            {
                var companies = new List<Company>
                {
                    new Company
                    {
                        Id = Guid.NewGuid(),
                        DisplayName = "Oxford University Hospitals NHS Foundation Trust",
                        Abbreviation = "OUH NHS FT",
                        Departments = 
                        {
                            new Department 
                            {
                                Id = Guid.NewGuid(),
                                DepartmentName = "Medical Physics and Clinical Engineering",
                                Acronym = "MPCE",
                                Contacts = 
                                {
                                    new Contact 
                                    {
                                        Id = Guid.NewGuid(),
                                        FirstName = "James",
                                        LastName = "Harries",
                                        JobTitle = "Head of Business and Informatics",
                                        EmailAddress = "james.harries@ouh.nhs.uk",
                                    }
                                }
                            }
                        }

                    }
                };
                context.Companies.AddRange(companies);
            }
            
            await context.SaveChangesAsync();
        }
    }
}