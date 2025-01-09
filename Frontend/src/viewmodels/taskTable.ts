import { ref } from 'vue'
import TaskModel from '../models/task'
import type ITaskRepository from '../repositories/ITaskRepository';

export default class TaskTableViewModel {
    public tasks = ref([new TaskModel({id: -1, name: "loading ...", due: false})])

    updateTasks() {
        this.tasksRepository.getTasks().then(
            (taskList) => this.tasks.value = taskList.map((task) => {
                return new TaskModel({"id": task.id, "name":task.name, "due": true});
            })
        )
    }

    tasksRepository: ITaskRepository
    public constructor(tasksRepository: ITaskRepository){
        this.tasksRepository = tasksRepository
        this.updateTasks()
    }

    public onAdd(name: string){
        this.tasksRepository
            .create(name)
            .then(() => {
                this.updateTasks()
            })
    }

    public onDelete(id: number){
        this.tasksRepository
            .delete(id)
            .then(() => {
                this.updateTasks()
            })
    }
}
