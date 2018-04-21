export interface State {

    iso: string;
    name: string;
}

export type Region = "Asia" | "Europe" | "Africa" | "Oceania" | "America" | "Anterctica";

export interface Country {
    iso: string;
    name: string;
    haspostalcode: boolean;
    region: Region;
    state: State[];
    zipRegex: string | number;
}

export const countries: Country[] = [
    {
        "iso": "AF",
        "name": "Afganistan",
        "haspostalcode": true,
        "region": "Asia",
        "state":[],
        "zipRegex": "^(\\d{4})$"


    },
    {
        "iso": "AX",
        "name": "Aland Island",
        "haspostalcode": true,
        "region": "Europe",
        "state": [],
        "zipRegex": "^(\\d{5})$"

    },

     {
        "iso": "AL",
        "name": "Ice Island",
        "haspostalcode": true,
        "region": "Europe",
        "state": [],
        "zipRegex": "^(\\d{6})$"

    },
     {
         "iso": "AF",
         "name": "zimbabu",
         "haspostalcode": true,
         "region": "Africa",
         "state": [],
         "zipRegex": "^(\\d{7})$"


     },
     {
         "iso": "AX",
         "name": "kaniya",
         "haspostalcode": true,
         "region": "Africa",
         "state": [],
         "zipRegex": "^(\\d{8})$"

     },

     {
         "iso": "AL",
         "name": "England",
         "haspostalcode": true,
         "region": "Europe",
         "state": [],
         "zipRegex": "^(\\d{6})$"

     }



]