using BizServiceApi.Database.Repository;
using BizServiceApi.Database.Repository.Models;
using Capitec.Api.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Web.Helpers;

namespace Capitec.Api.Repository
{
    public class Gateway
    {
        private readonly DbContextOptions<TransformationDbContext> _context;

        public Gateway(DbContextOptions<TransformationDbContext> context)
        {
            _context = context;
        }

        public int SaveTransaction(NearRealTimeRequest request)
        {
            var jsonRequest = JsonConvert.SerializeObject(request);

            using var context = new TransformationDbContext(_context);
            var nrt = new CapitecNrt
            {
                MessageId = new Guid(request.messageID),
                Received = DateTime.Now,
                OrignalJson = jsonRequest
            };

            context.CapitecNrts.Add(nrt);

            context.SaveChanges();

            return nrt.Id;
        }

        public void UpdateTransaction(int id, DateTime? sentToBiz, string result)
        {
            using var context = new TransformationDbContext(_context);
            var nrt = context.CapitecNrts.FirstOrDefault(t => t.Id == id);
            if (nrt == null) return;

            nrt.SentToBiz = sentToBiz;
            nrt.Result = result;

            context.CapitecNrts.Update(nrt);

            context.SaveChanges();
        }

        internal bool Authenticate(string? loginID, string? password)
        {
            using var context = new TransformationDbContext(_context);

            var authenticate = context.Authenticates.FirstOrDefault(a => a.LoginId == loginID);
            if (authenticate == null) return false;
            var verified = Crypto.VerifyHashedPassword(authenticate.Hash, password);

            return verified;
        }

        internal void AddUser(string loginID, string password)
        {
            using var context = new TransformationDbContext(_context);

            var hash = Crypto.HashPassword(password);
            var verified = Crypto.VerifyHashedPassword(hash, password);

            context.Authenticates.Add(new Authenticate
            {
                Hash = hash,
                LoginId = loginID,
            });

            context.SaveChanges();
        }
    }
}
