import { Role } from "./role.model";

export interface User{
    userId : string;
    firstName : string;
    lastName : string;
    email:string ;
    phone :string;
    role : Role;
    username : string;


}
export interface AddUserRequest{
    userId : string;
    firstName : string;
    lastName : string;
    email:string ;
    phone :string;
    roleId : string;
    username : string;
    password: string;
}
export interface UpdateUserRequest{
    userId : string;
    firstName : string;
    lastName : string;
    email:string ;
    phone :string;
    roleId : string;
    username : string;
    password: string;
}
export interface GetAllUser{
    orderBy : string;
    orderDirection: string ;
    pageNumber: number ;
    pageSize: number ;
    search: string;

}
export function defaultGetAllUser(): GetAllUser {
    return { orderBy: '', orderDirection: 'asc', pageNumber: 1, pageSize: 20, search: '' };
}
// Usage: const params = defaultGetAllUser();
export interface DeleteUserRequest{
    result: boolean;
    message: string;
}