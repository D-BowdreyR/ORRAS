export interface Study {
  id: string;
  localPID: string;
  irasProjectID: string;
  eudraCTReference: string;
  hraReference: string;
  shortTitle: string;
  acronym: string;
  longTitle: string;
  created: string
  estimatedStartDate: string
}

export interface StudyList {
    key: string
    studies: Study[];
}
