using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models;
public class Project
{
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int Id { get; set; }

	/// <summary>
	/// Название проекта
	/// </summary>
	public string Name { get; set; }

	/// <summary>
	/// Заказчик
	/// </summary>
	public string Customer { get; set; }

	/// <summary>
	/// Исполнитель
	/// </summary>
	public string Executor { get; set; }

	/// <summary>
	/// Сотрудники
	/// </summary>
	public IEnumerable<User> Workers { get; set; }

	[ForeignKey(nameof(User))]
	public int UserId { get; set; }
	/// <summary>
	/// Управляющий
	/// </summary>
	public User HeadWorker { get; set; }

	/// <summary>
	/// Дата старта
	/// </summary>
	public DateTime StartDate { get; set; }

	/// <summary>
	/// Дата окончания
	/// </summary>
	public DateTime EndDate { get; set; }

	/// <summary>
	/// Приоритет
	/// </summary>
	public int Priority { get; set; }

	public Project(string name, string customer, string executor, DateTime endDate, int priority)
	{
		Name = name;
		Customer = customer;
		Executor = executor;
		Workers = new List<User>();
		StartDate = DateTime.UtcNow;
		EndDate = endDate;
		Priority = priority;
	}
}
