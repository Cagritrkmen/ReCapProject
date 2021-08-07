using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using Core.Entities.Concrete;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
        IDataResult<List<User>> GetAll();
        IDataResult<User>GetById(int userId);
        IDataResult <List<OperationClaim>> GetClaims(User user);
         IDataResult<User> GetByMail(string email);
        
    }
}
