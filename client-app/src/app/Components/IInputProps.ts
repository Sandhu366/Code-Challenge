import { FormModel } from '../models/Common/FormModel';

interface IInputProps {
    value: any;
    name: string;
    type?: string;
    placeholder: string;
    onModelChange: (key: keyof FormModel, value: any) => void;
}

export default IInputProps;