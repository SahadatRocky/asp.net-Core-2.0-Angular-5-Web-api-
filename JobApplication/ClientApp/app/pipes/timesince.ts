import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'timesince' })

export class TimeSince implements PipeTransform {
    transform(createdDate: Date) {
        let timeSinceCalculator: TimeSinceCalculator = new TimeSinceCalculator();
        return timeSinceCalculator.getTimeSince(createdDate);
    }
}

class TimeSinceCalculator {

    private totalSecondInYear: number = 31536000;
    private totalSecondInMonth: number = 2592000;
    private totalSecondInDay: number = 86400;
    private totalSecondInHour: number = 3600;

    private getDifferenceFromTodayInSeconds(inputDate: Date): number {
        let inputDateInSeconds: number = Math.floor(new Date(inputDate).getTime() / 1000);
        let toDaysDateInSeconds: number = Math.floor(new Date().getTime() / 1000);
        var elapseDateInSeconds = toDaysDateInSeconds - inputDateInSeconds;
        console.log("Elapse time :" + elapseDateInSeconds);
        return Math.floor(elapseDateInSeconds);
    }

    getTimeSince(date: Date): string {

        let interval: number;
        let seconds = this.getDifferenceFromTodayInSeconds(date);
        interval = Math.floor(seconds / this.totalSecondInYear);
        if (interval > 1) {
            return interval + " years ago";
        }
        interval = Math.floor(seconds / this.totalSecondInMonth);
        if (interval > 1) {
            return interval + " months ago";
        }
        interval = Math.floor(seconds / this.totalSecondInDay);
        if (interval > 1) {
            return interval + " days ago";
        }
        interval = Math.floor(seconds / this.totalSecondInHour);
        if (interval > 1) {
            return interval + " hours ago";
        }
        interval = Math.floor(seconds / 60);
        if (interval > 1) {
            return interval + " minutes ago";
        }
        return interval + " seconds ago";

    }


}