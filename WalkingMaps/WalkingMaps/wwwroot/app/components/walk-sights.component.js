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
var router_1 = require("@angular/router");
var paginated_1 = require("../core/common/paginated");
var data_service_1 = require("../core/services/data.service");
var utility_service_1 = require("../core/services/utility.service");
var notification_service_1 = require("../core/services/notification.service");
var operationResult_1 = require("../core/domain/operationResult");
var WalkSightsComponent = (function (_super) {
    __extends(WalkSightsComponent, _super);
    function WalkSightsComponent(dataService, utilityService, notificationService, route, router) {
        var _this = _super.call(this, 0, 0, 0) || this;
        _this.dataService = dataService;
        _this.utilityService = utilityService;
        _this.notificationService = notificationService;
        _this.route = route;
        _this.router = router;
        _this._walksAPI = 'api/walks/';
        _this._sightsAPI = 'api/walksights/';
        return _this;
    }
    WalkSightsComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.sub = this.route.params.subscribe(function (params) {
            _this._walkId = params['id']; // (+) converts string 'id' to a number
            _this._walksAPI += _this._walkId + '/sights/';
            _this.dataService.set(_this._walksAPI, 6);
            _this.getWalkSights();
        });
    };
    WalkSightsComponent.prototype.getWalkSights = function () {
        var _this = this;
        this.dataService.get(this._page)
            .subscribe(function (res) {
            var data = res.json();
            _this._sights = data.Items;
            _this._displayingTotal = _this._sights.length;
            _this._page = data.Page;
            _this._pagesCount = data.TotalPages;
            _this._totalCount = data.TotalCount;
            _this._walkName = _this._sights[0].WalkName;
        }, function (error) {
            if (error.status == 401 || error.status == 302) {
                _this.utilityService.navigateToSignIn();
            }
            console.error('Error: ' + error);
        }, function () { return console.log(_this._sights); });
    };
    WalkSightsComponent.prototype.search = function (i) {
        _super.prototype.search.call(this, i);
        this.getWalkSights();
    };
    ;
    WalkSightsComponent.prototype.convertDateTime = function (date) {
        return this.utilityService.convertDateTime(date);
    };
    WalkSightsComponent.prototype.delete = function (sight) {
        var _this = this;
        var _removeResult = new operationResult_1.OperationResult(false, '');
        this.notificationService.printConfirmationDialog('Are you sure you want to remove the sight from this walk?', function () {
            _this.dataService.deleteResource(_this._sightsAPI + sight.Id)
                .subscribe(function (res) {
                _removeResult.Succeeded = res.Succeeded;
                _removeResult.Message = res.Message;
            }, function (error) { return console.error('Error: ' + error); }, function () {
                if (_removeResult.Succeeded) {
                    _this.notificationService.printSuccessMessage(sight.Name + ' removed from the walk.');
                    _this.getWalkSights();
                }
                else {
                    _this.notificationService.printErrorMessage('Failed to remove this sight from the walk.');
                }
            });
        });
    };
    return WalkSightsComponent;
}(paginated_1.Paginated));
WalkSightsComponent = __decorate([
    core_1.Component({
        selector: 'walk-sights',
        providers: [notification_service_1.NotificationService],
        templateUrl: './app/components/walk-sights.component.html'
    }),
    __metadata("design:paramtypes", [data_service_1.DataService,
        utility_service_1.UtilityService,
        notification_service_1.NotificationService,
        router_1.ActivatedRoute,
        router_1.Router])
], WalkSightsComponent);
exports.WalkSightsComponent = WalkSightsComponent;
//# sourceMappingURL=walk-sights.component.js.map