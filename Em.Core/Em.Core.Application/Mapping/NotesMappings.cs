using Em.Core.Application.DTOs.CreateDtos.Notes;
using Em.Core.Application.DTOs.ReadDtos.Notes;
using Em.Core.Application.DTOs.UpdateDtos.Notes;
using Em.Core.Domain.Entities.Notes;

namespace Em.Core.Application.Mapping
{
    public static class NotesMappings
    {
        public static PersonalNote ToEntity(this CreatePersonalNoteDto dto)
        {
            return new PersonalNote
            {
                CompanyId = dto.CompanyId,
                EmployeeId = dto.EmployeeId,
                Title = dto.Title,
                Content = dto.Content,
                IsPinned = dto.IsPinned,
                ReminderAt = dto.ReminderAt,
            };
        }

        public static void MapTo(this UpdatePersonalNoteDto dto, PersonalNote entity)
        {
            entity.Id = dto.Id;
            entity.CompanyId = dto.CompanyId;
            entity.EmployeeId = dto.EmployeeId;
            entity.Title = dto.Title;
            entity.Content = dto.Content;
            entity.IsPinned = dto.IsPinned;
            entity.ReminderAt = dto.ReminderAt;
        }

        public static GetByIdPersonalNoteDto ToGetByIdDto(this PersonalNote entity)
        {
            return new GetByIdPersonalNoteDto
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                EmployeeId = entity.EmployeeId,
                Title = entity.Title,
                Content = entity.Content,
                IsPinned = entity.IsPinned,
                ReminderAt = entity.ReminderAt,
                CreateDate = entity.CreateDate,
                UpdateDate = entity.UpdateDate,
            };
        }

        public static GetAllPersonalNoteDto ToGetAllDto(this PersonalNote entity)
        {
            return new GetAllPersonalNoteDto
            {
                Id = entity.Id,
                EmployeeId = entity.EmployeeId,
                Title = entity.Title,
                IsPinned = entity.IsPinned,
                ReminderAt = entity.ReminderAt,
            };
        }
    }
}
