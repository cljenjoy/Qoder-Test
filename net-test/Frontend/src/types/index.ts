/// <summary>
/// 待办事项类型定义，与后端 TodoItem 模型对应
/// </summary>
export interface TodoItem {
  id: number
  title: string
  description?: string
  isCompleted: boolean
  createdAt: string
}

/// <summary>
/// 创建待办事项的请求体（不含 id 和 createdAt，由后端生成）
/// </summary>
export interface CreateTodoRequest {
  title: string
  description?: string
  isCompleted?: boolean
}
