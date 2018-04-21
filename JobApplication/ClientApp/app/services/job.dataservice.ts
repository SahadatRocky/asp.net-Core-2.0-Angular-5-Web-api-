

import { Http, Headers, RequestOptions } from "@angular/http";
import { Injectable } from "@angular/core";
import { DeveloperJob } from "../model/developerjob";



@Injectable()
export class JobDataService {
    private baseUrl: string = "http://localhost:50289/api/";
    constructor(private http: Http) {
       
    }

    public saveDeveloperJob(developerjob: DeveloperJob) {
        let headers = new Headers({ 'content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        return this.http.post(this.baseUrl + "DeveloperJobs", developerjob, options);
    }

    public removeDeveloperJob(jobId: number) {
        let url = this.baseUrl + "DeveloperJobs/" + jobId;
        return this.http.delete(url);

    }



    public getAllDeveloperJob() {
        return this.http.get(this.baseUrl + "DeveloperJobs");
    }

    public getAllIndustryTypes() {
        return this.http.get(this.baseUrl +"Industries");
    }

    public getAllCompanyTypes() {
        return this.http.get(this.baseUrl + "CompanyTypes");
    }

    public getAlljobTypes() {
        return this.http.get(this.baseUrl + "JobTypes");
    }

    public getDeveloperJobById(jobId: number) {
        let url = this.baseUrl + "DeveloperJobs/" + jobId;
        return this.http.get(url);
    }

    public editDeveloperJob(jobId: number, developerjob: DeveloperJob) {
        let headers = new Headers({ 'content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        let url = this.baseUrl + "DeveloperJobs/" + jobId;
        return this.http.put(url, developerjob, options);


    }

}