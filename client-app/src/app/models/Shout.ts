import { observable, action } from "mobx";
import { FormModel } from "./Common/FormModel";
import { Remark } from "./Remark";

export class Shout extends FormModel {
    @observable public id: number;
    @observable public body: string;
    @observable public upVotes: number;
    @observable public downVotes: number;
    @observable public remarks: Array<Remark>;

    constructor() {
        super();
        this.id = 0;
        this.body = '';
        this.upVotes = 0;
        this.downVotes = 0;
        this.remarks = [];
    }

    @action SetData(dbData: any): Shout {
        if (!dbData) {
            return this;
        }

        this.id = dbData.Id || dbData.id;
        this.body = dbData.Body || dbData.body;
        this.upVotes = dbData.UpVotes || dbData.upvotes;
        this.downVotes = dbData.DownVotes || dbData.downvotes;
        this.remarks = dbData.Remarks || dbData.remarks;
        return this;
    }
}