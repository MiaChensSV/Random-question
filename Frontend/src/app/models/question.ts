import { Option } from "./option"
export interface Question {
    questionAnswerId:number,
    questionText:string,
    options: Option[]
}
