using API.DarkShame.Domain.Dto.Response;
using API.DarkShame.Domain.Entities.Store.Game;
using API.DarkShame.Domain.Entities.Store.Payment;
using API.DarkShame.Domain.Interfaces.Payment;
using API.DarkShame.Infra.Repository.Store.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DarkShame.Services.Store.Payment
{
    public class ServicePayments : IServicePayments
    {
        private readonly IRepositoryPayments _repositoryPayments;

        public ServicePayments()
        {
            _repositoryPayments = new RepositoryPayments();
        }

        public async Task<List<Payments>> GetPayments()
        {
            var payments = await _repositoryPayments.GetPayments();
            return payments;
        }

        public async Task<Payments> GetPaymentsById(int codePayment)
        {
            var paymentId = await _repositoryPayments.GetPaymentsById(codePayment);
            return paymentId;
        }

        public async Task<ReturnDto> CreatePayments(Payments payments)
        {
            ReturnDto returnDto = new ReturnDto();

            var ret = _repositoryPayments.CreatePayments(payments);

            if (ret.Exception != null)
            {
                returnDto.ThereError = true;
                returnDto.CodeError = "400";
                returnDto.TitleError = "Gravar Pagamentos";
                returnDto.MessageError = "Erro no processo de gravar os Pagamentos";
            }

            return await Task.FromResult(returnDto);
        }
    }
}
