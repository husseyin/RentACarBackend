using Core.Entities.Concrete;
using Core.Utilities.Results.DataResult;
using Core.Utilities.Results.OperationResult;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IDataResult<User> GetByEmail(string email);
        IDataResult<List<OperationClaim>> GetClaims(User user);
    }
}
