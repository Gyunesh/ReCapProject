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
        IResult Add(Image image, IFormFile file);
        IResult Update(Image image, IFormFile file);
        IResult Delete(Image image);
        IDataResult<List<Image>> GetAll();
        IDataResult<Image> GetById(int id);
    }
}
