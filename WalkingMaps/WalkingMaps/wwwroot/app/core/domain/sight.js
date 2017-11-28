"use strict";
var Sight = (function () {
    function Sight(id, name, description, navLink, address, createdDate, formattedAddress, latitude, longtitude, userId, photoUri) {
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
    return Sight;
}());
exports.Sight = Sight;
//# sourceMappingURL=sight.js.map