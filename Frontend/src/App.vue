<script setup lang="ts">
import { provide } from 'vue'
import TaskTable from "./components/TaskTable.vue"
import TaskRepository from "./repositories/TaskRepository"
import TaskTableViewModel from './viewmodels/taskTable'

const tasksRepository = new TaskRepository()
provide('tasksRepository', tasksRepository)

const taskTableViewModel = new TaskTableViewModel(tasksRepository)
</script>

<template>
  <TaskTable
    msg="My Tasks"
    :tasks=taskTableViewModel.tasks.value
    @add-task="(name) => {taskTableViewModel.onAdd(name)}"
    @del-task="(id) => {taskTableViewModel.onDelete(id)}"
    @do-task="(id) => {taskTableViewModel.onDo(id)}"
    />
</template>

<style scoped>
</style>
