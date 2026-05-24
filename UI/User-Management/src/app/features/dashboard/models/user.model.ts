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
export interface AddUser{
    userId : string;
    firstName : string;
    lastName : string;
    email:string ;
    phone :string;
    roleId : string;
    username : string;
    password: string;
}
export interface UpdateUser{
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
export interface DeleteUser{
    result: boolean;
    message: string;
}