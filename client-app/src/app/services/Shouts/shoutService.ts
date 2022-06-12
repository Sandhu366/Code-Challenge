import { Shout } from "../../models/Shout";
import endpoints from "../endpoints";
import ServiceBase from "../serviceBase";

class ShoutService extends ServiceBase {
    getAll = (): Promise<Array<Shout>> => {
        this.endpoint = endpoints.shouts.getAll;
        return this.get();
    }

    getById = (id: number): Promise<Shout> => {
        this.endpoint = endpoints.shouts.getById;
        return this.get({ id });
    };

    create = (shout: Shout): Promise<void> => {
        this.endpoint = endpoints.shouts.create;
        return this.post(undefined, shout);
    };

    edit = (shout: Shout): Promise<void> => {
        this.endpoint = endpoints.shouts.edit;
        return this.put({ id: shout.id }, shout);
    };

    deleteShout = (id: number): Promise<void> => {
        this.endpoint = endpoints.shouts.delete;
        return this.delete({ id });
    };
}

export default new ShoutService() as ShoutService;