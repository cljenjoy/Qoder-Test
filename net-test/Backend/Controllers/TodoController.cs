using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

/// <summary>
/// 待办事项 REST API 控制器
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    // 使用内存存储模拟数据库
    private static readonly List<TodoItem> _items = new()
    {
        new TodoItem { Id = 1, Title = "学习 .NET 6", Description = "学习 ASP.NET Core Web API 开发", IsCompleted = false, CreatedAt = DateTime.UtcNow },
        new TodoItem { Id = 2, Title = "学习 Vue 3", Description = "学习 Vue 3 Composition API 和 TypeScript", IsCompleted = false, CreatedAt = DateTime.UtcNow },
        new TodoItem { Id = 3, Title = "完成全栈项目", Description = "将前后端整合为完整项目", IsCompleted = false, CreatedAt = DateTime.UtcNow }
    };

    private static long _nextId = 4;

    /// <summary>
    /// 获取所有待办事项
    /// </summary>
    [HttpGet]
    public ActionResult<IEnumerable<TodoItem>> GetAll()
    {
        return Ok(_items);
    }

    /// <summary>
    /// 根据 ID 获取待办事项
    /// </summary>
    [HttpGet("{id}")]
    public ActionResult<TodoItem> GetById(long id)
    {
        var item = _items.Find(i => i.Id == id);
        if (item == null)
        {
            return NotFound();
        }
        return Ok(item);
    }

    /// <summary>
    /// 创建新的待办事项
    /// </summary>
    [HttpPost]
    public ActionResult<TodoItem> Create(TodoItem item)
    {
        item.Id = _nextId++;
        item.CreatedAt = DateTime.UtcNow;
        _items.Add(item);
        return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
    }

    /// <summary>
    /// 更新待办事项
    /// </summary>
    [HttpPut("{id}")]
    public ActionResult Update(long id, TodoItem updatedItem)
    {
        var item = _items.Find(i => i.Id == id);
        if (item == null)
        {
            return NotFound();
        }

        item.Title = updatedItem.Title;
        item.Description = updatedItem.Description;
        item.IsCompleted = updatedItem.IsCompleted;

        return NoContent();
    }

    /// <summary>
    /// 删除待办事项
    /// </summary>
    [HttpDelete("{id}")]
    public ActionResult Delete(long id)
    {
        var item = _items.Find(i => i.Id == id);
        if (item == null)
        {
            return NotFound();
        }

        _items.Remove(item);
        return NoContent();
    }
}
