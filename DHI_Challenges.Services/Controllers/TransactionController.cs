using DHI_Challenges.Models.DataTransferObject;
using DHI_Challenges.Models.Entities;
using DHI_Challenges.Services.Repositories.IRepositories;
using DHI_Challenges.Services.Utils;
using Microsoft.AspNetCore.Mvc;

namespace DHI_Challenges.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private ResponseGlobalDto _objResponse;
        public TransactionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _objResponse = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseGlobalDto))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseExceptionDto))]
        public IActionResult GetAll()
        {
            List<ResponseTransactionHeaderDto> objList = new();

            foreach (var item in _unitOfWork.Header.GetAll(ss => ss.IsDelete == false).ToList())
            {
                List<TransactionDetail> objListDetails = _unitOfWork.Detail.GetAll(ss => ss.HeaderID == item.HeaderID).ToList();

                objList.Add(MapToResponseDto(item, objListDetails));
            }

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
            TransactionHeader objHeader = _unitOfWork.Header.Get(ss => ss.IsDelete == false && ss.HeaderID == id);

            if (objHeader == null)
            {
                _objResponse = new()
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = Message.DATA_NOT_FOUND
                };

                return NotFound(_objResponse);
            }

            List<TransactionDetail> objListDetails = _unitOfWork.Detail.GetAll(ss => ss.HeaderID == objHeader.HeaderID).ToList();
            ResponseTransactionHeaderDto obj = MapToResponseDto(objHeader, objListDetails);

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
        public IActionResult Create([FromBody] RequestTransactionHeaderDto<RequestTransactionDetailDto> value)
        {
            try
            {
                List<int> productIdList = value.Details
                .GroupBy(ss => ss.ProductID)
                .Select(group => group.Key)
                .ToList();

                List<MasterProduct> objProductList = _unitOfWork.Product.GetAll(ss => ss.IsDelete == false && productIdList.Contains(ss.ProductID)).ToList();

                if (productIdList.Count() != objProductList.Count())
                {
                    _objResponse = new()
                    {
                        StatusCode = StatusCodes.Status404NotFound,
                        Message = Message.DATA_SOME_PRODUCT_NOT_FOUND
                    };
                    return NotFound(_objResponse);
                }

                    _unitOfWork.BeginTransaction();
                TransactionHeader objHeader = new();
                objHeader.UserID = value.UserID;
                objHeader.SummaryQuantity = value.Details.Sum(ss => ss.Quantity);
                objHeader.CreateDate = DateTime.Now;

                _unitOfWork.Header.Add(objHeader);
                _unitOfWork.Save();

                var detail = value.Details
                .GroupBy(ss => ss.ProductID)
                .Select(group => new
                {
                    ProductID = group.Key,
                    Quantity = group.Sum(x => x.Quantity)
                });

                List<TransactionDetail> objDetail = new();
                foreach (var item in detail)
                {
                    TransactionDetail obj = new();
                    obj.HeaderID = objHeader.HeaderID;
                    obj.ProductID = item.ProductID;
                    obj.Quantity = item.Quantity;
                    obj.Price = _unitOfWork.Product.Get(ss => ss.ProductID == item.ProductID).Price * item.Quantity;
                    objDetail.Add(obj);
                }
                _unitOfWork.Detail.AddRange(objDetail);
                _unitOfWork.Save();

                _unitOfWork.CommitTransaction();

                _objResponse = new()
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = Message.SUCCESS,
                    Data = _unitOfWork.Header.Get(ss => ss.HeaderID == objHeader.HeaderID)
                };

                return Ok(_objResponse);
            }
            catch (Exception)
            {
                _unitOfWork.RollbackTransaction();

                throw;
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseGlobalDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResponseErrorDto))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseExceptionDto))]
        public IActionResult Delete(int id)
        {
            TransactionHeader obj = _unitOfWork.Header.Get(ss => ss.IsDelete == false && ss.HeaderID == id);

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

            _unitOfWork.Header.Update(obj);
            _unitOfWork.Save();

            _objResponse = new()
            {
                StatusCode = StatusCodes.Status200OK,
                Message = Message.SUCCESS
            };

            return Ok(_objResponse);
        }

        private ResponseTransactionHeaderDto MapToResponseDto(TransactionHeader header, List<TransactionDetail> details)
        {
            return new ResponseTransactionHeaderDto
            {
                HeaderID = header.HeaderID,
                UserID = header.UserID,
                CreateDate = header.CreateDate,
                SummaryQuantity = header.SummaryQuantity,
                Details = details.Select(d => new ResponseransactionDetailDto
                {
                    ProductID = d.ProductID,
                    Quantity = d.Quantity,
                    Price = d.Price
                }).ToList()
            };
        }
    }
}
