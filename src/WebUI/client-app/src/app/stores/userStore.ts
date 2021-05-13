import { makeAutoObservable } from "mobx";
import { User, UserFormValues } from "../models/user";

export default class UserStore {
    user: User | null = null;
    
    constructor() {
        makeAutoObservable(this)
    }

    get isLoggedIn() {
        return !!this.user
    }

    login = async (creds: UserFormValues) => {

    }

    logout = () => {

    }

    getUser = async () => {

    }

    register = async (creds: UserFormValues) => {

    }
}