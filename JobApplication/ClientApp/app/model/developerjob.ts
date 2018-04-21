export class CompanyAddress {
    constructor(
        public id: number,
        public address1: string,
        public address2: string,
        public city: string,
        public state: string,
        public zipCode: string,
        public countryName:string

    ) {}
}

export class DeveloperJob{
    constructor(
        public jobTitle: string,
        public companyName:string,
        public companyAddress: CompanyAddress,
        public salaryRange: string,
        public remoteOptions: boolean,
        public equitySharing: boolean,
        public jobTypeId: number,
        public experienceLavel: string,
        public industryId: number,
        public companySize: number,
        public companyTypeId: number,
        public jobDescription:string 
        
    ) { }
}


export class JobView {
    constructor(
        public developerjobId: number,
        public id: number,
        public jobTitle: string,
        public  companyName:string,
        public companyAddress: CompanyAddress,
        public salaryRange: string,
        public jobTypeName: string,
        public experienceLavel: string,
        public industryName: string,
        public companySize: number,
        public companyTypeName: string

    ) { }
}