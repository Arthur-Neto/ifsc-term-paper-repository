using System;
using ifsc.tcc.Portal.Domain.CommonModule;

namespace ifsc.tcc.Portal.Infra.Data.Crosscutting.Guard
{
    public static class Guard
    {
        public static void AgainstNull(object entity, ExceptionArguments argument)
        {
            if (entity == null)
            {
                throw new NullReferenceException(argument.ToString());
            }
        }
    }
}
