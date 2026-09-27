<template>
  <div class="home">
    <h2>待办事项列表</h2>

    <!-- 新建待办表单 -->
    <div class="create-form">
      <input
        v-model="newTodo.title"
        type="text"
        placeholder="输入待办事项标题..."
        @keyup.enter="addTodo"
      />
      <input
        v-model="newTodo.description"
        type="text"
        placeholder="描述（可选）"
        @keyup.enter="addTodo"
      />
      <button @click="addTodo" :disabled="!newTodo.title.trim()">
        添加
      </button>
    </div>

    <!-- 加载状态 -->
    <p v-if="loading" class="status">加载中...</p>
    <p v-if="error" class="status error">{{ error }}</p>

    <!-- 待办列表 -->
    <ul class="todo-list">
      <li v-for="todo in todos" :key="todo.id" :class="{ completed: todo.isCompleted }">
        <div class="todo-content">
          <input
            type="checkbox"
            :checked="todo.isCompleted"
            @change="toggleTodo(todo)"
          />
          <div class="todo-info">
            <strong>{{ todo.title }}</strong>
            <p v-if="todo.description">{{ todo.description }}</p>
            <small>创建于: {{ new Date(todo.createdAt).toLocaleString() }}</small>
          </div>
        </div>
        <button class="delete-btn" @click="deleteTodo(todo.id)">删除</button>
      </li>
    </ul>

    <p v-if="!loading && todos.length === 0" class="empty">暂无待办事项，请添加！</p>
  </div>
</template>

<script setup lang="ts">
import { ref, reactive, onMounted } from 'vue'
import { todoApi } from '@/api'
import type { TodoItem, CreateTodoRequest } from '@/types'

const todos = ref<TodoItem[]>([])
const loading = ref(false)
const error = ref('')

const newTodo = reactive<CreateTodoRequest>({
  title: '',
  description: ''
})

/** 加载所有待办事项 */
async function loadTodos() {
  loading.value = true
  error.value = ''
  try {
    todos.value = await todoApi.getAll()
  } catch (e) {
    error.value = '加载待办事项失败，请确保后端服务已启动'
    console.error(e)
  } finally {
    loading.value = false
  }
}

/** 添加新的待办事项 */
async function addTodo() {
  if (!newTodo.title.trim()) return
  try {
    await todoApi.create({
      title: newTodo.title,
      description: newTodo.description || undefined
    })
    newTodo.title = ''
    newTodo.description = ''
    await loadTodos()
  } catch (e) {
    error.value = '添加待办事项失败'
    console.error(e)
  }
}

/** 切换待办完成状态 */
async function toggleTodo(todo: TodoItem) {
  try {
    await todoApi.update(todo.id, { ...todo, isCompleted: !todo.isCompleted })
    await loadTodos()
  } catch (e) {
    error.value = '更新待办事项失败'
    console.error(e)
  }
}

/** 删除待办事项 */
async function deleteTodo(id: number) {
  try {
    await todoApi.delete(id)
    await loadTodos()
  } catch (e) {
    error.value = '删除待办事项失败'
    console.error(e)
  }
}

onMounted(() => {
  loadTodos()
})
</script>

<style scoped>
.home {
  padding: 1rem 0;
}

h2 {
  color: #333;
  margin-bottom: 1.5rem;
}

.create-form {
  display: flex;
  gap: 0.5rem;
  margin-bottom: 1.5rem;
}

.create-form input {
  padding: 0.5rem 0.75rem;
  border: 1px solid #ddd;
  border-radius: 4px;
  font-size: 0.95rem;
}

.create-form input:first-child {
  flex: 2;
}

.create-form input:nth-child(2) {
  flex: 3;
}

.create-form button {
  padding: 0.5rem 1.5rem;
  background-color: #42b883;
  color: white;
  border: none;
  border-radius: 4px;
  cursor: pointer;
  font-size: 0.95rem;
}

.create-form button:hover:not(:disabled) {
  background-color: #38a373;
}

.create-form button:disabled {
  opacity: 0.5;
  cursor: not-allowed;
}

.status {
  text-align: center;
  padding: 1rem;
  color: #666;
}

.status.error {
  color: #e74c3c;
}

.todo-list {
  list-style: none;
  padding: 0;
}

.todo-list li {
  display: flex;
  align-items: center;
  justify-content: space-between;
  padding: 1rem;
  margin-bottom: 0.5rem;
  background: #f9f9f9;
  border-radius: 6px;
  border: 1px solid #eee;
  transition: background 0.2s;
}

.todo-list li:hover {
  background: #f0f0f0;
}

.todo-list li.completed .todo-info strong {
  text-decoration: line-through;
  color: #999;
}

.todo-content {
  display: flex;
  align-items: flex-start;
  gap: 0.75rem;
}

.todo-info p {
  margin: 0.25rem 0;
  color: #666;
  font-size: 0.9rem;
}

.todo-info small {
  color: #999;
  font-size: 0.8rem;
}

.delete-btn {
  padding: 0.3rem 0.8rem;
  background-color: #e74c3c;
  color: white;
  border: none;
  border-radius: 4px;
  cursor: pointer;
  font-size: 0.85rem;
}

.delete-btn:hover {
  background-color: #c0392b;
}

.empty {
  text-align: center;
  color: #999;
  padding: 2rem;
  font-style: italic;
}
</style>
