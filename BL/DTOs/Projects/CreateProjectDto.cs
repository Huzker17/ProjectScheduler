using DAL.Models;

namespace BL.DTOs.Projects;
public record CreateProjectDto(string Name, string Customer, string Executor, DateTime EndDate, int Priority);

