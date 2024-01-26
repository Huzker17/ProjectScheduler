using DAL.Models;

namespace BL.DTOs.Projects;
public record UpdateProjectDto(string Name, string Customer, string Executor, IEnumerable<User> Workers, User HeadWorker, DateTime EndDate, int Priority);
