<script setup lang="ts">
import { ref } from 'vue'
import TaskModel from '../models/task'

defineProps<{
    msg: string
    tasks: TaskModel[]
}>()
defineEmits<{
    (e: 'editTask', id: number): void
    (e: 'doTask', id: number): void
    (e: 'addTask', name: string): void
    (e: 'delTask', id: number): void
}>()

const newTaskName = ref("")

</script>

<template>
    <h1>{{ msg }}</h1>
    <table density="compact">
        <thead>
            <tr>
                <th>Id</th>
                <th>Due?</th>
                <th>Name</th>
                <th>Actions</th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="task in tasks">
                <td>{{ task.id }}</td>
                <td>{{ task.due }}</td>
                <td>{{ task.name }}</td>
                <td>
                    <button :disabled=!task.due @click="$emit('doTask', task.id)">Do!</button>
                    <button @click="$emit('editTask',task.id)">Edit</button>
                    <button @click="$emit('delTask',task.id)">Delete</button>
                </td>
            </tr>
            <tr>
                <td>#?</td>
                <td></td>
                <td><input v-model="newTaskName" /></td>
                <td><button @click="$emit('addTask', newTaskName)">add</button></td>
            </tr>
        </tbody>
    </table>
</template>

<style scoped>
th, td{
    text-align: left;
    padding-left: 10px;
    padding-right: 10px;
}
</style>