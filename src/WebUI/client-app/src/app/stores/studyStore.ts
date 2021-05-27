import { makeAutoObservable } from "mobx";
import agent from "../api/agent";
import { Study } from "../models/study";

export default class StudyStore {
    studyRegistry = new Map<string, Study>();
    selectedStudy: Study | undefined = undefined;
    loading = false;
    loadingInitial = true;

    constructor() {
        makeAutoObservable(this)
    }

    // computed property
    get studiesByDate() {
        return Array.from(this.studyRegistry.values()).sort((a, b) =>
            // TODO: this smells - sort out date handling strategy
            Date.parse(a.created) - Date.parse(b.created));
    }
    
    loadStudies = async () => {
        this.setLoadingInitial(true);
        try {
            const response = await agent.Studies.list();
                response.studies.forEach((study: Study) => {
                    this.setStudy(study)
                })
                this.setLoadingInitial(false);
        } catch (error) {
            console.log(error);
                this.setLoadingInitial(false);
        }
    }

    private setStudy = (study: Study) => {

        // TODO: this smells - sort out date handling strategy
        study.created = study.created.split('T')[0];
        study.estimatedStartDate = study.estimatedStartDate.split('T')[0];
        this.studyRegistry.set(study.id, study);
    }

    setLoadingInitial = (state: boolean) => {
        this.loadingInitial = state;
    }
}