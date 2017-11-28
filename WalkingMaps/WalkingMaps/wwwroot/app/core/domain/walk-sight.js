"use strict";
var WalkSight = (function () {
    function WalkSight(id, name, description, address, walkId, walkName, photoUri) {
        this.Id = id;
        this.Name = name;
        this.Description = description;
        this.Address = address;
        this.WalkId = walkId;
        this.WalkName = walkName;
        this.PhotoUri = photoUri;
    }
    return WalkSight;
}());
exports.WalkSight = WalkSight;
//# sourceMappingURL=walk-sight.js.map