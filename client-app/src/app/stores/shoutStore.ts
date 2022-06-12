import { createContext } from "react";
import { action, computed, makeObservable, observable, runInAction } from "mobx";
import { Shout } from "../models/Shout";
import ShoutService from '../services/Shouts/shoutService';

class ShoutStore {
    @observable target: string;
    @observable isLoading: boolean;
    @observable isSubmitting: boolean;
    @observable isShoutSelected: boolean;
    @observable shouts: Array<Shout>;
    @observable shout: Shout | undefined;

    constructor() {
        makeObservable(this);

        this.target = '';
        this.isLoading = false;
        this.isSubmitting = false;
        this.shout = new Shout();
        this.isShoutSelected = false;
        this.shouts = new Array<Shout>();
    }

    @action loadShouts = async () => {
        this.shouts = new Array<Shout>();
        this.isLoading = true;
        try {
            const response = await ShoutService.getAll();
            runInAction(() => {
                this.shouts.push(...response.map((x: Shout) => new Shout().SetData(x)));
            });
        } catch (error) {
            console.log(error);
        } finally {
            runInAction(() => this.isLoading = false);
        }
    };

    @action loadShout = async (id: number) => {
        if (!id) {
            this.shout = new Shout();
            return;
        }

        this.shout = this.getShout(id);
        if (this.shout && this.shout.id) {
            return;
        }

        this.isLoading = true;

        try {
            const response = await ShoutService.getById(id);
            runInAction(() => {
                this.shout = new Shout().SetData(response);
            });
        } catch (error) {
        } finally {
            runInAction(() => {
                this.isLoading = false;
            });
        }
    };

    getShout = (id: number) => {
        return this.shouts.find(x => x.id === id) || new Shout();
    };

    @computed get getSelectedShout() {
        return this.shout || new Shout();
    };

    @action selectShout = (id?: number) => {
        if (id) {
            this.shout = this.shouts.find(x => x.id === id);
            this.isShoutSelected = true;
            return;
        }
        this.shout = undefined;
        this.isShoutSelected = false;
    };

    @action deleteShout = async (id: number) => {
        this.target = id.toString();
        try {
            await ShoutService.deleteShout(id);
            await this.loadShouts();
        } catch (error) {
            console.log(error);
        }
    };

    @action editShout = async (Shout: Shout) => {
        this.isLoading = true;
        try {
            await ShoutService.edit(Shout);
        } catch (error) {
            console.log(error);
        }
        this.isLoading = false;
    };

    @action submitShout = async (Shout: Shout) => {
        this.isSubmitting = true;
        try {
            await ShoutService.create(Shout);
            await this.loadShouts();
        } catch (error) {
            console.log(error);
        } finally {
            runInAction(() => this.isSubmitting = false);
        }
    };
}

export default createContext(new ShoutStore());