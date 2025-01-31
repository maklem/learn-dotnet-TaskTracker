import { ref } from 'vue'
import TaskModel from '../models/task'
import type ITaskRepository from '../repositories/ITaskRepository';
import isTaskDueAt from '../logic/taskLogic';

export default class TaskEditViewModel {
    task = ref(new TaskModel())
    tasksRepository: ITaskRepository
    public constructor(tasksRepository: ITaskRepository){
        this.tasksRepository = tasksRepository
    }

    public reset(id: number){
        this.tasksRepository.getTasks().then(
            (taskList) => {
                let tasks = taskList
                    .map((task) => {return new TaskModel({"id": task.id, "name":task.name, "due": isTaskDueAt(task, new Date(Date.now()))})})
                    .filter((task: TaskModel) => {return task.id == id})
                this.task.value = tasks.length > 0 ? tasks[0] : new TaskModel
            }
        )
    }

    public onSave(id: number, name: string) : Promise<void> {
        var result = new Promise<void>((resolve,_) => {
            this.tasksRepository
            .update(id, name)
            .then(() => { resolve() })
            .catch(()=> { resolve()  })
        })
        return result;
    }
}
