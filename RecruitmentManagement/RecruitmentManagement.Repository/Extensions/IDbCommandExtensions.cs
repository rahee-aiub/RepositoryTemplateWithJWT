using System.Data;

namespace RecruitmentManagement.DAL.Extensions
{
    public static class IDbCommandExtensions
    {
        public static IDbDataParameter CreateParameter(this IDbCommand command, string name, object value)
        {
            var parameter = command.CreateParameter();
            parameter.ParameterName = name;
            parameter.Value = value;

            return parameter;
        }
    }
}
