using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface IImageService
    {
        IResult Add(CarImage image, IFormFile file);
        IResult Update(CarImage image, IFormFile file);
        IResult Delete(CarImage image);
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> GetById(int id);
    }
}
