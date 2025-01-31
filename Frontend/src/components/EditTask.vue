<script setup lang="ts">
import TaskModel from '../models/task'

defineProps<{
    msg: string
    task: TaskModel
}>()
defineEmits<{
    (e: 'cancel'): void
    (e: 'saveTask', id: number, name: string): void
}>()
</script>

<script lang="ts">
</script>

<template>
    <h1>{{ msg }}</h1>
    <table density="compact">
        <tbody>
            <tr>
                <td>ID</td>
                <td>{{ task.id }}</td>
            </tr>
            <tr>
                <td>Name</td>
                <td><input v-model="task.name" /></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <button @click="$emit('cancel')">cancel</button>
                    <button @click="$emit('saveTask', task.id, task.name)">save</button>
                </td>
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