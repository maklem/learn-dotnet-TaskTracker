<script setup lang="ts">
import { ref, onMounted } from 'vue'
import axios from 'axios'

defineProps<{ msg: string }>()

const backend = "api/"
const tasks = ref( [{'id': -1, "name": "nullstring"}])

onMounted(() =>{
    axios
    .get(backend + 'task')
    .then((response) => {tasks.value = response.data})
    }
)
</script>

<template>
    <h1>{{ msg }}</h1>
    <div v-for="task in tasks">{{task.id}} => {{ task.name }}</div>
</template>