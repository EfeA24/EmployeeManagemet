using Em.Core.Application.DTOs.CreateDtos.Notifications;
using Em.Core.Application.DTOs.ReadDtos.Notifications;
using Em.Core.Application.DTOs.UpdateDtos.Notifications;
using Em.Core.Domain.Entities.Notifications;
using Em.Core.Domain.Enums;

namespace Em.Core.Application.Mapping
{
    public static class NotificationsMappings
    {
        public static DeviceToken ToEntity(this CreateDeviceTokenDto dto)
        {
            return new DeviceToken
            {
                CompanyId = dto.CompanyId,
                UserId = dto.UserId,
                Token = dto.Token,
                Platform = dto.Platform,
                IsActive = dto.IsActive,
            };
        }

        public static void MapTo(this UpdateDeviceTokenDto dto, DeviceToken entity)
        {
            entity.Id = dto.Id;
            entity.CompanyId = dto.CompanyId;
            entity.UserId = dto.UserId;
            entity.Token = dto.Token;
            entity.Platform = dto.Platform;
            entity.IsActive = dto.IsActive;
        }

        public static GetByIdDeviceTokenDto ToGetByIdDto(this DeviceToken entity)
        {
            return new GetByIdDeviceTokenDto
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                UserId = entity.UserId,
                Token = entity.Token,
                Platform = entity.Platform,
                IsActive = entity.IsActive,
                CreateDate = entity.CreateDate,
                UpdateDate = entity.UpdateDate,
            };
        }

        public static GetAllDeviceTokenDto ToGetAllDto(this DeviceToken entity)
        {
            return new GetAllDeviceTokenDto
            {
                Id = entity.Id,
                UserId = entity.UserId,
                Platform = entity.Platform,
                IsActive = entity.IsActive,
            };
        }

        public static Notification ToEntity(this CreateNotificationDto dto)
        {
            return new Notification
            {
                CompanyId = dto.CompanyId,
                UserId = dto.UserId,
                Type = dto.Type,
                Title = dto.Title,
                Message = dto.Message,
                RelatedEntityId = dto.RelatedEntityId,
                RelatedEntityType = dto.RelatedEntityType,
            };
        }

        public static void MapTo(this UpdateNotificationDto dto, Notification entity)
        {
            entity.Id = dto.Id;
            entity.CompanyId = dto.CompanyId;
            entity.UserId = dto.UserId;
            entity.Type = dto.Type;
            entity.Title = dto.Title;
            entity.Message = dto.Message;
            entity.IsRead = dto.IsRead;
            entity.ReadAt = dto.ReadAt;
            entity.RelatedEntityId = dto.RelatedEntityId;
            entity.RelatedEntityType = dto.RelatedEntityType;
        }

        public static GetByIdNotificationDto ToGetByIdDto(this Notification entity)
        {
            return new GetByIdNotificationDto
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                UserId = entity.UserId,
                Type = entity.Type,
                Title = entity.Title,
                Message = entity.Message,
                IsRead = entity.IsRead,
                ReadAt = entity.ReadAt,
                RelatedEntityId = entity.RelatedEntityId,
                RelatedEntityType = entity.RelatedEntityType,
                CreateDate = entity.CreateDate,
                UpdateDate = entity.UpdateDate,
            };
        }

        public static GetAllNotificationDto ToGetAllDto(this Notification entity)
        {
            return new GetAllNotificationDto
            {
                Id = entity.Id,
                UserId = entity.UserId,
                Type = entity.Type,
                Title = entity.Title,
                IsRead = entity.IsRead,
                CreateDate = entity.CreateDate,
            };
        }

        public static NotificationDelivery ToEntity(this CreateNotificationDeliveryDto dto)
        {
            return new NotificationDelivery
            {
                CompanyId = dto.CompanyId,
                NotificationId = dto.NotificationId,
                Channel = dto.Channel,
            };
        }

        public static void MapTo(this UpdateNotificationDeliveryDto dto, NotificationDelivery entity)
        {
            entity.Id = dto.Id;
            entity.CompanyId = dto.CompanyId;
            entity.NotificationId = dto.NotificationId;
            entity.Channel = dto.Channel;
            entity.Status = dto.Status;
            entity.RetryCount = dto.RetryCount;
            entity.SentAt = dto.SentAt;
            entity.NextRetryAt = dto.NextRetryAt;
            entity.ErrorMessage = dto.ErrorMessage;
        }

        public static GetByIdNotificationDeliveryDto ToGetByIdDto(this NotificationDelivery entity)
        {
            return new GetByIdNotificationDeliveryDto
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                NotificationId = entity.NotificationId,
                Channel = entity.Channel,
                Status = entity.Status,
                RetryCount = entity.RetryCount,
                SentAt = entity.SentAt,
                NextRetryAt = entity.NextRetryAt,
                ErrorMessage = entity.ErrorMessage,
                CreateDate = entity.CreateDate,
                UpdateDate = entity.UpdateDate,
            };
        }

        public static GetAllNotificationDeliveryDto ToGetAllDto(this NotificationDelivery entity)
        {
            return new GetAllNotificationDeliveryDto
            {
                Id = entity.Id,
                NotificationId = entity.NotificationId,
                Channel = entity.Channel,
                Status = entity.Status,
                RetryCount = entity.RetryCount,
                SentAt = entity.SentAt,
            };
        }

        public static NotificationPreference ToEntity(this CreateNotificationPreferenceDto dto)
        {
            return new NotificationPreference
            {
                CompanyId = dto.CompanyId,
                UserId = dto.UserId,
                NotificationType = dto.NotificationType,
                InAppEnabled = dto.InAppEnabled,
                EmailEnabled = dto.EmailEnabled,
                PushEnabled = dto.PushEnabled,
            };
        }

        public static void MapTo(this UpdateNotificationPreferenceDto dto, NotificationPreference entity)
        {
            entity.Id = dto.Id;
            entity.CompanyId = dto.CompanyId;
            entity.UserId = dto.UserId;
            entity.NotificationType = dto.NotificationType;
            entity.InAppEnabled = dto.InAppEnabled;
            entity.EmailEnabled = dto.EmailEnabled;
            entity.PushEnabled = dto.PushEnabled;
        }

        public static GetByIdNotificationPreferenceDto ToGetByIdDto(this NotificationPreference entity)
        {
            return new GetByIdNotificationPreferenceDto
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                UserId = entity.UserId,
                NotificationType = entity.NotificationType,
                InAppEnabled = entity.InAppEnabled,
                EmailEnabled = entity.EmailEnabled,
                PushEnabled = entity.PushEnabled,
                CreateDate = entity.CreateDate,
                UpdateDate = entity.UpdateDate,
            };
        }

        public static GetAllNotificationPreferenceDto ToGetAllDto(this NotificationPreference entity)
        {
            return new GetAllNotificationPreferenceDto
            {
                Id = entity.Id,
                UserId = entity.UserId,
                NotificationType = entity.NotificationType,
                InAppEnabled = entity.InAppEnabled,
                EmailEnabled = entity.EmailEnabled,
                PushEnabled = entity.PushEnabled,
            };
        }
    }
}
