export class Photo {
    Id: number;
    Title: string;
    Uri: string;
    SightId: number;
    SightTitle: string;
    UserId: string;
    DateUploaded: Date

    constructor(id: number,
        title: string,
        uri: string,
        sightId: number,
        sightTitle: string,
        userId: string,
        dateUploaded: Date) {
        this.Id = id;
        this.Title = title;
        this.Uri = uri;
        this.SightId = sightId;
        this.SightTitle = sightTitle;
        this.UserId = userId;
        this.DateUploaded = dateUploaded;
    }
}