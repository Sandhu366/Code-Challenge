import { createContext } from "react";
import { Remark } from '../models/Remark';
import RemarkService from '../services/Remarks/remarkService';
import { action, computed, makeObservable, observable, runInAction } from "mobx";

class RemarkStore {
    @observable target: string;
    @observable isLoading: boolean;
    @observable isSubmitting: boolean;
    @observable isRemarkSelected: boolean;
    @observable remarks: Array<Remark>;
    @observable remark: Remark | undefined;

    constructor() {
        makeObservable(this);

        this.target = '';
        this.isLoading = false;
        this.isSubmitting = false;
        this.remark = new Remark();
        this.isRemarkSelected = false;
        this.remarks = new Array<Remark>();
    }

    @action loadRemarks = async () => {
        this.remarks = new Array<Remark>();
        this.isLoading = true;
        try {
            const response = await RemarkService.getAll();
            runInAction(() => {
                this.remarks.push(...response.map((x: Remark) => new Remark().SetData(x)));
            });
        } catch (error) {
            console.log(error);
        } finally {
            runInAction(() => this.isLoading = false);
        }
    };

    @action loadRemark = async (id: number) => {
        if (!id) {
            this.remark = new Remark();
            return;
        }

        this.remark = this.getRemark(id);
        if (this.remark && this.remark.id) {
            return;
        }

        this.isLoading = true;

        try {
            const response = await RemarkService.getById(id);
            runInAction(() => {
                this.remark = new Remark().SetData(response);
            });
        } catch (error) {
        } finally {
            runInAction(() => {
                this.isLoading = false;
            });
        }
    };

    getRemark = (id: number) => {
        return this.remarks.find(x => x.id === id) || new Remark();
    };

    @computed get getSelectedRemark() {
        return this.remark || new Remark();
    };

    @action selectRemark = (id?: number) => {
        if (id) {
            this.remark = this.remarks.find(x => x.id === id);
            this.isRemarkSelected = true;
            return;
        }
        this.remark = undefined;
        this.isRemarkSelected = false;
    };

    @action deleteRemark = async (id: number) => {
        this.target = id.toString();
        this.isSubmitting = true;
        try {
            await RemarkService.deleteRemark(id);
            await this.loadRemarks();
        } catch (error) {
            console.log(error);
        } finally {
            runInAction(() => this.isSubmitting = false);
        }
    };

    @action editRemark = async (remark: Remark) => {
        this.isSubmitting = true;
        try {
            await RemarkService.edit(remark);
        } catch (error) {
            console.log(error);
        } finally {
            runInAction(() => this.isSubmitting = false);
        }
    };

    @action submitRemark = async (remark: Remark) => {
        this.isSubmitting = true;
        try {
            await RemarkService.create(remark);
            await this.loadRemarks();
        } catch (error) {
            console.log(error);
        } finally {
            runInAction(() => this.isSubmitting = false);
        }
    };
}

export default createContext(new RemarkStore());