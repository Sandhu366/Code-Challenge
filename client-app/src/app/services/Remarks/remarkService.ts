import ServiceBase from "../serviceBase";
import { Remark } from '../../models/Remark';
import endpoints from "../endpoints";


class RemarkService extends ServiceBase {
    getAll = (): Promise<Array<Remark>> => {
        this.endpoint = endpoints.remarks.getAll;
        return this.get();
    }

    getById = (id: number): Promise<Remark> => {
        this.endpoint = endpoints.remarks.getById;
        return this.get({ id });
    };

    create = (remark: Remark): Promise<void> => {
        this.endpoint = endpoints.remarks.create;
        return this.post(undefined, remark);
    };

    edit = (remark: Remark): Promise<void> => {
        this.endpoint = endpoints.remarks.edit;
        return this.put({ id: remark.id }, remark);
    };

    deleteRemark = (id: number): Promise<void> => {
        this.endpoint = endpoints.remarks.delete;
        return this.delete({ id });
    };
}

export default new RemarkService() as RemarkService;