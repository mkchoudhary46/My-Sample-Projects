using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LifeLine.Core;
using LifeLine.Core.DAO;
using LifeLine.Core.Interfaces;

namespace LifeLine.Infrastructure.Repositories
{
    public class BloodDonorRepository : IBloodDonorRepository
    {
        private readonly IBloodDonorContext _context;

        public BloodDonorRepository(IBloodDonorContext context)
        {
            _context = context;
        }
        public void Add(BloodDonor b)
        {
            _context.BloodDonors.Add(b);
            _context.SaveChanges();
        }  

        public void Edit(BloodDonor b)
        {
            
        }

        public void Remove(string bloodDonorId)
        {
            BloodDonor b = _context.BloodDonors.Find(bloodDonorId);
            _context.BloodDonors.Remove(b);
            _context.SaveChanges();  
        }

        public IEnumerable<BloodDonor> GetBloodDonors()
        {
            return _context.BloodDonors;
        }

        public BloodDonor FindById(string bloodDonorId)
        {
            var bloodDonor = (from r in _context.BloodDonors where r.BloodDonorId == bloodDonorId select r).FirstOrDefault();
            return bloodDonor; 
        }
    }
}
