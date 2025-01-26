using DHI_Challenges.Models.DataTransferObject;
using DHI_Challenges.Models.Entities;
using DHI_Challenges.Services.Repositories.IRepositories;
using DHI_Challenges.Services.Utils;
using Microsoft.AspNetCore.Mvc;

namespace DHI_Challenges.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private ResponseGlobalDto _objResponse;
        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _objResponse = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseGlobalDto))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseExceptionDto))]
        public IActionResult GetAll()
        {
            List<MasterUser> objList = _unitOfWork.User.GetAll(ss => ss.IsDelete == false).ToList();

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
            MasterUser obj = _unitOfWork.User.Get(ss => ss.IsDelete == false && ss.UserID == id);

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
        public IActionResult Create([FromBody] RequestUserDto value)
        {
            MasterUser obj = new();
            obj.FullName = value.FullName;
            obj.PhoneNumber = value.PhoneNumber;

            _unitOfWork.User.Add(obj);
            _unitOfWork.Save();


            MasterUser objList = _unitOfWork.User.Get(ss => ss.IsDelete == false && ss.UserID == obj.UserID);
            _objResponse = new()
            {
                StatusCode = StatusCodes.Status200OK,
                Message = Message.SUCCESS,
                Data = _unitOfWork.User.Get(ss => ss.UserID == obj.UserID)
            };

            return Ok(_objResponse);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseGlobalDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResponseErrorDto))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseExceptionDto))]
        public IActionResult Put(int id, [FromBody] RequestUserDto value)
        {
            MasterUser obj = _unitOfWork.User.Get(ss => ss.IsDelete == false && ss.UserID == id);

            if (obj == null)
            {
                _objResponse = new()
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = Message.DATA_NOT_FOUND
                };

                return NotFound(_objResponse);
            }

            obj.FullName = value.FullName;
            obj.PhoneNumber = value.PhoneNumber;

            _unitOfWork.User.Update(obj);
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
            MasterUser obj = _unitOfWork.User.Get(ss => ss.IsDelete == false && ss.UserID == id);

            if (obj == null)
            {
                _objResponse = new()
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = Message.SUCCESS
                };

                return NotFound(_objResponse);
            }

            obj.IsDelete = false;

            _objResponse = new()
            {
                StatusCode = StatusCodes.Status200OK,
                Message = Message.SUCCESS
            };

            return Ok(_objResponse);
        }
    }
}
