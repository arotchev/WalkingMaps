import { Component, OnInit } from '@angular/core';
import { Walk } from '../core/domain/walk';
import { Paginated } from '../core/common/paginated';
import { DataService } from '../core/services/data.service';
import { UtilityService } from '../core/services/utility.service';
import { NotificationService } from '../core/services/notification.service';

@Component({
    selector: 'walks',
    templateUrl: './app/components/walks.component.html'
})
export class WalksComponent extends Paginated implements OnInit {
    private _walksAPI: string = 'api/walks/';
    private _walks: Array<Walk>;

    constructor(public walksService: DataService,
        public utilityService: UtilityService,
        public notificationService: NotificationService) {
        super(0, 0, 0);
    }

    ngOnInit() {
       
        this.walksService.set(this._walksAPI, 3);
        this.getWalks();
    }

    getWalks(): void {
        this.walksService.get(this._page)
            .subscribe(res => {
                var data: any = res.json();                

                this._walks = data.Items;
                this._page = data.Page;
                this._pagesCount = data.TotalPages;
                this._totalCount = data.TotalCount;
               
            },
            error => {

                if (error.status == 401 || error.status == 404) {
                    this.notificationService.printErrorMessage('Authentication required');
                    this.utilityService.navigateToSignIn();
                }
            });
    }

    search(i): void {
        super.search(i);
        this.getWalks();
    };

    convertDateTime(date: Date) {
        return this.utilityService.convertDateTime(date);
    }
}