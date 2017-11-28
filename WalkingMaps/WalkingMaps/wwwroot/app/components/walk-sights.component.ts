import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { WalkSight } from '../core/domain/walk-sight';
import { Paginated } from '../core/common/paginated';
import { DataService } from '../core/services/data.service';
import { UtilityService } from '../core/services/utility.service';
import { NotificationService } from '../core/services/notification.service';
import { OperationResult } from '../core/domain/operationResult';
import { Subscription } from 'rxjs/Subscription';

@Component({
    selector: 'walk-sights',
    providers: [NotificationService],
    templateUrl: './app/components/walk-sights.component.html'
})
export class WalkSightsComponent extends Paginated implements OnInit {
    private _walksAPI: string = 'api/walks/';
    private _sightsAPI: string = 'api/walksights/';
    private _walkId: string;
    private _sights: Array<WalkSight>;
    private _displayingTotal: number;
    private _walkName: string;
    private sub: Subscription;

    constructor(public dataService: DataService,
        public utilityService: UtilityService,
        public notificationService: NotificationService,
        private route: ActivatedRoute,
        private router: Router) {
        super(0, 0, 0);
    }

    ngOnInit() {

        this.sub = this.route.params.subscribe(params => {
            this._walkId = params['id']; // (+) converts string 'id' to a number
            this._walksAPI += this._walkId + '/sights/';
            this.dataService.set(this._walksAPI, 6);
            this.getWalkSights();
        });
    }

    getWalkSights(): void {
        this.dataService.get(this._page)
            .subscribe(res => {

                var data: any = res.json();

                this._sights = data.Items;
                this._displayingTotal = this._sights.length;
                this._page = data.Page;
                this._pagesCount = data.TotalPages;
                this._totalCount = data.TotalCount;
                this._walkName = this._sights[0].WalkName;
            },
            error => {

                if (error.status == 401 || error.status == 302) {
                    this.utilityService.navigateToSignIn();
                }

                console.error('Error: ' + error)
            },
            () => console.log(this._sights));
    }

    search(i): void {
        super.search(i);
        this.getWalkSights();
    };

    convertDateTime(date: Date) {
        return this.utilityService.convertDateTime(date);
    }

    delete(sight: WalkSight) {
        var _removeResult: OperationResult = new OperationResult(false, '');

        this.notificationService.printConfirmationDialog('Are you sure you want to remove the sight from this walk?',
            () => {
                this.dataService.deleteResource(this._sightsAPI + sight.Id)
                    .subscribe(res => {
                        _removeResult.Succeeded = res.Succeeded;
                        _removeResult.Message = res.Message;
                    },
                    error => console.error('Error: ' + error),
                    () => {
                        if (_removeResult.Succeeded) {
                            this.notificationService.printSuccessMessage(sight.Name + ' removed from the walk.');
                            this.getWalkSights();
                        }
                        else {
                            this.notificationService.printErrorMessage('Failed to remove this sight from the walk.');
                        }
                    });
            });
    }
}