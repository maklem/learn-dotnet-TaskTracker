import DatabaseTaskModel from "../models/databaseTask"

export default interface ITaskRepository {
    getTasks: () => Promise<DatabaseTaskModel[]>;

    create: (name: string) => Promise<void>;
    delete: (id: number) => Promise<void>;
    do: (id: number) => Promise<void>;
}
