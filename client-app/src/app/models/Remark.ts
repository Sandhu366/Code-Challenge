import { action, observable } from "mobx";
import { FormModel } from "./Common/FormModel";

export class Remark extends FormModel {
    @observable public id: number;
    @observable public body: string;
    @observable public shoutId: number;

    constructor() {
        super();
        this.id = 0;
        this.body = '';
        this.shoutId = 0;
    }

    @action SetData(dbData: any): Remark {
        if (!dbData) {
            return this;
        }

        this.id = dbData.Id || dbData.id;
        this.body = dbData.Title || dbData.title;
        this.shoutId = dbData.Description || dbData.description;
        return this;
    }
}