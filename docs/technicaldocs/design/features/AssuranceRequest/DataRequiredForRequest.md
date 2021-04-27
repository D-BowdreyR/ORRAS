# Data required when a assurance request is made

Meta Data Regarding Request
- Creator (user id)
- timedate of creation
- timedate of submission

## What must we know / ask from the requestor/service user?


### Type of Approval being requested

Currently these are called:
1. **National Approval** (marked as RRA on the system), this is where we also create a radiation risk assessment. Could either be for a study where Oxford is the lead site, or an external request for MPE (e.g. HRA approved reviewers)
2. **Local Approval** (makred as SSI on the system), this is where the RRA has already been completed and signed off by another MPE and CRE (so the IRAS should have already been submitted)

This could be: (National Approval Only, National and Local Approval, Local Approval Only)

### Study [Header] Details

- Short study title
- Study Acronym
- OUH R&D Project ID
- IRAS Project ID
- has IRAS been submitted? (YES/NO)
- If YES - submission date
- EudraCT number (CTIMPs only)
- est. study start date (mm/yyyy)
- est. study end date (mm/yyyy)
- est. total duration of the study (in months)
- Full Title of research project
- Chief investigator
- Study Coordinator(s)
- 
- does the study involve trialing a new medical device? (YES/NO)
- does the study involve Radiotherapies?
- does the study involve radioactive substances?

- multicentre? (YES/NO)
- if YES, how many UK Centres are involved?
- Lead Site ()

### Local Site Participation Info
- IF study is local - Main Local Site
- Local Departments where imaging or therapy procedures will take place
- Name of CRE or IRMER practitioner - business rules here:
  - Professor Fergus Gleeson for Churchill
  - Dr Suzie Anthony for JRH
  - Wilhelm Kueker for West Wing
  - Dr Bernadette Lavery for Radiotherapy


### Study Participants Info
- Will any of the study participants be patients>? (YES/NO)
- Number (Whole Study)
- Number at Local Site (oxford)
- Age Range
- Sex of Participants (Male only, Female only, Male and Female)
- Clinical condition
- Will any of the study participants be healthy volunteers? (YES/NO)
- Number (whole study)
- Number of participants at Local (Oxford) site
- Age Range (range beginning, range end)
- Sex of Participants (Male only, Female only, Male and Female)
- Are participants healthy? (YES/NO)
- If NO - Provide Clinical condition

- Will the study involve participants who are pregnant or breast feeding? (YES/NO)
- Will the study involve children?  (YES/NO)

### Study Protocol Procedures
- Add Cohort(s)
  - Create A Study Procedure/s
    - Imaging Procedure (Code)
    - Assign to one or more Cohorts (created earlier)
    - Imaging Procedure Modifier
    - Imaging Procedure Modifier Value
    - Number of Routine Care examinations
    - Number of Additional examinations
    - Reporting Required (multi-selection)
    - Data Processing Required? (multi-selection)
    - Where will this procedure take place (OUH, )

### Study Documentation
- Upload Files
  - Title
  - Description
  - Version
  - Document Date
  - Category/Type (Submitted IRAS Form,Draft IRAS Form, Protocol, Imaging Manual, Participant Information Sheet,Email Correspondents,Letter,HRA Approval)

#### Currently we ask for:
##### National Approval
- Protocol
- Draft IRAS (if available)
- Draft Imaging Manual (if available)
- Draft PIS
- HRA documentation such as Research Exposure Form (REF form) (if via HRA route)
- 

##### Local Approval
- Protocol
- Full IRAS Form
- Imaging Manual (unless explicit confirmation that there is none)
- ARSAC research approval certificate (if applicable, the sponsor should provide this to all participating sites)
- PIS
- Any Additional Information