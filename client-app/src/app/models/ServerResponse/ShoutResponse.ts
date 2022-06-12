import { IRemarkResponse } from "./RemarkResponse";

export interface IShoutResponse {
    Id: number;
    Body: string;
    UpVotes: number;
    DownVotes: number;
    Remarks: Array<IRemarkResponse>;
}