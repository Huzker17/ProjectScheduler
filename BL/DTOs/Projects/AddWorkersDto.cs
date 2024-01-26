using DAL.Models;

namespace BL.DTOs.Projects;
public record AddWorkersDto(int ProjectId, IEnumerable<User> Workers);
