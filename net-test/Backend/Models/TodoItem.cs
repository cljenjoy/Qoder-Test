namespace Backend.Models;

/// <summary>
/// 待办事项模型
/// </summary>
public class TodoItem
{
    /// <summary>
    /// 唯一标识，哈哈
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// 标题
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// 描述
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// 是否完成
    /// </summary>
    public bool IsCompleted { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
