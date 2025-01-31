<script setup lang="ts">
import { ref, provide } from 'vue'
import TaskTable from "./components/TaskTable.vue"
import TaskRepository from "./repositories/TaskRepository"
import TaskTableViewModel from './viewmodels/taskTable'
import TaskEditViewModel from './viewmodels/taskEdit'
import EditTask from './components/EditTask.vue'

const tasksRepository = new TaskRepository()
provide('tasksRepository', tasksRepository)

const taskTableViewModel = new TaskTableViewModel(tasksRepository)
const taskEditViewModel = new TaskEditViewModel(tasksRepository)

const isInEditMode = ref(false)
</script>

<template>
  <TaskTable
    v-if="!isInEditMode"
    msg="My Tasks"
    :tasks=taskTableViewModel.tasks.value
    @add-task="(name) => {taskTableViewModel.onAdd(name)}"
    @del-task="(id) => {taskTableViewModel.onDelete(id)}"
    @do-task="(id) => {taskTableViewModel.onDo(id)}"
    @edit-task="(id) => {taskEditViewModel.reset(id); isInEditMode=true}"
    />
  <EditTask 
    v-if="isInEditMode"
    msg="Edit Task"
    :task=taskEditViewModel.task.value
    @cancel="isInEditMode = false"
    @save-task="(id, name) => {
      taskEditViewModel.onSave(id, name).then(()=>{
        isInEditMode=false;
        taskTableViewModel.updateTasks();
      });
      }"
  />
</template>

<style scoped>
</style>
