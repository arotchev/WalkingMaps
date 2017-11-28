"use strict";
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require("@angular/core");
var paginated_1 = require("../core/common/paginated");
var data_service_1 = require("../core/services/data.service");
var utility_service_1 = require("../core/services/utility.service");
var notification_service_1 = require("../core/services/notification.service");
var WalksComponent = (function (_super) {
    __extends(WalksComponent, _super);
    function WalksComponent(walksService, utilityService, notificationService) {
        var _this = _super.call(this, 0, 0, 0) || this;
        _this.walksService = walksService;
        _this.utilityService = utilityService;
        _this.notificationService = notificationService;
        _this._walksAPI = 'api/walks/';
        return _this;
    }
    WalksComponent.prototype.ngOnInit = function () {
        this.walksService.set(this._walksAPI, 3);
        this.getWalks();
    };
    WalksComponent.prototype.getWalks = function () {
        var _this = this;
        this.walksService.get(this._page)
            .subscribe(function (res) {
            var data = res.json();
            _this._walks = data.Items;
            _this._page = data.Page;
            _this._pagesCount = data.TotalPages;
            _this._totalCount = data.TotalCount;
        }, function (error) {
            if (error.status == 401 || error.status == 404) {
                _this.notificationService.printErrorMessage('Authentication required');
                _this.utilityService.navigateToSignIn();
            }
        });
    };
    WalksComponent.prototype.search = function (i) {
        _super.prototype.search.call(this, i);
        this.getWalks();
    };
    ;
    WalksComponent.prototype.convertDateTime = function (date) {
        return this.utilityService.convertDateTime(date);
    };
    return WalksComponent;
}(paginated_1.Paginated));
WalksComponent = __decorate([
    core_1.Component({
        selector: 'walks',
        templateUrl: './app/components/walks.component.html'
    }),
    __metadata("design:paramtypes", [data_service_1.DataService,
        utility_service_1.UtilityService,
        notification_service_1.NotificationService])
], WalksComponent);
exports.WalksComponent = WalksComponent;
//# sourceMappingURL=walks.component.js.map