using API.DarkShame.Domain.Entities.Store.Payment;
using API.DarkShame.Domain.Interfaces;
using API.DarkShame.Domain.Interfaces.Payment;
using API.DarkShame.Infra.Contexts;
using MongoDB.Driver;

namespace API.DarkShame.Infra.Repository.Store.Payment
{
    public class RepositoryPayments : IRepositoryPayments
    {
        private readonly IContext _context;

        public RepositoryPayments()
        {
            _context = new Context();
        }

        public async Task<List<Payments>> GetPayments()
        {
            var payments = await _context.Payments.FindAsync(_ => true);
            return payments.ToList();
        }

        public async Task<Payments> GetPaymentsById(int codePayment)
        {
            var paymentId = await _context.Payments.Find(x => x.CodePayment == codePayment).FirstOrDefaultAsync();
            return paymentId;
        }

        public async Task CreatePayments(Payments payments)
        {
            await _context.Payments.InsertOneAsync(payments);
        }
    }
}
