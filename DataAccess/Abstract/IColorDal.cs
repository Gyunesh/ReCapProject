using System;
using System.Collections.Generic;
using Entities.Concrete;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;

namespace DataAccess.Abstract
{
    public interface IColorDal:IEntityRepository<Color>
    {
    }
}
