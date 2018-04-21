import { Component } from '@angular/core';
import { Router } from "@angular/router";
import { FormGroup, FormControl, FormBuilder, Validators } from "@angular/forms";
import { IIndustryType, ICompanyType, IJobType } from "../../model/IndustryType";
import { JobDataService } from "../../services/job.dataservice";
import { DeveloperJob, CompanyAddress } from "../../model/developerjob";
import { UsStates, IUsState } from "../../resorces/usState";
import { countries, Country } from "../../resorces/countries";
@Component({
    selector: 'add-job',
    templateUrl: './addjob.component.html',
    styleUrls: ['./addjob.component.css'],
    providers: [JobDataService]

})
export class AddjobComponent {
    isValid = true;
    public industrytypes: IIndustryType[];
    public jobTypes: IJobType[];
    public companytypes: ICompanyType[];
    public usstates: IUsState[] = UsStates;
    public Countries: Country[] = countries;
    public devjob: DeveloperJob = this.initialjob();
    
    private initialjob() {
        return new DeveloperJob("", "", new CompanyAddress(0, "", "", "", "", "", ""), "", false, false,0,"",0,0,0,"");
    }
   

    constructor(private dataService: JobDataService, private router: Router) {
       // this.loadDefaultForm();
       

        this.dataService.getAllIndustryTypes()
            .subscribe(result => {
                this.industrytypes = result.json() as IIndustryType[];
                console.log(this.industrytypes);
            }, error => console.error(error));


        this.dataService.getAlljobTypes()
            .subscribe(result => {
                this.jobTypes = result.json() as IJobType[];
                console.log(this.jobTypes);
            }, error => console.error(error));


        this.dataService.getAllCompanyTypes()
            .subscribe(result => {
                this.companytypes = result.json() as ICompanyType[];
                console.log(this.companytypes);
            }, error => console.error(error));


    }

    onSubmit(): void {
        console.log(this.devjob);
        if (this.devjob && this.devjob.jobTitle && this.devjob.jobTitle.length > 0) {
            this.dataService.saveDeveloperJob(this.devjob)
                .subscribe(res => {
                    if (res.ok) {
                        var jobid = res.json().id;
                        alert("Job saved successfully with jobid :" + jobid);
                        this.router.navigate(['/view-job']);
                    }
                }, error => {
                    console.log(error);
                });
        }
    }
   
   
    
}

