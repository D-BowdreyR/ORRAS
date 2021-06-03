export interface User {
    username: string
    displayName: string
    jobTitle: string
    token: string

}

export interface UserFormValues {
    email: string;
    password: string;
    displayName?: string;
    username?: string;
}