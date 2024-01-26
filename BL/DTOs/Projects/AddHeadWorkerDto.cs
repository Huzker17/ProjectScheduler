using DAL.Models;

namespace BL.DTOs.Projects;
public record AddHeadWorkerDto(int ProjectId, User User);
