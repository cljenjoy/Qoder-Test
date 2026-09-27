# 全栈待办事项应用

前后端分离的全栈项目，后端使用 C# .NET 6 Web API，前端使用 Vue 3 + TypeScript + Vite。

## 项目结构

```
net-test/
├── Backend/                        # 后端 - .NET 6 Web API
│   ├── Controllers/
│   │   └── TodoController.cs       # 待办事项 REST API 控制器
│   ├── Models/
│   │   └── TodoItem.cs             # 数据模型
│   ├── Properties/
│   │   └── launchSettings.json     # 启动配置
│   ├── Program.cs                  # 应用入口
│   ├── Backend.csproj              # 项目文件
│   ├── FullStackDemo.sln           # 解决方案文件
│   ├── appsettings.json            # 应用配置
│   └── appsettings.Development.json
│
├── Frontend/                       # 前端 - Vue 3 + TypeScript
│   ├── public/
│   │   └── vite.svg
│   ├── src/
│   │   ├── api/
│   │   │   └── index.ts            # API 请求封装 (Axios)
│   │   ├── components/             # 公共组件
│   │   ├── router/
│   │   │   └── index.ts            # Vue Router 路由配置
│   │   ├── types/
│   │   │   └── index.ts            # TypeScript 类型定义
│   │   ├── views/
│   │   │   └── HomeView.vue        # 首页视图（待办列表）
│   │   ├── App.vue                 # 根组件
│   │   ├── main.ts                 # 应用入口
│   │   ├── style.css               # 全局样式
│   │   └── env.d.ts                # 环境类型声明
│   ├── index.html                  # HTML 入口
│   ├── package.json                # 依赖配置
│   ├── tsconfig.json               # TypeScript 配置
│   ├── tsconfig.node.json
│   └── vite.config.ts              # Vite 构建配置
│
└── .gitignore
```

## 快速开始

### 前置要求

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Node.js](https://nodejs.org/) (>= 16)
- npm (>= 8)

### 启动后端

```bash
cd Backend
dotnet run
```

后端默认运行在：
- HTTP: http://localhost:5001
- HTTPS: https://localhost:7001
- Swagger UI: http://localhost:5001/swagger

### 启动前端

```bash
cd Frontend
npm install
npm run dev
```

前端默认运行在：http://localhost:5173

> 前端已配置 Vite 代理，`/api` 开头的请求会自动转发到后端 `http://localhost:5001`。

## API 接口

| 方法     | 路径              | 说明           |
| -------- | ----------------- | -------------- |
| GET      | /api/todo         | 获取所有待办   |
| GET      | /api/todo/{id}    | 获取单个待办   |
| POST     | /api/todo         | 创建待办       |
| PUT      | /api/todo/{id}    | 更新待办       |
| DELETE   | /api/todo/{id}    | 删除待办       |

## 技术栈

### 后端
- **框架**: ASP.NET Core 6.0 (Minimal Hosting)
- **API 文档**: Swagger / Swashbuckle
- **跨域**: CORS 配置

### 前端
- **框架**: Vue 3 (Composition API + `<script setup>`)
- **语言**: TypeScript
- **构建工具**: Vite 5
- **HTTP 客户端**: Axios
- **路由**: Vue Router 4
