
export class CarIdCardData {
    public fullName: string;
    public certificateSeries: string;
    public certificateNumber: string;

    constructor() {

    }
}

export class UserCar {
    public id: number;
    public userId: number;
    public name: string;
    public carIdCardData: CarIdCardData;
    public penaltyCount?: number;

    constructor() {

    }
}
