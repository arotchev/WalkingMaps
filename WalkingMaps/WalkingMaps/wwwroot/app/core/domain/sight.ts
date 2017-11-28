export class Sight {
    Id: number;
    Name: string;
    Description: string;
    NavLink: string;
    Address: string;
    CreatedDate: Date;
    FormattedAddress: string;
    Latitude: number;
    Longtitude: number;
    UserId: string;
    PhotoUri: string;

   

    constructor(id: number,
        name: string,
        description: string,
        navLink: string,
        address: string,
        createdDate: Date,
        formattedAddress: string,
        latitude: number,
        longtitude: number,
        userId: string,
        photoUri: string)
    {

        this.Id = id;
        this.Name = name;
        this.Description = description;
        this.NavLink = navLink;
        this.Address = address;
        this.CreatedDate = createdDate;
        this.FormattedAddress = formattedAddress;
        this.Latitude = latitude;
        this.Longtitude = longtitude;
        this.UserId = userId;
        this.PhotoUri = photoUri;
    }
}