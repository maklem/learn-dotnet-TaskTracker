<script setup lang="ts">
import { ref, onMounted } from 'vue'
import axios from 'axios'

defineProps<{ msg: string }>()

const backend = "api/"
const message = ref( [{'id': -1, "name": "nullstring"}])

onMounted(() =>{
    axios
    .get(backend + 'task')
    .then((response) => {message.value = response.data})
    }
)
</script>

<template>
    <h1>{{ msg }}</h1>
    <div v-for="title in message">{{title.id}} => {{ title.name }}</div>
</template>