
enum City { Moscow, StPetersburg, Kazan, Sochi }

export class Walk {
    Id: number;
    Name: string;
    Description: string;
    StartPoint: string;
    EndPoint: string;
    CreatedDate: Date;
    NavLink: string;
    Distance: number;
    IsPublished: boolean;
    UserId: string;
    City: City;
    TotalSights: number;
    
    constructor(id: number,
        name: string,
        description: string,
        startPoint: string,
        endPoint: string,
        createdDate: Date,
        navLink: string,
        distance: number,
        isPublished: boolean,
        userId: string,
        city: City,
        totalSights: number) {
        this.Id = id;
        this.Name = name;
        this.Description = description;
        this.StartPoint = startPoint;
        this.EndPoint = endPoint;
        this.CreatedDate = createdDate;
        this.NavLink = navLink;
        this.Distance = distance;
        this.IsPublished = isPublished;
        this.UserId = userId;
        this.City = city;
        this.TotalSights = totalSights;
    }
}



      