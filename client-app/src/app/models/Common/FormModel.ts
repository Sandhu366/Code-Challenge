import { action } from "mobx";

interface IFormModel {
    SetData: (dbData: any) => void;
    OnModelChange: (key: keyof FormModel, value: any) => void;
}

export abstract class FormModel implements IFormModel {
    public createdOn: string = '';

    @action OnModelChange = (key: keyof FormModel, value: any): void => {
        this[key] = value;
    }

    SetData(dbData: any) {
    };
}