export class WalkSight {
    Id: number;
    Name: string;
    Description: string;   
    Address: string;  
    WalkId: number;
    WalkName: string;
    PhotoUri: string;   

    constructor(id: number,
        name: string,
        description: string,      
        address: string,     
        walkId: number,
        walkName: string,
        photoUri: string)
    {

        this.Id = id;
        this.Name = name;
        this.Description = description;     
        this.Address = address;       
        this.WalkId = walkId;
        this.WalkName = walkName;
        this.PhotoUri = photoUri;
    }
}