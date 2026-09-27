<template>
  <div class="app">
    <header class="app-header">
      <h1>📝 全栈待办事项应用</h1>
      <nav>
        <router-link to="/">首页</router-link>
      </nav>
    </header>
    <main class="app-main">
      <router-view />
    </main>
  </div>
</template>

<script setup lang="ts">
</script>

<style scoped>
.app {
  max-width: 800px;
  margin: 0 auto;
  padding: 2rem;
}

.app-header {
  text-align: center;
  margin-bottom: 2rem;
  padding-bottom: 1rem;
  border-bottom: 2px solid #e0e0e0;
}

.app-header h1 {
  color: #333;
  margin-bottom: 0.5rem;
}

.app-header nav a {
  color: #42b883;
  text-decoration: none;
  font-weight: bold;
}

.app-header nav a:hover {
  text-decoration: underline;
}
</style>
