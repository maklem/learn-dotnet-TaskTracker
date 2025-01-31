export default class DatabaseTaskModel {
    public id: number = -1
    public name: string = ""
    public to_be_done_at: string = "12:00:00.000"
    public done_at: string | null = null

    public constructor(init?:Partial<DatabaseTaskModel>) {
        Object.assign(this, init);
    }

    public toString(){
        return JSON.stringify(this)
    }
}
