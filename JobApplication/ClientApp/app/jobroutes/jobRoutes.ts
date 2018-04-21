

import { AppComponent } from "../components/app/app.component";
import { NavMenuComponent } from "../components/navmenu/navmenu.component";
import { Routes } from "@angular/router/router";
import { HomeComponent } from "../components/home/home.component";
import { AddjobComponent } from "../components/addjob/addjob.component";
import { JobDataService } from "../services/job.dataservice";
import { ViewjobComponent } from "../components/viewjob/viewjob.component";
import { EditjobComponent } from "../components/editjob/editjob.component";

export const JOB_ROUTES: Routes = [
    
        { path: '', redirectTo: 'home', pathMatch: 'full' },
        { path: 'home', component: HomeComponent },
        { path: 'add-job', component: AddjobComponent },
        { path: 'view-job', component: ViewjobComponent },
        { path: 'edit-job/:jobId', component: EditjobComponent },
        { path: '**', redirectTo: 'home' }
]