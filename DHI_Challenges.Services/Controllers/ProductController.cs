using DHI_Challenges.Models.DataTransferObject;
using DHI_Challenges.Models.Entities;
using DHI_Challenges.Services.Repositories.IRepositories;
using DHI_Challenges.Services.Utils;
using Microsoft.AspNetCore.Mvc;

namespace DHI_Challenges.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private ResponseGlobalDto _objResponse;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _objResponse = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseGlobalDto))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseExceptionDto))]
        public IActionResult GetAll()
        {
            List<MasterProduct> objList = _unitOfWork.Product.GetAll(ss => ss.IsDelete == false).ToList();

            _objResponse = new()
            {
                StatusCode =  StatusCodes.Status200OK,
                Message = objList != null ? Message.SUCCESS : Message.DATA_NOT_EXIST,
                Data = objList
            };

            return Ok(_objResponse);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseGlobalDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResponseErrorDto))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseExceptionDto))]
        public IActionResult Get(int id)
        {
            MasterProduct obj = _unitOfWork.Product.Get(ss => ss.IsDelete == false && ss.ProductID == id);

            if (obj == null)
            {
                _objResponse = new()
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = Message.DATA_NOT_FOUND
                };

                return NotFound(_objResponse);
            }

            _objResponse = new()
            {
                StatusCode = StatusCodes.Status200OK,
                Message = Message.SUCCESS,
                Data = obj
            };

            return Ok(_objResponse);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseGlobalDto))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseExceptionDto))]
        public IActionResult Create([FromBody] RequestProductDto value)
        {
            MasterProduct obj = new();
            obj.ProductName = value.ProductName;
            obj.Price = value.Price;

            _unitOfWork.Product.Add(obj);
            _unitOfWork.Save();

            MasterProduct objList = _unitOfWork.Product.Get(ss => ss.IsDelete == false && ss.ProductID == obj.ProductID);

            _objResponse = new()
            {
                StatusCode = StatusCodes.Status200OK,
                Message = Message.SUCCESS,
                Data = _unitOfWork.Product.Get(ss => ss.ProductID == obj.ProductID)
            };

            return Ok(_objResponse);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseGlobalDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResponseErrorDto))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseExceptionDto))]
        public IActionResult Put(int id, [FromBody] RequestProductDto value)
        {
            MasterProduct obj = _unitOfWork.Product.Get(ss => ss.IsDelete == false && ss.ProductID == id);

            if (obj == null)
            {
                _objResponse = new()
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = Message.DATA_NOT_FOUND
                };

                return NotFound(_objResponse);
            }

            obj.ProductName = value.ProductName;
            obj.Price = value.Price;

            _unitOfWork.Product.Update(obj);
            _unitOfWork.Save();

            _objResponse = new()
            {
                StatusCode = StatusCodes.Status200OK,
                Message = Message.SUCCESS,
                Data = obj
            };

            return Ok(_objResponse);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseGlobalDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResponseErrorDto))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseExceptionDto))]
        public IActionResult Delete(int id)
        {
            MasterProduct obj = _unitOfWork.Product.Get(ss => ss.IsDelete == false && ss.ProductID == id);

            if (obj == null)
            {
                _objResponse = new()
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = Message.DATA_NOT_FOUND
                };

                return NotFound(_objResponse);
            }

            obj.IsDelete = true;

            _unitOfWork.Product.Update(obj);
            _unitOfWork.Save();

            _objResponse = new()
            {
                StatusCode = StatusCodes.Status200OK,
                Message = Message.SUCCESS
            };

            return Ok(_objResponse);
        }
    }
}
