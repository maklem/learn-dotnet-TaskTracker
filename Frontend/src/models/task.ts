export default class TaskModel {
    public id: number = -1
    public name: string = ""
    public due: boolean = false

    public constructor(init?:Partial<TaskModel>) {
        Object.assign(this, init);
    }
}
