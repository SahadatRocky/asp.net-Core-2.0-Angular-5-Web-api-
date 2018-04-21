

import { Component } from "@angular/core";
import { JobDataService } from "../../services/job.dataservice";
import { Router } from "@angular/router";
import { JobView } from "../../model/developerjob";

@Component({
    selector: 'view-job',
    templateUrl: './viewjob.component.html',
    styleUrls: ['./viewjob.component.css']
})

export class ViewjobComponent {
    public jobs: JobView[];

    public constructor(private dataService: JobDataService, private router: Router) {
        this.viewjob();
    }

    edit(jobId:number) {
        if (jobId && jobId > 0) {
            this.router.navigate(['/edit-job/'+jobId]);
        }

    }


    delete(jobId: number) {
        //alert(jobId);
        if (jobId && jobId > 0) {
            let message = window.confirm("Are you sure you want to delete this Record?");
            if (message == true) {
                this.dataService.removeDeveloperJob(jobId)
                    .subscribe(res => {
                        if (res.ok) {
                            alert("Record Delete Successfully");
                            this.viewjob();
                        }
                    }, error => {
                        console.error(error);
                    });
            }
        }

    }

    private viewjob() {
        this.dataService.getAllDeveloperJob()
            .subscribe(res => {
                this.jobs = res.json() as JobView[];
                console.log(this.jobs);
            }, error => {
                console.error(error);
            });
    }


}