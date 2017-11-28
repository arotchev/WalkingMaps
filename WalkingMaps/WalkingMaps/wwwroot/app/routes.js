"use strict";
var router_1 = require("@angular/router");
var walks_component_1 = require("./components/walks.component");
var walk_sights_component_1 = require("./components/walk-sights.component");
var appRoutes = [
    {
        path: '',
        redirectTo: '/walks',
        pathMatch: 'full'
    },
    {
        path: 'walks',
        component: walks_component_1.WalksComponent
    },
    {
        path: 'walks/:id/sights',
        component: walk_sights_component_1.WalkSightsComponent
    }
];
exports.routing = router_1.RouterModule.forRoot(appRoutes);
//# sourceMappingURL=routes.js.map