"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var City;
(function (City) {
    City[City["Moscow"] = 0] = "Moscow";
    City[City["StPetersburg"] = 1] = "StPetersburg";
    City[City["Kazan"] = 2] = "Kazan";
    City[City["Sochi"] = 3] = "Sochi";
})(City || (City = {}));
var Walk = (function () {
    function Walk(id, name, description, startPoint, endPoint, createdDate, navLink, distance, isPublished, userId, city, totalSights) {
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
    return Walk;
}());
exports.Walk = Walk;
