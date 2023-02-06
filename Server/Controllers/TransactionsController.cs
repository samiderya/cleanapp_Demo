using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Server.Entity;
using Server.Response;
using Server.Services;

namespace Server.Controllers
{
    [Route("api/transactions")]
    // [Controller]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly ILogger<TransactionsController> _logger;
        public TransactionsController(ILogger<TransactionsController> logger, ITransactionRepository transactionRepository)
        {
            this._logger = logger;
            _transactionRepository = transactionRepository ?? throw new ArgumentNullException(nameof(transactionRepository));

        }
        /// <summary>
        [Route("[action]/{userId}")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> getTransactionByUserId(short userId)
        {

            var response = new ListResponse<Transactions>();
            try
            {
                var res = await _transactionRepository.getTransactionByUserId(userId);
                if (res == null)
                {
                    response.DidError = false;
                    response.ErrorMessage = "Data not found";
                }
                else
                {

                    response.DidError = false;
                    response.Model = res;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Stopped program because of exception");
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";
                throw;

            }
            return response.ToHttpResponse();

        }

        /// <summary>
        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Save([FromBody] Server.Models.Dto.TransactionDto model)
        {
            var response = new Responses();
            try
            {
                var ent = new Transactions()
                {
                    card_type = model.card_type,
                    cardowner_name = model.cardowner_name,
                    card_number = model.card_number,
                    expired_date = model.expired_date,
                    ccv = model.ccv,
                    amount = model.amount,
                    user_id = model.user_id,
                    transaction_typeid = model.transaction_typeid
                };
                var res = await _transactionRepository.Save(ent);
                if (res)
                {
                    response.Message = "Transaction Sucessfully Saved";
                }
                else
                {
                    response.DidError = true;
                    response.ErrorMessage = "Please try again";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Stopped program because of exception");
                response.DidError = true;
                response.ErrorMessage = "There was an internal error, please contact to technical support.";
                throw;

            }
            return response.ToHttpResponse();

        }
    }
}