using DHI_Challenges.Models.DataTransferObject;
using DHI_Challenges.Models.Entities;
using DHI_Challenges.Services.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace DHI_Challenges.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private ResponseGlobalDto _objResponse;
        private ResponseErrorDto _objResponseError;
        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _objResponse = new();
            _objResponseError = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAll()
        {
            List<MasterUser> objList = _unitOfWork.User.GetAll().ToList();

            _objResponse = new()
            {
                StatusCode =  StatusCodes.Status200OK,
                Message = objList != null ? "Success" : "Data not exist",
                Data = objList
            };

            return Ok(_objResponse);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get(int id)
        {
            MasterUser obj = _unitOfWork.User.Get(ss => ss.UserID == id);

            if (obj == null)
            {
                _objResponse = new()
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = "Data not found"
                };

                return NotFound(_objResponse);
            }

            _objResponse = new()
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Success",
                Data = obj
            };

            return Ok(_objResponse);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Create([FromBody] RequestUserDto value)
        {
            MasterUser obj = new();
            obj.FullName = value.FullName;
            obj.PhoneNumber = value.PhoneNumber;

            _unitOfWork.User.Add(obj);
            _unitOfWork.Save();


            MasterUser objList = _unitOfWork.User.Get(ss => ss.UserID == obj.UserID);
            _objResponse = new()
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Success",
                Data = _unitOfWork.User.Get(ss => ss.UserID == obj.UserID)
            };

            return Ok(_objResponse);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Put(int id, [FromBody] RequestUserDto value)
        {
            MasterUser obj = _unitOfWork.User.Get(ss => ss.UserID == id);

            if (obj == null)
            {
                _objResponse = new()
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = "Data not found"
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
                Message = "Success",
                Data = obj
            };

            return Ok(_objResponse);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(int id)
        {
            MasterUser obj = _unitOfWork.User.Get(ss => ss.UserID == id);

            if (obj == null)
            {
                _objResponse = new()
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = "Data not found"
                };

                return NotFound(_objResponse);
            }

            _objResponse = new()
            {
                StatusCode = StatusCodes.Status200OK,
                Message = "Success"
            };

            return Ok(_objResponse);
        }
    }
}
