using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models;
public class User
{
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int Id { get; set; }

	/// <summary>
	/// Имя
	/// </summary>
	public string Name { get; set; }

	/// <summary>
	/// Фамилия
	/// </summary>
	public string Surname { get; set; }

	/// <summary>
	/// Отчество
	/// </summary>
	public string Patronymic { get; set; }

	/// <summary>
	/// Почтовый индекс
	/// </summary>
	public string Email { get; set; }
	public IEnumerable<Project> Projects { get; set; }
	public User(string name, string surname, string patronymic, string email)
	{
		Name = name;
		Surname = surname;
		Patronymic = patronymic;
		Email = email;
		Projects = new List<Project>();
	}
}
