using Numiteq.BusinessLogic.BusinessContracts;
using Numiteq.Common.Entities;
using Numiteq.DataAccess.DataContracts;

namespace Numiteq.BusinessLogic.BusinessComponents
{
    public class NumberService : DataService<Number>, INumberService
    {
        public NumberService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public Number Add(int value, string label)
        {
            Number newNumber = Add(new Number
            {
                Value = value,
                Label = label
            });

            return newNumber;
        }

        public Number Update(int id, int value, string label)
        {
            Number number = GetById(id);

            if (number == null)
            {
                return null;
            }

            number.Value = value;
            number.Label = label;

            Update(number);

            return number;
        }
    }
}