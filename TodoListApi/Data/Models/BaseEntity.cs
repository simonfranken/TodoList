using System.ComponentModel.DataAnnotations;

namespace TodoListApi.Data.Models;

public abstract class BaseEntity
{
    [Key]
    public Guid Id { get; set; }
}