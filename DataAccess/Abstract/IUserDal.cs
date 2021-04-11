using Core.DataAccess.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results.DataResult;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        IDataResult<List<OperationClaim>> GetClaims(User user);
    }
}
