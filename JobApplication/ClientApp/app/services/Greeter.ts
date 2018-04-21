export interface IGreeter {
    greeter(name: string): string;
}

export class Greeter implements IGreeter {
    constructor() {

    }
    greeter(name: string): string {
        return "Hello" + name;
    }


}