using System.Data;
using Dapper;

namespace Em.Infrastructure.Persistance.Dapper
{
    public sealed class DateOnlyTypeHandler : SqlMapper.TypeHandler<DateOnly>
    {
        public override DateOnly Parse(object value)
        {
            return value switch
            {
                DateOnly dateOnly => dateOnly,
                DateTime dateTime => DateOnly.FromDateTime(dateTime),
                _ => DateOnly.FromDateTime(Convert.ToDateTime(value))
            };
        }

        public override void SetValue(IDbDataParameter parameter, DateOnly value)
        {
            parameter.DbType = DbType.Date;
            parameter.Value = value.ToDateTime(TimeOnly.MinValue);
        }
    }

    public sealed class NullableDateOnlyTypeHandler : SqlMapper.TypeHandler<DateOnly?>
    {
        public override DateOnly? Parse(object value)
        {
            if (value is null or DBNull)
                return null;

            return value switch
            {
                DateOnly dateOnly => dateOnly,
                DateTime dateTime => DateOnly.FromDateTime(dateTime),
                _ => DateOnly.FromDateTime(Convert.ToDateTime(value))
            };
        }

        public override void SetValue(IDbDataParameter parameter, DateOnly? value)
        {
            parameter.DbType = DbType.Date;
            parameter.Value = value?.ToDateTime(TimeOnly.MinValue) ?? (object)DBNull.Value;
        }
    }
}
