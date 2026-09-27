import axios from 'axios'
import type { TodoItem, CreateTodoRequest } from '@/types'

const apiClient = axios.create({
  baseURL: '/api',
  headers: {
    'Content-Type': 'application/json'
  }
})

/// <summary>
/// 待办事项 API 服务
/// </summary>
export const todoApi = {
  /** 获取所有待办事项 */
  getAll(): Promise<TodoItem[]> {
    return apiClient.get<TodoItem[]>('/todo').then(res => res.data)
  },

  /** 根据 ID 获取待办事项 */
  getById(id: number): Promise<TodoItem> {
    return apiClient.get<TodoItem>(`/todo/${id}`).then(res => res.data)
  },

  /** 创建新的待办事项 */
  create(data: CreateTodoRequest): Promise<TodoItem> {
    return apiClient.post<TodoItem>('/todo', data).then(res => res.data)
  },

  /** 更新待办事项 */
  update(id: number, data: TodoItem): Promise<void> {
    return apiClient.put(`/todo/${id}`, data)
  },

  /** 删除待办事项 */
  delete(id: number): Promise<void> {
    return apiClient.delete(`/todo/${id}`)
  }
}
