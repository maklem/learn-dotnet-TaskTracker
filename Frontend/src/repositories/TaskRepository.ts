import axios from 'axios'

import DatabaseTaskModel from "../models/databaseTask"
import type ITaskRepository from './ITaskRepository';

const backend = "api/"

export default class TaskRepository implements ITaskRepository {
    async getTasks(): Promise<DatabaseTaskModel[]>
    {
        let response = await axios.get(backend + 'task/')

        if(response.status == 200)
        {
            return response.data.map( (row: any) => {
                return new DatabaseTaskModel(row);
            }).filter(
                (entry: DatabaseTaskModel) => {
                    return entry.id != -1
                }
            )
        }
        return [] as DatabaseTaskModel[]
    }

    async create(name:string): Promise<void>{
        var payload = new DatabaseTaskModel({"name": name})
        console.log(payload)
        await axios.post(backend + 'task/', payload)
    }

    async delete(id:number): Promise<void>{
        await axios.delete(backend + 'task/' + id.toString())
    }
}