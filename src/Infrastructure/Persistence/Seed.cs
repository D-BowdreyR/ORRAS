using System;
using System.Runtime.InteropServices;
using System.Linq;
using System.Threading.Tasks;
using ORRA.Domain.Entities;

namespace ORRA.Infrastructure.Persistence
{
    public class Seed
    {
        public static async Task SeedDataAsync(ApplicationDbContext context)
        {
            //TODO: check if seed is necessary
            if (!context.Modalities.Any())
            {
                context.Modalities.Add(new Modality 
                {
                    Id = Guid.NewGuid(),
                    ModalityCode = "A",
                    ModalityName = "Angiography",
                    
                    ImagingProcedures =
                    {
                        new ImagingProcedure { 
                            Id = Guid.NewGuid(),
                            CrisCode = "FPACE", 
                            Term = "Cardiac Pacing Wire Screening",
                            ExamCount = 1,
                            Interventional = true
                        },
                        new ImagingProcedure {
                            Id = Guid.NewGuid(),
                            CrisCode = "FPASC", 
                            Term = "Cardiac Permanent Pacemaker Check",
                            ExamCount = 1,
                            Interventional = true
                        },
                    }
                });

            }

            await context.SaveChangesAsync();
        }
    }
}

