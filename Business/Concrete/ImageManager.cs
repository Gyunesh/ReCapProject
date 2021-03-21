using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class ImageManager : IImageService
    {
        private IImageDal _imageDal;
     
        public ImageManager(IImageDal imageDal)
        {
            _imageDal = imageDal;
        }
        
        [ValidationAspect(typeof(ImageValidator))]
        public IResult Add(Image image, IFormFile file)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(image.CarId));
            if (result != null)
            {
                return result;
            }

            image.ImagePath = FileHelper.Add(file);
            image.Date = DateTime.Now;
            _imageDal.Add(image);
            return new SuccessResult();
        }

        private IResult CheckImageLimitExceeded(int carId)
        {
            var count = _imageDal.GetAll(p => p.CarId == carId).Count;
            if (count >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded);
            }

            return new SuccessResult();
        }

        public IResult Delete(Image image)
        {
            FileHelper.Delete(image.ImagePath);
            _imageDal.Delete(image);
            return new SuccessResult();
        }

        public IDataResult<List<Image>> GetAll()
        {
            return new SuccessDataResult<List<Image>>(_imageDal.GetAll());
        }

        public IDataResult<Image> GetById(int id)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageNull(id));
            if (result!=null)
            {
                return new ErrorDataResult<Image>();
            }

            return new SuccessDataResult<Image>();
        }

        private IDataResult<Image> CheckIfCarImageNull(int id)
        {
            try
            {
                string path = @"\uploads\default.jpg";

                var result = _imageDal.GetAll(c => c.CarId == id).Any();

                if (!result)
                {
                    List<Image> image = new List<Image>();

                    image.Add(new Image { CarId = id, ImagePath = path, Date = DateTime.Now });

                    return new SuccessDataResult<Image>();
                }
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<Image>();
            }

            return new SuccessDataResult<Image> ();
        }

        public IResult Update(Image image, IFormFile file)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(image.CarId));
            if (result != null)
            {
                return result;
            }

            var oldPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) + _imageDal.Get(p => p.Id == image.Id).ImagePath;

            image.ImagePath = FileHelper.Update(oldPath, file);
            image.Date = DateTime.Now;
            _imageDal.Update(image);
            return new SuccessResult();
        }
    }
}
