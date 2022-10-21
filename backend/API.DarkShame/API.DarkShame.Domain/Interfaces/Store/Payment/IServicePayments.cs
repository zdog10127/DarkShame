using API.DarkShame.Domain.Dto.Response;
using API.DarkShame.Domain.Entities.Store.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DarkShame.Domain.Interfaces.Payment
{
    public interface IServicePayments
    {
        Task<List<Payments>> GetPayments();
        Task<Payments> GetPaymentsById(int codePayment);
        Task<ReturnDto> CreatePayments(Payments payments);
    }
}
