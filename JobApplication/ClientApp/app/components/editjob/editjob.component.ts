import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, Params } from "@angular/router";
import { FormGroup, FormControl, FormBuilder, Validators } from "@angular/forms";
import { IIndustryType, ICompanyType, IJobType } from "../../model/IndustryType";
import { JobDataService } from "../../services/job.dataservice";
import { DeveloperJob, CompanyAddress } from "../../model/developerjob";
import { UsStates, IUsState } from "../../resorces/usState";
import { countries, Country } from "../../resorces/countries";

@Component({
    selector: 'edit-job',
    templateUrl: './editjob.component.html',
    styleUrls: ['./editjob.component.css']
})

export class EditjobComponent implements OnInit {
    private jobId: number;
    public industrytypes: IIndustryType[];
    public jobTypes: IJobType[];
    public companytypes: ICompanyType[];
    public usstates: IUsState[] = UsStates;
    public Countries: Country[] = countries;
    public devjob: DeveloperJob = this.initialjob();


    ngOnInit(): void {
        this.activatedRoute.params.subscribe((params: Params) => {
            this.jobId = params["jobId"];

            this.dataService.getDeveloperJobById(this.jobId)
                .subscribe(res => {
                    this.devjob = res.json() as DeveloperJob;

                }, error => {

                    console.log(error);
                });
        });
    }

   

    private initialjob() {
        return new DeveloperJob("", "", new CompanyAddress(0, "", "", "", "", "", ""), "", false, false, 0, "", 0, 0, 0, "");
    }


    constructor(private dataService: JobDataService, private router: Router, private activatedRoute:ActivatedRoute) {



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
            this.dataService.editDeveloperJob(this.jobId,this.devjob)
                .subscribe(res => {
                    if (res.ok) {
                        var jobid = res.json().id;
                        alert("Job Edited successfully with jobid :" + jobid);
                        this.router.navigate(['/view-job']);
                    }
                }, error => {
                    console.log(error);
                });
        }
    }



}