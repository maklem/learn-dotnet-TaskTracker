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

    async update(id: number, name: string): Promise<void>{
        let response = await axios.get(backend + 'task/' + id.toString())

        if(response.status != 200)
        {
            return;
        }
        let payload = new DatabaseTaskModel(response.data);
        payload.name = name;
        await axios.put(backend + 'task/' + id.toString(), payload)
    }

    async do(id: number): Promise<void>{
        let response = await axios.get(backend + 'task/' + id.toString())

        if(response.status != 200)
        {
            return;
        }
        let payload = new DatabaseTaskModel(response.data);
        payload.done_at = new Date(Date.now()).toISOString();
        await axios.put(backend + 'task/' + id.toString(), payload)
    }
}