using System.IO;
using System.Net;
using System;
using System.Runtime.InteropServices;
using System.Linq;
using System.Threading.Tasks;
using ORRAS.Domain.Entities;
using System.Collections.Generic;
using ORRAS.Domain.Enums;
using ORRAS.Domain.ValueObjects;
using Microsoft.AspNetCore.Identity;
using ORRAS.Infrastructure.Identity;
using System.Text.Json;
using System.Reflection;

namespace ORRAS.Infrastructure.Persistence
{
    public class Seed
    {

        public static async Task SeedDefaultUsersAsync(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {


                string filePath = "../Infrastructure/Persistence/UserAccountSeed.json";

                try
                {
                    using FileStream openStream = System.IO.File.OpenRead(filePath);
                    List<AppUser> users = await JsonSerializer.DeserializeAsync<List<AppUser>>(openStream);

                    foreach (var user in users)
                    {
                        await userManager.CreateAsync(user, "Pa$$w0rd");
                    }
                }
                catch (Exception)
                {

                    throw;
                }


            }
        }

        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {


            //TODO: check if seed is necessary
            if (!context.ImagingModalities.Any())
            {
                var modalities = new List<ImagingModality>
                {
                    new ImagingModality
                    {
                        ModalityCode = "A",
                        ModalityName = "Angiography",

                        ImagingProcedures =
                        {
                            new ImagingProcedure {
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
                        ModalityCode = "X",
                        ModalityName = "X-Ray",
                        ImagingProcedures =
                        {
                            new ImagingProcedure {
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

            if (!context.Companies.Any())
            {
                var companies = new List<Company>
                {
                    new Company
                    {
                        DisplayName = "Oxford University Hospitals NHS Foundation Trust",
                        Abbreviation = "OUH NHS FT",
                        Departments =
                        {
                            new Department
                            {
                                DepartmentName = "Medical Physics and Clinical Engineering",
                                Acronym = "MPCE",
                                Contacts =
                                {
                                    new Contact
                                    {
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

            if (!context.ResearchStudies.Any())
            {
                var studies = new List<ResearchStudy>
                {
                    new ResearchStudy
                    {
                        LocalPID = "15044",
                        IrasProjectID = "20/LO/0963",
                        ShortTitle = "SGNTUC-016 / HER2CLIMB-02",
                        LongTitle = "Randomized, double-blind, phase 3 study of tucatinib or placebo in combination with ado-trastuzumab emtansine (TDM1) for subjects with unresectable locally-advanced or metastatic HER2+ breast cancer (HER2CLIMB-02)",
                        EstimatedStartDate = DateTime.Parse("01/10/2020"),
                        EstimatedTotalDurationInMonths = 48,
                        IsMultiCentre = true,
                        NumberOfUKCentres = 8,
                        EudraCTReference = "2019-005017-39"
                    },
                    new ResearchStudy
                    {
                        IrasProjectID = "1061/MODREC/20",
                        LongTitle = "Military COVID, Outcomes in a Viral Infectious Disease",
                        ShortTitle = "M-COVID Military COVID trial",
                        EstimatedStartDate = DateTime.Parse("03/08/2020"),
                        IsMultiCentre = true,
                        NumberOfUKCentres = 2,
                        EstimatedTotalDurationInMonths = 18
                    },
                    new ResearchStudy
                    {
                        IrasProjectID = "20/SC/0111",
                        LongTitle = "DREAMM 7: A Multicenter, Open-Label, Randomized Phase III Study to Evaluate the Efficacy and Safety of the Combination of Belantamab Mafodotin, Bortezomib, and Dexamethasone (B-Vd) Compared with the Combination of Daratumumab, Bortezomib and Dexamethasone (D-Vd) in Participants with Relapsed/Refractory Multiple Myeloma",
                        ShortTitle = "DREAMM 7: A Multicenter, Open-Label, Randomized Phase III Study",
                        Acronym = "DREAMM7",
                        EstimatedStartDate = DateTime.Parse("01/05/2020"),
                        IsMultiCentre = true,
                        NumberOfUKCentres = 6,
                        EstimatedTotalDurationInMonths = 74
                    }
                };
                context.ResearchStudies.AddRange(studies);
            }

            await context.SaveChangesAsync();
        }
    }
}